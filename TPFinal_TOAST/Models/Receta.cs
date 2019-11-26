using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace TPFinal_TOAST.Models
{
    public class Receta
    {
        public int IDReceta { get; set; }
        [Required(ErrorMessage = "Ingrese un titulo de receta")]
        public string NombreReceta { get; set; }
        [Required(ErrorMessage = "Ingrese categoría")]
        public Categoria Categoria { get; set; }
        [Required(ErrorMessage = "Ingrese instrucciones para preparar la receta")]
        public string Preparacion { get; set; }
        [Required(ErrorMessage = "Ingrese tiempo de preparación de receta")]
        public int TiempoPreparacion { get; set; }
        [Required(ErrorMessage = "Ingrese cantidad de platos de receta")]
        public float CantidadPlatos { get; set; }
        [Required(ErrorMessage = "Ingrese dificultad de receta")]
        public Dificultad Dificultad { get; set; }
        [Required(ErrorMessage = "Ingrese ingredientes de receta")]
        public List<Ingrediente> Ingredientes { get; set; }
        [Required(ErrorMessage = "Ingrese foto de receta")]
        public HttpPostedFileBase Foto { get; set; }
        public string NombreFoto { get; set; }
        public int Cant_Likes { get; set; }

        public Receta()
        {
        }

        public Receta(int idReceta, string nombreReceta, Categoria categoria, string preparacion, int tiempoPreparacion, float cantidadPlatos, Dificultad dificultad, HttpPostedFileBase foto, string nom_foto, List<Ingrediente> ingredientes, int likes)
        {
            IDReceta = idReceta;
            NombreReceta = nombreReceta;
            Categoria = categoria;
            Preparacion = preparacion;
            TiempoPreparacion = tiempoPreparacion;
            CantidadPlatos = cantidadPlatos;
            Dificultad = dificultad;
            NombreFoto = nom_foto;
            Foto = foto;
            Ingredientes = ingredientes;
            Cant_Likes = likes;
        }

        public List<Ingrediente> ListarIngredientes()
        {
            List<Ingrediente> Ingredientes = new List<Ingrediente>();
            SqlConnection Conn = BD.Conectar();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "TraerIngredientes";
            Consulta.Parameters.Add(new SqlParameter("@IDReceta", IDReceta));
            SqlDataReader Lector = Consulta.ExecuteReader();

            while (Lector.Read())
            {
                int IDIngrediente = Convert.ToInt32(Lector["IDIngrediente"]);
                string NombreIngrediente = Lector["NombreIngrediente"].ToString();
                string Cantidad = Lector["Cantidad"].ToString();
                Ingrediente UnIngrediente = new Ingrediente(IDIngrediente, NombreIngrediente, Cantidad);
                Ingredientes.Add(UnIngrediente);
            }

            BD.Desconectar(Conn);
            return Ingredientes;
        }
    }
}