using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TPFinal_TOAST.Models
{
    public class Receta
    {
        private int _IDReceta;
        private string _NombreReceta;
        private int _Categoria;
        private string _Preparacion;
        private int _TiempoPreparacion;
        private float _CantidadPlatos;
        private float _Dificultad;
        private HttpPostedFileBase _Foto;
        private string _NombreFoto;
        private List<Ingrediente> _Ingredientes;

        public int IDReceta { get => _IDReceta; set => _IDReceta = value; }
        public string NombreReceta { get => _NombreReceta; set => _NombreReceta = value; }
        public int Categoria { get => _Categoria; set => _Categoria = value; }
        public string Preparacion { get => _Preparacion; set => _Preparacion = value; }
        public int TiempoPreparacion { get => _TiempoPreparacion; set => _TiempoPreparacion = value; }
        public float CantidadPlatos { get => _CantidadPlatos; set => _CantidadPlatos = value; }
        public float Dificultad { get => _Dificultad; set => _Dificultad = value; }
        public List<Ingrediente> Ingredientes { get => _Ingredientes; set => _Ingredientes = value; }
        public HttpPostedFileBase Foto { get => _Foto; set => _Foto = value; }
        public string NombreFoto { get => _NombreFoto; set => _NombreFoto = value; }

        public Receta()
        {
        }

        public Receta(int IDReceta, string NombreReceta, int Categoria, string Preparacion, int TiempoPreparacion, float CantidadPlatos, float Dificultad, HttpPostedFileBase foto, string nom_foto, List<Ingrediente> Ingredientes)
        {
            _IDReceta = IDReceta;
            _NombreReceta = NombreReceta;
            _Categoria = Categoria;
            _Preparacion = Preparacion;
            _TiempoPreparacion = TiempoPreparacion;
            _CantidadPlatos = CantidadPlatos;
            _Dificultad = Dificultad;
            _NombreFoto = nom_foto;
            _Foto = foto;
            _Ingredientes = Ingredientes;
        }

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

        public List<Ingrediente> ListarIngredientes()
        {
            List<Ingrediente> Ingredientes = new List<Ingrediente>();
            SqlConnection Conn = Conectar();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "TraerIngredientes";
            Consulta.Parameters.Add(new SqlParameter("@IDReceta", _IDReceta));
            SqlDataReader Lector = Consulta.ExecuteReader();

            while (Lector.Read())
            {
                int IDIngrediente = Convert.ToInt32(Lector["IDIngrediente"]);
                string NombreIngrediente = Lector["NombreIngrediente"].ToString();
                string Cantidad = Lector["Cantidad"].ToString();
                Ingrediente UnIngrediente = new Ingrediente(IDIngrediente, NombreIngrediente, Cantidad);
                Ingredientes.Add(UnIngrediente);
            }

            Desconectar(Conn);
            return Ingredientes;
        }
    }
}