using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFinal_TOAST.Models
{
    public class Dificultad
    {
        public int IDDificultad;
        public string NombreDificultad;

        public Dificultad()
        {
        }
        public Dificultad(int id, string nom)
        {
            IDDificultad = id;
            NombreDificultad = nom;
        }
    }
}