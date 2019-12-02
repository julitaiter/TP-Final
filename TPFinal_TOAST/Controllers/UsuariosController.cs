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
        public ActionResult Index(int id)
        {
            Usuario user = BD.TraerUsuario(id);
            List<Receta> RecXAut = BD.TraerRecetasxAutor(id);
            ViewBag.RecXAut = RecXAut;
            return View(user);
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
                User = BD.TraerUsuario(User.IDUsuario);
                Session["Usuario"] = User;
                return RedirectToAction("Index", new { id = User.IDUsuario });

            }
            else
            {
                return RedirectToAction("Login", User);
            }
        }
        public ActionResult RM(string modo, int id)
        {
            Usuario user = BD.TraerUsuario(id);
            ViewBag.modo = modo;
            return View(user);
        }
        [HttpPost]
        public ActionResult RM2(HttpPostedFileBase Foto, string name, string username, string email, string password, string re_password, string modo)
        {
            Usuario User = new Usuario();

            if (password != re_password)
            {
                return RedirectToAction("RM", User);
            }
            else
            {
                User.Foto = Foto;
                User.Nombre = name;
                User.Nombre_Usuario = username;
                User.Mail = email;
                User.Contraseña = password;

                string NuevaUbicacion = Server.MapPath("~/Content/Fotos/Perfiles/") + User.Foto.FileName;
                User.Foto.SaveAs(NuevaUbicacion);
                User.NombreFoto = User.Foto.FileName;
                User.Admin = false;

                if (modo == "Insertar")
                {
                    BD.InsertarUsuario(User);
                    return RedirectToAction("Index", new { id = User.IDUsuario });
                }

                else
                {
                    BD.ModificarUsuario(User);
                    return RedirectToAction("Index", new { id = User.IDUsuario });
                }
            }

        }
        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            return View("Login");
        }
    }
}