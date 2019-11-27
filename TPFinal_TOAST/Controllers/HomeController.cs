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
          NumerosRandom = BD.GenerarRandoms(4, NumRecetas);
          ListaRecetas = BD.TraerRecetasRandom(NumerosRandom);
          ViewBag.Receta1 = ListaRecetas[0];
          ViewBag.Receta2 = ListaRecetas[1];
          ViewBag.Receta3 = ListaRecetas[2];
          ViewBag.Receta4 = ListaRecetas[3];
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
            ViewBag.nom = c.Nom_Categoria;
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
        public ActionResult RecetaSubida(Receta rec)
        {
            if (!ModelState.IsValid)
            {
                return View("SubirReceta", rec);
            }
            else
            {
                string NuevaUbicacion = Server.MapPath("~/Content/Fotos/Perfiles/") + rec.Foto.FileName;
                rec.Foto.SaveAs(NuevaUbicacion);
                rec.NombreFoto = rec.Foto.FileName;
                return View("RecetaPublicada", rec);
            }
        }
        public ActionResult EliminarReceta(int id)
        {
            BD.EliminarReceta(id);
            return View("Index");
        }
    }
}