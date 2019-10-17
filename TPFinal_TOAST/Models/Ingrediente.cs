using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFinal_TOAST.Models
{
    public class Ingrediente
    {
        private int _IDIngrediente;
        private string _NombreIngrediente;
        private string _Cantidad;
        public int IDIngrediente { get => _IDIngrediente; set => _IDIngrediente = value; }
        public string NombreIngrediente { get => _NombreIngrediente; set => _NombreIngrediente = value; }
        public string Cantidad { get => _Cantidad; set => _Cantidad = value; }

        public Ingrediente()
        {
        }

        public Ingrediente(int IDIngrediente, string NombreIngrediente, string Cantidad)
        {
            _IDIngrediente = IDIngrediente;
            _NombreIngrediente = NombreIngrediente;
            _Cantidad = Cantidad;
        }
    }
}