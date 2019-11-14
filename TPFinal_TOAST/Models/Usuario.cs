﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TPFinal_TOAST.Models
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre de usuario")]
        public string Nombre_Usuario { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese un apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Ingrese un mail")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Ingrese una contraseña")]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Más de 4 caracteres y menos de 16 ")]
        public string Contraseña { get; set; }

        [Compare(nameof(Contraseña), ErrorMessage ="Las contraseñas no coinciden")]
        public string RepetirContraseña { get; set; }
        public bool Admin { get; set; }
        [Required(ErrorMessage = "Ingrese una foto")]
        public HttpPostedFileBase Foto { get; set; }

        public string NombreFoto { get; set; }
        public List<Receta> _Favoritos { get; set; }


        public Usuario() { }

        public Usuario(int iDUsuario, string nombre_Usuario, string nombre, string apellido, string mail, string contraseña, bool admin, HttpPostedFileBase foto, string nom_foto, List<Receta> favs)
        {
            IDUsuario = iDUsuario;
            Nombre_Usuario = nombre_Usuario;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Contraseña = contraseña;
            Admin = admin;
            NombreFoto = nom_foto;
            Foto = foto;
            _Favoritos = favs;
        }
        public List<Receta> TraerFavoritos()
        {
            List<Receta> Recetas = new List<Receta>();
            SqlConnection Conn = Conectar();

            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "TraerFavoritosxUsuario";
            Consulta.Parameters.Add(new SqlParameter("@IDUsuario", _IDUsuario));
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
                Recetas.Add(UnaReceta);
            }

            Desconectar(Conn);
            return Ingredientes;
        }

    }
}