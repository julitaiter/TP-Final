﻿using System;
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
        public ActionResult Index(Usuario user)
        {
            return View(user);
        }
        public ActionResult ListarUsuarios()
        {
            return View();
        }
        public ActionResult Login() 
        {
            return View(); //CORREGIR
        }
        [HttpPost]
        public ActionResult LoginOK(Usuario User) 
        {
            bool validacion = BD.ValidarUsuario(User);
            if (validacion)
            {
                User = BD.TraerUsuario(User.IDUsuario);
                return RedirectToAction("Index", User); //CORREGIR
            }
            else
            {
                return RedirectToAction("Login", User); //CORREGIR
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
                string NuevaUbicacion = Server.MapPath("~/Content/Fotos/Perfiles/") + user.Foto.FileName;
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