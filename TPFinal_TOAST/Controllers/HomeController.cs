﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPFinal_TOAST.Models;

namespace TPFinal_TOAST.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          int NumRecetas;
          List<int> NumerosRandom = new List<int>();
          Receta UnaReceta = new Receta();
          List<Receta> ListaRecetas = new List<Receta>();
          NumRecetas = BD.CantidadRecetas();
          NumerosRandom = BD.GenerarRandoms(3, NumRecetas);
          ListaRecetas = BD.TraerRecetasRandom(NumerosRandom);
          ViewBag.ListaRecetas = ListaRecetas;
          return View();
        }
       
        public ActionResult ViewReceta(int id)
        {
            Receta rec = BD.TraerReceta(id);
            return View(rec);
        }

        public ActionResult Categorias()
        {
            List<Categoria> LisCat = BD.ListarCategorias();
            ViewBag.List = LisCat;
            return View();
        }

        public ActionResult RecetaCategoria(int IdCat, string Nom)
        {
            Categoria c = BD.TraerCategoria(IdCat);
            List<Receta> rec = BD.TraerRecetasxCat(c.IdCategoria);
            ViewBag.recxcat = rec;
            ViewBag.nom = Nom;
            return View();
        }

        public ActionResult SubirReceta()
        {
            List<Categoria> LasCategorias = BD.ListarCategorias();
            List<Dificultad> LasDificultades = BD.ListarDificultades();
            List<string> NomCategorias = new List<string>();
            List<string> NomDificultades = new List<string>();
            foreach(Categoria UnaCategoria in LasCategorias)
            {
                NomCategorias.Add(UnaCategoria.Nom_Categoria);
            }
            foreach (Dificultad UnaDificultad in LasDificultades)
            {
                NomDificultades.Add(UnaDificultad.NombreDificultad);
            }
            /* Paso solo un viewbag con string y no con categorias ni dificultades porque habria que agregar
             mas de un model a la view, cosa que no es posible */

            ViewBag.Categorias = NomCategorias;
            ViewBag.Dificultades = NomDificultades;
            return View();
        }

        [HttpPost]
        public ActionResult RecetaSubida()
        {
            return View();
        }
    }
}