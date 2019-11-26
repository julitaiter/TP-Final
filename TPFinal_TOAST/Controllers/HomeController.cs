using System;
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
            List<Categoria> lcat = BD.ListarCategorias();
            List<int> Dificultad = new List<int>(){ 1, 2, 3 };
            ViewBag.lcat = lcat;
            ViewBag.dif = Dificultad;
            return View();
        }

        [HttpPost]
        public ActionResult RecetaSubida()
        {
            return View();
        }
    }
}