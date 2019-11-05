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
          int numre;
          List<int> ids = new List<int>();
          List<Receta> ListaRecetas = new List<Receta>();
          numre = BD.Numrecetas();
          ids = BD.random(numre);
          ListaRecetas = BD.TraerRecetasRandom(ids);
          ViewBag.recetas = ListaRecetas; 
          return View();
        }
    }
}