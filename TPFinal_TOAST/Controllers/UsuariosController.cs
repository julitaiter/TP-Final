using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPFinal_TOAST.Models;
using System.IO;

namespace TPFinal_TOAST.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult MiPerfil(int id)
        {
            Usuario user = BD.TraerUsuario(id);
            List<Receta> RecXAut = BD.TraerRecetasxAutor(id);
            ViewBag.Usuario = user;
            ViewBag.RecXAut = RecXAut;
            return View();
        }
        public ActionResult ListarUsuarios()
        {
            return View();
        }
        public ActionResult Login() 
        {
            return View();
        }
        public ActionResult LoginOK(string email, string pass) 
        {
            Usuario User = new Usuario();
            User.Mail = email;
            User.Contraseña = pass;
            bool validacion = BD.ValidarUsuario(User);
            if (validacion)
            {
                int IDUsuario = BD.TraerIDUsuario(User.Mail, User.Contraseña);
                User = BD.TraerUsuario(IDUsuario);
                Session["Usuario"] = User;
                return RedirectToAction("MiPerfil", new { id = User.IDUsuario });

            }
            else
            {
                return RedirectToAction("Login", User);
            }
        }
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrado(HttpPostedFileBase Foto, string nombre, string apellido, string username, string email, string contraseña, string re_contraseña)
        {
            Usuario User = new Usuario();
            User.Foto = Foto;
            User.Nombre = nombre;
            User.Apellido = apellido;
            User.Nombre_Usuario = username;
            User.Mail = email;
            User.Contraseña = contraseña;

            if (contraseña != re_contraseña)
            {
                return RedirectToAction("Registrar", User);
            }
            else
            {
                string NuevaUbicacion = Server.MapPath("~/Content/Fotos/Perfiles/") + User.Foto.FileName;
                User.Foto.SaveAs(NuevaUbicacion);
                User.NombreFoto = User.Foto.FileName;
                User.Admin = false;

                BD.InsertarUsuario(User);
                User.IDUsuario = BD.TraerIDUsuario(User.Mail, User.Contraseña);
                Session["Usuario"] = User;
                return RedirectToAction("MiPerfil", new { id = User.IDUsuario });
            }
        }
        public ActionResult Modificar()
        {
            ViewBag.Usuario = Session["Usuario"];
            return View();
        }
        public ActionResult Modificado(HttpPostedFileBase Foto, string nombre, string apellido, string username, string email, string contraseña, string re_contraseña)
        {
            Usuario User = new Usuario();
            User.Foto = Foto;
            User.Nombre = nombre;
            User.Apellido = apellido;
            User.Nombre_Usuario = username;
            User.Mail = email;
            User.Contraseña = contraseña;

            string NuevaUbicacion = Server.MapPath("~/Content/Fotos/Perfiles/") + User.Foto.FileName;
            User.Foto.SaveAs(NuevaUbicacion);
            User.NombreFoto = User.Foto.FileName;
            User.Admin = false;

            BD.ModificarUsuario(User);
            User.IDUsuario = BD.TraerIDUsuario(User.Mail, User.Contraseña);
            return RedirectToAction("MiPerfil", new { id = User.IDUsuario });
        }
        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            return View("Login");
        }
    }
}