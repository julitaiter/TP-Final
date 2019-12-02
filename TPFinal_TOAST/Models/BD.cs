using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Net;

namespace TPFinal_TOAST.Models
{
    public static class BD
    {
        //Metodos de SQL
        public static SqlConnection Conectar()
        {
            System.Security.SecureString contra = new NetworkCredential("", "alumno").SecurePassword;
            contra.MakeReadOnly();
            string strConn = "Server=.;Database=BD - TOAST;Trusted_Connection=True;";
            strConn += "Integrated Security = False;";
            SqlConnection Conexion = new SqlConnection(strConn);
            SqlCredential usr = new SqlCredential("alumno", contra);
            Conexion.Credential = usr;
            Conexion.Open();
            return Conexion;
        }
        public static void Desconectar(SqlConnection Conn)
        {
            Conn.Close();
        }

        //Metodos Recetas
        public static void IngresarReceta(Receta rec)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "IngresarRecetas";
            Consulta.Parameters.Add(new SqlParameter("@NombreReceta", rec.NombreReceta));
            Consulta.Parameters.Add(new SqlParameter("@Categoria", rec.Categoria));
            Consulta.Parameters.Add(new SqlParameter("@Preparacion", rec.Preparacion));
            Consulta.Parameters.Add(new SqlParameter("@TiempoPreparacion", rec.TiempoPreparacion));
            Consulta.Parameters.Add(new SqlParameter("@CantidadPlatos", rec.CantidadPlatos));
            Consulta.Parameters.Add(new SqlParameter("@Dificultad", rec.Dificultad));
            Consulta.Parameters.Add(new SqlParameter("@Foto", rec.NombreFoto));
            Consulta.Parameters.Add(new SqlParameter("@Cant_Likes", rec.Cant_Likes));
            Consulta.Parameters.Add(new SqlParameter("@Autor", rec.Autor));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }
        public static void ModificarReceta(Receta rec)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "ModificarReceta";
            Consulta.Parameters.Add(new SqlParameter("@NombreReceta", rec.NombreReceta));
            Consulta.Parameters.Add(new SqlParameter("@Categoria", rec.Categoria));
            Consulta.Parameters.Add(new SqlParameter("@Preparacion", rec.Preparacion));
            Consulta.Parameters.Add(new SqlParameter("@TiempoPreparacion", rec.TiempoPreparacion));
            Consulta.Parameters.Add(new SqlParameter("@CantidadPlatos", rec.CantidadPlatos));
            Consulta.Parameters.Add(new SqlParameter("@Dificultad", rec.Dificultad));
            Consulta.Parameters.Add(new SqlParameter("@Foto", rec.NombreFoto));
            Consulta.Parameters.Add(new SqlParameter("@Cant_Likes", rec.Cant_Likes));
            Consulta.Parameters.Add(new SqlParameter("@Autor", rec.Autor));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }
        public static void EliminarReceta(int IDReceta)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "EliminarReceta";
            Consulta.Parameters.Add(new SqlParameter("@IDReceta", IDReceta));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }
        public static Receta TraerReceta(int idrec)
        {
            SqlConnection Conn = Conectar();
            Receta UnaReceta = new Receta();
            List<Ingrediente> Ingredientes = new List<Ingrediente>();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "TraerInfoReceta";
            Consulta.Parameters.Add(new SqlParameter("@id", idrec));
            SqlDataReader Lector = Consulta.ExecuteReader();

            while (Lector.Read())
            {
                int IDReceta = Convert.ToInt32(Lector["IDReceta"]);
                string NombreReceta = Lector["NombreReceta"].ToString();
                int idcate = Convert.ToInt32(Lector["Categoria"]);
                string Preparacion = Lector["Preparacion"].ToString();
                int TiempoPreparacion = Convert.ToInt32(Lector["TiempoPreparacion"]);
                float CantidadPlatos = Convert.ToInt32(Lector["CantidadPlatos"]);
                int iddifi = Convert.ToInt32(Lector["Dificultad"]);
                string NombreFoto = Lector["Foto"].ToString();
                int Cant_Likes = Convert.ToInt32(Lector["Cant_Likes"]);
                int Autor = Convert.ToInt32(Lector["Autor"]);
                HttpPostedFileBase Foto = null;
                Dificultad LaDificultad = new Dificultad();
                LaDificultad = BD.TraerDificultad(iddifi);
                Categoria LaCategoria = new Categoria();
                LaCategoria = BD.TraerCategoria(idcate);
                UnaReceta = new Receta(IDReceta, NombreReceta, LaCategoria, Preparacion, TiempoPreparacion, CantidadPlatos, LaDificultad, Foto, NombreFoto, Ingredientes, Cant_Likes, Autor);
                UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
            }

            Desconectar(Conn);
            return UnaReceta;
        }       
        public static int CantidadRecetas()
        {
            SqlConnection Conn = Conectar();
            int i = -1;
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "CantidadRecetas";
            SqlDataReader Lector = Consulta.ExecuteReader();
            if (Lector.Read())
            {
                i = Convert.ToInt32(Lector["cant"]);
            }

            return i;
        }
        public static List<Receta> TraerRecetas(string ElIngrediente)
        {
            List<Receta> LasRecetas = new List<Receta>();
            List<Ingrediente> Ingredientes = new List<Ingrediente>();
            Receta UnaReceta = new Receta();
            SqlConnection Conn = Conectar();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "BusquedaReceta";
            Consulta.Parameters.Add(new SqlParameter("@NombreIngrediente", ElIngrediente));
            SqlDataReader Lector = Consulta.ExecuteReader();

            while (Lector.Read())
            {
                int IDReceta = Convert.ToInt32(Lector["IDReceta"]);
                string NombreReceta = Lector["NombreReceta"].ToString();
                int idcate = Convert.ToInt32(Lector["Categoria"]);
                string Preparacion = Lector["Preparacion"].ToString();
                int TiempoPreparacion = Convert.ToInt32(Lector["TiempoPreparacion"]);
                float CantidadPlatos = Convert.ToInt32(Lector["CantidadPlatos"]);
                int iddifi = Convert.ToInt32(Lector["Dificultad"]);
                string NombreFoto = Lector["Foto"].ToString();
                int Cant_Likes = Convert.ToInt32(Lector["Cant_Likes"]);
                int Autor = Convert.ToInt32(Lector["Autor"]);
                HttpPostedFileBase Foto = null;
                Dificultad LaDificultad = new Dificultad();
                LaDificultad = BD.TraerDificultad(iddifi);
                Categoria LaCategoria = new Categoria();
                LaCategoria = BD.TraerCategoria(idcate);
                UnaReceta = new Receta(IDReceta, NombreReceta, LaCategoria, Preparacion, TiempoPreparacion, CantidadPlatos, LaDificultad, Foto, NombreFoto, Ingredientes, Cant_Likes, Autor);
                UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
                LasRecetas.Add(UnaReceta);
            }

            Desconectar(Conn);
            return LasRecetas;
        }
        public static List<Receta> ListarRecetas()
        {
            SqlConnection Conn = Conectar();
            Receta UnaReceta = new Receta();
            List<Receta> ListaDeRecetas = new List<Receta>();
            List<Ingrediente> Ingredientes = new List<Ingrediente>();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "ListarRecetas";
            SqlDataReader Lector = Consulta.ExecuteReader();

            while (Lector.Read())
            {
                int IDReceta = Convert.ToInt32(Lector["IDReceta"]);
                string NombreReceta = Lector["NombreReceta"].ToString();
                int idcate = Convert.ToInt32(Lector["Categoria"]);
                string Preparacion = Lector["Preparacion"].ToString();
                int TiempoPreparacion = Convert.ToInt32(Lector["TiempoPreparacion"]);
                float CantidadPlatos = Convert.ToInt32(Lector["CantidadPlatos"]);
                int iddifi = Convert.ToInt32(Lector["Dificultad"]);
                string NombreFoto = Lector["Foto"].ToString();
                int Cant_Likes = Convert.ToInt32(Lector["Cant_Likes"]);
                int Autor = Convert.ToInt32(Lector["Autor"]);
                HttpPostedFileBase Foto = null;
                Dificultad LaDificultad = new Dificultad();
                LaDificultad = BD.TraerDificultad(iddifi);
                Categoria LaCategoria = new Categoria();
                LaCategoria = BD.TraerCategoria(idcate);
                UnaReceta = new Receta(IDReceta, NombreReceta, LaCategoria, Preparacion, TiempoPreparacion, CantidadPlatos, LaDificultad, Foto, NombreFoto, Ingredientes, Cant_Likes, Autor);
                UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
                ListaDeRecetas.Add(UnaReceta);
            }

            Desconectar(Conn);
            return ListaDeRecetas;
        }
        public static List<Receta> FiltrarRecetas(string NombreReceta, int Categoria, int TiempoPreparacion, float Cantidad, float Dificultad, int Cant_Likes, int Autor)
        {

            SqlConnection Conn = Conectar();
            Receta UnaReceta = new Receta();
            List<Receta> ListaDeRecetas = new List<Receta>();
            List<Ingrediente> Ingredientes = new List<Ingrediente>();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.Add(new SqlParameter("@NombreReceta", NombreReceta));
            Consulta.Parameters.Add(new SqlParameter("@Categoria", Categoria));
            Consulta.Parameters.Add(new SqlParameter("@TiempoPreparacion", TiempoPreparacion));
            Consulta.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
            Consulta.Parameters.Add(new SqlParameter("@Dificultad", Dificultad));
            Consulta.Parameters.Add(new SqlParameter("@Cant_Likes", Cant_Likes));
            Consulta.Parameters.Add(new SqlParameter("@Autor", Autor));

            Consulta.CommandText = "FiltrarRecetas";

            SqlDataReader Lector = Consulta.ExecuteReader();

            while (Lector.Read())
            {
                int IDReceta1 = Convert.ToInt32(Lector["IDReceta"]);
                string NombreReceta1 = Lector["NombreReceta"].ToString();
                int idcate = Convert.ToInt32(Lector["Categoria"]);
                string Preparacion1 = Lector["Preparacion"].ToString();
                int TiempoPreparacion1 = Convert.ToInt32(Lector["TiempoPreparacion"]);
                float CantidadPlatos1 = Convert.ToInt32(Lector["CantidadPlatos"]);
                int iddifi = Convert.ToInt32(Lector["Dificultad"]);
                string NombreFoto1 = Lector["Foto"].ToString();
                int Cant_Likes1 = Convert.ToInt32(Lector["Cant_Likes"]);
                int Autor1 = Convert.ToInt32(Lector["Autor"]);
                HttpPostedFileBase Foto1 = null;
                Dificultad LaDificultad = new Dificultad();
                LaDificultad = BD.TraerDificultad(iddifi);
                Categoria LaCategoria = new Categoria();
                LaCategoria = BD.TraerCategoria(idcate);
                UnaReceta = new Receta(IDReceta1, NombreReceta1, LaCategoria, Preparacion1, TiempoPreparacion1, CantidadPlatos1, LaDificultad, Foto1, NombreFoto1, Ingredientes, Cant_Likes1, Autor1);
                UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
                ListaDeRecetas.Add(UnaReceta);
            }

            Desconectar(Conn);
            return ListaDeRecetas;
        }
        public static List<Receta> TraerRecetasxCat(int IdCat)
        {
            List<Receta> LasRecetas = new List<Receta>();
            List<Ingrediente> Ingredientes = new List<Ingrediente>();
            Receta UnaReceta = new Receta();
            SqlConnection Conn = Conectar();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "SELECT *  FROM Recetas WHERE Categoria =" + IdCat;
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int IDReceta = Convert.ToInt32(Lector["IDReceta"]);
                string NombreReceta = Lector["NombreReceta"].ToString();
                int idcate = Convert.ToInt32(Lector["Categoria"]);
                string Preparacion = Lector["Preparacion"].ToString();
                int TiempoPreparacion = Convert.ToInt32(Lector["TiempoPreparacion"]);
                float CantidadPlatos = Convert.ToInt32(Lector["CantidadPlatos"]);
                int iddifi = Convert.ToInt32(Lector["Dificultad"]);
                string NombreFoto = Lector["Foto"].ToString();
                int Cant_Likes = Convert.ToInt32(Lector["Cant_Likes"]);
                int Autor = Convert.ToInt32(Lector["Autor"]);
                HttpPostedFileBase Foto = null;
                Dificultad LaDificultad = new Dificultad();
                LaDificultad = BD.TraerDificultad(iddifi);
                Categoria LaCategoria = new Categoria();
                LaCategoria = BD.TraerCategoria(idcate);
                UnaReceta = new Receta(IDReceta, NombreReceta, LaCategoria, Preparacion, TiempoPreparacion, CantidadPlatos, LaDificultad, Foto, NombreFoto, Ingredientes, Cant_Likes, Autor);
                UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
                LasRecetas.Add(UnaReceta);
            }

            Desconectar(Conn);
            return LasRecetas;
        }
        public static List<Receta> TraerRecetasxAutor(int IDAutor)
        {
            List<Receta> LasRecetas = new List<Receta>();
            List<Ingrediente> Ingredientes = new List<Ingrediente>();
            Receta UnaReceta = new Receta();
            SqlConnection Conn = Conectar();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "SELECT *  FROM Recetas WHERE Autor =" + IDAutor;
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int IDReceta = Convert.ToInt32(Lector["IDReceta"]);
                string NombreReceta = Lector["NombreReceta"].ToString();
                int idcate = Convert.ToInt32(Lector["Categoria"]);
                string Preparacion = Lector["Preparacion"].ToString();
                int TiempoPreparacion = Convert.ToInt32(Lector["TiempoPreparacion"]);
                float CantidadPlatos = Convert.ToInt32(Lector["CantidadPlatos"]);
                int iddifi = Convert.ToInt32(Lector["Dificultad"]);
                string NombreFoto = Lector["Foto"].ToString();
                int Cant_Likes = Convert.ToInt32(Lector["Cant_Likes"]);
                int Autor = Convert.ToInt32(Lector["Autor"]);
                HttpPostedFileBase Foto = null;
                Dificultad LaDificultad = new Dificultad();
                LaDificultad = BD.TraerDificultad(iddifi);
                Categoria LaCategoria = new Categoria();
                LaCategoria = BD.TraerCategoria(idcate);
                UnaReceta = new Receta(IDReceta, NombreReceta, LaCategoria, Preparacion, TiempoPreparacion, CantidadPlatos, LaDificultad, Foto, NombreFoto, Ingredientes, Cant_Likes, Autor);
                UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
                LasRecetas.Add(UnaReceta);
            }

            Desconectar(Conn);
            return LasRecetas;
        }

        //Metodos Usuarios
        public static void InsertarUsuario(Usuario user)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "InsertarUsuario";
            Consulta.Parameters.Add(new SqlParameter("@Nombre_Usuario", user.Nombre_Usuario));
            Consulta.Parameters.Add(new SqlParameter("@Nombre", user.Nombre));
            Consulta.Parameters.Add(new SqlParameter("@Apellido", user.Apellido));
            Consulta.Parameters.Add(new SqlParameter("@Mail", user.Mail));
            Consulta.Parameters.Add(new SqlParameter("@Contraseña", user.Contraseña));
            Consulta.Parameters.Add(new SqlParameter("@Admin", user.Admin));
            Consulta.Parameters.Add(new SqlParameter("@Nombre_Foto", user.NombreFoto));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }
        public static void ModificarUsuario(Usuario user)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "ModificarUsuario";
            Consulta.Parameters.Add(new SqlParameter("@Nombre_Usuario", user.Nombre_Usuario));
            Consulta.Parameters.Add(new SqlParameter("@Nombre", user.Nombre));
            Consulta.Parameters.Add(new SqlParameter("@Apellido", user.Apellido));
            Consulta.Parameters.Add(new SqlParameter("@Mail", user.Mail));
            Consulta.Parameters.Add(new SqlParameter("@Contraseña", user.Contraseña));
            Consulta.Parameters.Add(new SqlParameter("@Nombre_Foto", user.NombreFoto));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }
        public static void EliminarUsuario(int IDUsuario)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "EliminarUsuario";
            Consulta.Parameters.Add(new SqlParameter("@IDUsuario", IDUsuario));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }
        public static Usuario TraerUsuario(int IDUsuario)
        {
            SqlConnection Conn = Conectar();
            Usuario UnUsuario = new Usuario();
            List<Receta> Favoritos = new List<Receta>();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "TraerUsuario";
            Consulta.Parameters.Add(new SqlParameter("@IDUsuario", IDUsuario));
            SqlDataReader Lector = Consulta.ExecuteReader();

            if (Lector.Read())
            {
                int id = Convert.ToInt32(Lector["IDUsuario"]);
                string Nombre_Usuario = Lector["Nombre_Usuario"].ToString();
                string Nombre = Lector["Nombre"].ToString();
                string Apellido = Lector["Apellido"].ToString();
                string Mail = Lector["Mail"].ToString();
                string Contraseña = Lector["Contraseña"].ToString();
                bool Admin = Convert.ToBoolean(Lector["Admin"]);
                string NombreFoto = Lector["Nombre_Foto"].ToString();
                HttpPostedFileBase Foto = null;
                Favoritos = UnUsuario.TraerFavoritos(IDUsuario);
                UnUsuario = new Usuario(IDUsuario, Nombre_Usuario, Nombre, Apellido, Mail, Contraseña, Admin, Foto, NombreFoto, Favoritos);
            }
            Desconectar(Conn);
            return UnUsuario;
        }
        public static bool ValidarUsuario(Usuario user)
        {
            bool Validacion = false;
            SqlConnection Conn = Conectar();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "ValidarUsuario";
            Consulta.Parameters.Add(new SqlParameter("@Mail", user.Mail));
            Consulta.Parameters.Add(new SqlParameter("@Contraseña", user.Contraseña));
            SqlDataReader Lector = Consulta.ExecuteReader();
            if (Lector.Read())
            {
                user.IDUsuario = Convert.ToInt32(Lector["IDUsuario"]);
                Validacion = true;
            }
            Desconectar(Conn);
            return Validacion;
        }
        public static List<Usuario> ListarUsuarios()
        {
            SqlConnection Conn = Conectar();
            Usuario UnUsuario = new Usuario();
            List<Usuario> ListaUsuarios = new List<Usuario>();
            List<Receta> Favoritos = new List<Receta>();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "ListarRecetas";
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int IDUsuario = Convert.ToInt32(Lector["IDUsuario"]);
                string Nombre_Usuario = Lector["Nombre_Usuario"].ToString();
                string Nombre = Lector["Nombre"].ToString();
                string Apellido = Lector["Apellido"].ToString();
                string Mail = Lector["Mail"].ToString();
                string Contraseña = Lector["Contraseña"].ToString();
                bool Admin = Convert.ToBoolean(Lector["Admin"]);
                string NombreFoto = Lector["Foto"].ToString();
                HttpPostedFileBase Foto = null;
                Favoritos = UnUsuario.TraerFavoritos(IDUsuario);
                UnUsuario = new Usuario(IDUsuario, Nombre_Usuario, Nombre, Apellido, Mail, Contraseña, Admin, Foto, NombreFoto, Favoritos);
                ListaUsuarios.Add(UnUsuario);
            }
            Desconectar(Conn);
            return ListaUsuarios;
        }
        public static int TraerIDUsuario (string Mail, string Contraseña)
        {
            SqlConnection Conn = Conectar();
            int IDUsuario = -1;
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "TraerIDUsuario";
            Consulta.Parameters.Add(new SqlParameter("@Mail", Mail));
            Consulta.Parameters.Add(new SqlParameter("@Contraseña", Contraseña));
            SqlDataReader Lector = Consulta.ExecuteReader();

            if (Lector.Read())
            {
                IDUsuario = Convert.ToInt32(Lector["IDUsuario"]);               
            }
            Desconectar(Conn);
            return IDUsuario;
        }

        //Metodos Ingredientes
        public static void IngresarIngrediente(string NombreIngrediente)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "IngresarIngrediente";
            Consulta.Parameters.Add(new SqlParameter("@NombreIngrediente", NombreIngrediente));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }
        public static bool ComprobarIngrediente(string NombreIngrediente)
        {
            bool Comprobar = false;
            int contador = 0;
            SqlConnection Conn = Conectar();
            Receta UnaReceta = new Receta();
            List<Ingrediente> Ingredientes = new List<Ingrediente>();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "ComprobarIngrediente";
            Consulta.Parameters.Add(new SqlParameter("@NombreIngrediente", NombreIngrediente));
            SqlDataReader Lector = Consulta.ExecuteReader();

            while (Lector.Read())
            {
                string Nombre = Lector["NombreIngrediente"].ToString();
                contador++;
            }

            if (contador > 0)
            {
                Comprobar = true;
            }

            Desconectar(Conn);
            return Comprobar;
        }

        //Metodos RxI
        public static void IngresarRxI(string NombreReceta, string NombreIngrediente, string Cantidad)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "IngresarRxI";
            Consulta.Parameters.Add(new SqlParameter("@NombreReceta", NombreReceta));
            Consulta.Parameters.Add(new SqlParameter("@NombreIngrediente", NombreIngrediente));
            Consulta.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }

        //Metodos Favoritos
        public static void InsertarFavorito(int idUsuario, int idReceta)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "InsertarFavorito";
            Consulta.Parameters.Add(new SqlParameter("@IDUsuario", idUsuario));
            Consulta.Parameters.Add(new SqlParameter("@IDReceta", idReceta));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }
        public static void EliminarFavorito(int idUsuario, int idReceta)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "EliminarFavorito";
            Consulta.Parameters.Add(new SqlParameter("@IDUsuario", idUsuario));
            Consulta.Parameters.Add(new SqlParameter("@IDReceta", idReceta));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }

        //Metodos Categorias
        public static Categoria TraerCategoria(int IdCat)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Categoria cat = new Categoria();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "TraerCategoria";
            Consulta.Parameters.Add(new SqlParameter("@id", IdCat));
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int IdCategoria = Convert.ToInt32(Lector["IDCategoria"]);
                string NomCat = Lector["NomCategoria"].ToString();
                cat = new Categoria(IdCategoria, NomCat);
            }
            Desconectar(Conn);
            return cat;
        }
        public static List<Categoria> ListarCategorias()
        {
            List<Categoria> categ = new List<Categoria>();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "ListarCategorias";
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int id = Convert.ToInt32(Lector["IDCategoria"]);
                string NomCat = Lector["NomCategoria"].ToString();
                Categoria cat = new Categoria(id, NomCat);
                categ.Add(cat);
            }
            Desconectar(Conn);
            return categ;
        }

        //Metodos Dificultad
        public static Dificultad TraerDificultad(int IDReceta)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Dificultad difi = new Dificultad();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "TraerDificultad";
            Consulta.Parameters.Add(new SqlParameter("@IDReceta", IDReceta));
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int Id = Convert.ToInt32(Lector["IDDificultad"]);
                string nom = Lector["NombreDificultad"].ToString();
                difi = new Dificultad(Id, nom);
            }
            Desconectar(Conn);
            return difi;
        }
        public static List<Dificultad> ListarDificultades()
        {
            List<Dificultad> difi = new List<Dificultad>();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "ListarDificultades";
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int id = Convert.ToInt32(Lector["IDDificultad"]);
                string nom = Lector["NombreDificultad"].ToString();
                Dificultad dif = new Dificultad(id, nom);
                difi.Add(dif);
            }
            Desconectar(Conn);
            return difi;

        }

        //Metodos Random
        public static List<Receta> TraerRecetasRandom(List<int> num)
        {
            SqlConnection Conn = Conectar();
            Receta UnaReceta = new Receta();
            List<Ingrediente> Ingredientes = new List<Ingrediente>();
            List<Receta> Listarecetas = new List<Receta>();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "TraerRecetaRandom";
            Consulta.Parameters.Add(new SqlParameter("@NumeroRandom0", num[0]));
            Consulta.Parameters.Add(new SqlParameter("@NumeroRandom1", num[1]));
            Consulta.Parameters.Add(new SqlParameter("@NumeroRandom2", num[2]));
            Consulta.Parameters.Add(new SqlParameter("@NumeroRandom3", num[3]));
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int IDReceta = Convert.ToInt32(Lector["IDReceta"]);
                string NombreReceta = Lector["NombreReceta"].ToString();
                int idcate = Convert.ToInt32(Lector["Categoria"]);
                string Preparacion = Lector["Preparacion"].ToString();
                int TiempoPreparacion = Convert.ToInt32(Lector["TiempoPreparacion"]);
                float CantidadPlatos = Convert.ToInt32(Lector["CantidadPlatos"]);
                int iddifi = Convert.ToInt32(Lector["Dificultad"]);
                string NombreFoto = Lector["Foto"].ToString();
                int Cant_Likes = Convert.ToInt32(Lector["Cant_Likes"]);
                int Autor = Convert.ToInt32(Lector["Autor"]);
                HttpPostedFileBase Foto = null;
                Dificultad LaDificultad = new Dificultad();
                LaDificultad = BD.TraerDificultad(iddifi);
                Categoria LaCategoria = new Categoria();
                LaCategoria = BD.TraerCategoria(idcate);
                UnaReceta = new Receta(IDReceta, NombreReceta, LaCategoria, Preparacion, TiempoPreparacion, CantidadPlatos, LaDificultad, Foto, NombreFoto, Ingredientes, Cant_Likes, Autor);
                UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
                Listarecetas.Add(UnaReceta);
            }
            Desconectar(Conn);
            return Listarecetas;
        }
        public static List<int> GenerarRandoms(int CantRandoms /* Cantidad de Randoms que se quiere generar */, int CantRecetasTotal)
        {
            Random ran = new Random();
            List<int> ListaNumeros = new List<int>();
            int x = 0;
            while (ListaNumeros.Count != CantRandoms)
            {
                int aux = ran.Next(1, CantRecetasTotal);
                if (ListaNumeros.Contains(aux))
                {
                }
                else
                {
                    ListaNumeros.Add(aux);
                    x++;
                }
            }
            return ListaNumeros;
        }
    }
}