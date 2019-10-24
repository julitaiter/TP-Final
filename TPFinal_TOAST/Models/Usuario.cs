using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFinal_TOAST.Models
{
    public class Usuario
    {
        private int _IDUsuario;
        private string _Nombre_Usuario;
        private string _Nombre;
        private string _Apellido;
        private string _Mail;
        private string _Contraseña;
        private bool _Admin;

        public int IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }
        public string Nombre_Usuario { get => _Nombre_Usuario; set => _Nombre_Usuario = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Mail { get => _Mail; set => _Mail = value; }
        public bool Admin { get => _Admin; set => _Admin = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }

        public Usuario()
        {


        }

        public Usuario(int IDUsuario, string Nombre_Usuario, string Nombre, string Apellido, string Mail, string Contraseña, bool Admin)
        {
            _IDUsuario = IDUsuario;
            _Nombre_Usuario = Nombre_Usuario;
            _Nombre = Nombre;
            _Apellido = Apellido;
            _Mail = Mail;
            _Contraseña = Contraseña;
            _Admin = Admin;
        }
    }
}