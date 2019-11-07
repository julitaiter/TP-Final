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
          foreach (int Numero in NumerosRandom)
            {
                UnaReceta = BD.TraerRecetaRandom(Numero);
                ListaRecetas.Add(UnaReceta);
            }
          
          ViewBag.recetas = ListaRecetas; 
          return View();
        }
    }
}