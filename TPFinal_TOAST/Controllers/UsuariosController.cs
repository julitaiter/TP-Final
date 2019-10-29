using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPFinal_TOAST.Models;

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
            return View("Loguear");
        }

        [HttpPost]
        public ActionResult Loguear(Usuario User)
        {
            if (!ModelState.IsValid)
            {
                return View("Loguear", User);
            }
            else
            {
                bool validacion = BD.ValidarUsuario(User.Mail, User.Contraseña);
                if (validacion)
                {
                    return View("Index");
                }
            }

            return View();
        }
    }
}