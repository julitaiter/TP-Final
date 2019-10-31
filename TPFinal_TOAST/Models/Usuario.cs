using System;
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
        public byte[] Foto { get; set; }

        public Usuario() { }

        public Usuario(int iDUsuario, string nombre_Usuario, string nombre, string apellido, string mail, string contraseña, bool admin, byte[] foto)
        {
            IDUsuario = iDUsuario;
            Nombre_Usuario = nombre_Usuario;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Contraseña = contraseña;
            Admin = admin;
            Foto = foto;
        }
    }
}