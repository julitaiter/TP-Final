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
        public ActionResult Index()
        {
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
        [HttpPost]
        public ActionResult Loguear(Usuario User) 
        {
            bool validacion = BD.ValidarUsuario(User);
            if (validacion)
            {
                User = BD.TraerUsuario(User.IDUsuario);
                return View("Index", User);
            }
            else
            {
                return View("Loguear", User);
            }
        }
        public ActionResult RM(string modo, int id)
        {
            Usuario user = BD.TraerUsuario(id);
            ViewBag.modo = modo;
            return View(user);
        }
        [HttpPost]
        public ActionResult RM2(Usuario user, string modo)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.modo = modo;
                return View("RM", user);
            }
            else
            {
                string NuevaUbicacion = Server.MapPath("~/Content/Fotos/") + user.Foto.FileName;
                user.Foto.SaveAs(NuevaUbicacion);
                user.NombreFoto = user.Foto.FileName;
                user.Admin = false;
                if (modo=="Insertar")
                {
                    BD.InsertarUsuario(user);
                }
                else
                {
                    BD.ModificarUsuario(user);
                }
                return View("Index",user);
            }
        }
    }
}