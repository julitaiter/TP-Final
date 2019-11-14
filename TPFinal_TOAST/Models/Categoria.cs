using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFinal_TOAST.Models
{
    public class Categoria
    {
        public int IdCategoria;
        public string Nom_Categoria;

        public Categoria()
        {
        }
        public Categoria(int id, string nom)
        {
            IdCategoria = id;
            Nom_Categoria = nom;
        }
    }
}