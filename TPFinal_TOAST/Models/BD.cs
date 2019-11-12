using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TPFinal_TOAST.Models
{
    public static class BD
    {
        private static SqlConnection Conectar()
        {
            string strConn = "Server=.;Database=BD - TOAST;Trusted_Connection=True;";
            SqlConnection Conexion = new SqlConnection(strConn);
            Conexion.Open();

            return Conexion;
        }
        private static void Desconectar(SqlConnection Conn)
        {
            Conn.Close();
        }
        public static List<Receta> TraerRecetas(string ElIngrediente)
        {
            List<Receta> LasRecetas = new List<Receta>();
            List<Ingrediente> Ingredientes = new List<Ingrediente>();
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
                int Categoria = Convert.ToInt32(Lector["Categoria"]);
                string Preparacion = Lector["Preparacion"].ToString();
                int TiempoPreparacion = Convert.ToInt32(Lector["TiempoPreparacion"]);
                float CantidadPlatos = Convert.ToInt32(Lector["CantidadPlatos"]);
                float Dificultad = Convert.ToInt32(Lector["Dificultad"]);
                string NombreFoto = Lector["Foto"].ToString();
                HttpPostedFileBase Foto = null;
                Receta UnaReceta = new Receta(IDReceta, NombreReceta, Categoria, Preparacion, TiempoPreparacion, CantidadPlatos, Dificultad, Foto, NombreFoto, Ingredientes);
                UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
                LasRecetas.Add(UnaReceta);
            }

            Desconectar(Conn);
            return LasRecetas;
        }
        public static Receta TraerReceta(string Nombre_Receta)
        {
            SqlConnection Conn = Conectar();
            Receta UnaReceta = new Receta();
            List<Ingrediente> Ingredientes = new List<Ingrediente>();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "TraerInfoReceta";
            Consulta.Parameters.Add(new SqlParameter("@NombreReceta", Nombre_Receta));
            SqlDataReader Lector = Consulta.ExecuteReader();

            while (Lector.Read())
            {
                int IDReceta = Convert.ToInt32(Lector["IDReceta"]);
                string NombreReceta = Lector["NombreReceta"].ToString();
                int Categoria = Convert.ToInt32(Lector["Categoria"]);
                string Preparacion = Lector["Preparacion"].ToString();
                int TiempoPreparacion = Convert.ToInt32(Lector["TiempoPreparacion"]);
                float CantidadPlatos = Convert.ToInt32(Lector["CantidadPlatos"]);
                float Dificultad = Convert.ToInt32(Lector["Dificultad"]);
                string NombreFoto = Lector["Foto"].ToString();
                HttpPostedFileBase Foto = null;
                UnaReceta = new Receta(IDReceta, NombreReceta, Categoria, Preparacion, TiempoPreparacion, CantidadPlatos, Dificultad, Foto, NombreFoto, Ingredientes);
                UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
            }

            Desconectar(Conn);
            return UnaReceta;
        }
        public static void IngresarReceta(string NombreReceta, int Categoria, string Preparacion, int TiempoPreparacion, float CantPlatos, float Dificultad, string Foto)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "IngresarRecetas";
            Consulta.Parameters.Add(new SqlParameter("@NombreReceta", NombreReceta));
            Consulta.Parameters.Add(new SqlParameter("@Categoria", Categoria));
            Consulta.Parameters.Add(new SqlParameter("@Preparacion", Preparacion));
            Consulta.Parameters.Add(new SqlParameter("@TiempoPreparacion", TiempoPreparacion));
            Consulta.Parameters.Add(new SqlParameter("@CantidadPlatos", CantPlatos));
            Consulta.Parameters.Add(new SqlParameter("@Dificultad", Dificultad));
            Consulta.Parameters.Add(new SqlParameter("@Foto", Foto));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }
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
                int Categoria = Convert.ToInt32(Lector["Categoria"]);
                string Preparacion = Lector["Preparacion"].ToString();
                int TiempoPreparacion = Convert.ToInt32(Lector["TiempoPreparacion"]);
                float CantidadPlatos = Convert.ToInt32(Lector["CantidadPlatos"]);
                float Dificultad = Convert.ToInt32(Lector["Dificultad"]);
                string NombreFoto = Lector["Foto"].ToString();
                HttpPostedFileBase Foto = null;
                UnaReceta = new Receta(IDReceta, NombreReceta, Categoria, Preparacion, TiempoPreparacion, CantidadPlatos, Dificultad, Foto, NombreFoto, Ingredientes);
                UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
                ListaDeRecetas.Add(UnaReceta);
            }

            Desconectar(Conn);
            return ListaDeRecetas;
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
        public static List<Receta> FiltrarRecetas(string NombreReceta, int Categoria, int TiempoPreparacion, float Cantidad, float Dificultad)
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
            Consulta.CommandText = "FiltrarRecetas";

            SqlDataReader Lector = Consulta.ExecuteReader();

            while (Lector.Read())
            {
                int IDReceta = Convert.ToInt32(Lector["IDReceta"]);
                string NombreReceta1 = Lector["NombreReceta"].ToString();
                int Categoria1 = Convert.ToInt32(Lector["Categoria"]);
                string Preparacion = Lector["Preparacion"].ToString();
                int TiempoPreparacion1 = Convert.ToInt32(Lector["TiempoPreparacion"]);
                float CantidadPlatos1 = Convert.ToInt32(Lector["CantidadPlatos"]);
                float Dificultad1 = Convert.ToInt32(Lector["Dificultad"]);
                string NombreFoto = Lector["Foto"].ToString();
                HttpPostedFileBase Foto = null;
                UnaReceta = new Receta(IDReceta, NombreReceta1, Categoria1, Preparacion, TiempoPreparacion1, CantidadPlatos1, Dificultad1, Foto, NombreFoto, Ingredientes);
                UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
                ListaDeRecetas.Add(UnaReceta);
            }

            Desconectar(Conn);
            return ListaDeRecetas;
        }
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
                UnUsuario = new Usuario(IDUsuario, Nombre_Usuario, Nombre, Apellido, Mail, Contraseña, Admin, Foto, NombreFoto);
                ListaUsuarios.Add(UnUsuario);
            }
            Desconectar(Conn);
            return ListaUsuarios;
        }
        public static Usuario TraerUsuario(int IDUsuario)
        {
            SqlConnection Conn = Conectar();
            Usuario UnUsuario = new Usuario();
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
                UnUsuario = new Usuario(IDUsuario, Nombre_Usuario, Nombre, Apellido, Mail, Contraseña, Admin, Foto, NombreFoto);
            }
            Desconectar(Conn);
            return UnUsuario;
        }
        public static int CantidadRecetas()
        {
            SqlConnection Conn = Conectar();
            int i = -1;
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "CantidadRecetas";
            SqlDataReader Lector = Consulta.ExecuteReader();
            if(Lector.Read())
            {
               i = Convert.ToInt32(Lector["cant"]);
            }

            return i;
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
        public static List<Receta> TraerRecetasRandom(List<int> num)
        {
            SqlConnection Conn = Conectar();
            Receta UnaReceta = new Receta();
            List<Ingrediente> Ingredientes = new List<Ingrediente>();
            List<Receta> recetas = new List<Receta>();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "TraerRecetaRandom";
            foreach (int n in num)
            {
                Consulta.Parameters.Add(new SqlParameter("@NumeroRandom", n));
                SqlDataReader Lector = Consulta.ExecuteReader();
                while (Lector.Read())
                {
                    int IDReceta = Convert.ToInt32(Lector["IDReceta"]);
                    string NombreReceta = Lector["NombreReceta"].ToString();
                    int Categoria = Convert.ToInt32(Lector["Categoria"]);
                    string Preparacion = Lector["Preparacion"].ToString();
                    int TiempoPreparacion = Convert.ToInt32(Lector["TiempoPreparacion"]);
                    float CantidadPlatos = Convert.ToInt32(Lector["CantidadPlatos"]);
                    float Dificultad = Convert.ToInt32(Lector["Dificultad"]);
                    string NombreFoto = Lector["Foto"].ToString();
                    HttpPostedFileBase Foto = null;
                    UnaReceta = new Receta(IDReceta, NombreReceta, Categoria, Preparacion, TiempoPreparacion, CantidadPlatos, Dificultad, Foto, NombreFoto, Ingredientes);
                    UnaReceta.Ingredientes = UnaReceta.ListarIngredientes();
                    recetas.Add(UnaReceta);
                }
            }
            Desconectar(Conn);
            return recetas;
        }
        public static void ModificarReceta (string NombreReceta, int Categoria, string Preparacion, int TiempoPreparacion, float CantPlatos, float Dificultad, string Foto)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "ModificarRecetas";
            Consulta.Parameters.Add(new SqlParameter("@NombreReceta", NombreReceta));
            Consulta.Parameters.Add(new SqlParameter("@Categoria", Categoria));
            Consulta.Parameters.Add(new SqlParameter("@Preparacion", Preparacion));
            Consulta.Parameters.Add(new SqlParameter("@TiempoPreparacion", TiempoPreparacion));
            Consulta.Parameters.Add(new SqlParameter("@CantidadPlatos", CantPlatos));
            Consulta.Parameters.Add(new SqlParameter("@Dificultad", Dificultad));
            Consulta.Parameters.Add(new SqlParameter("@Foto", Foto));
            Consulta.ExecuteNonQuery();
            Desconectar(Conn);
        }

    }
}