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

            foreach (Categoria UnaCategoria in LasCategorias)
            {
                NomCategorias.Add(UnaCategoria.Nom_Categoria);
            }
            foreach (Dificultad UnaDificultad in LasDificultades)
            {
                NomDificultades.Add(UnaDificultad.NombreDificultad);
            }

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
                BD.IngresarReceta(rec);
                return View("RecetaPublicada", rec);
            }
        }
        public ActionResult EliminarReceta(int id)
        {
            BD.EliminarReceta(id);
            return View("Index");
        }
        public ActionResult BuscarXIng()
        {
            Session["ListaIngredientes"] = null;
            return View();
        }
        public ActionResult BusqXIng(string Buscar, string Eliminar)
        {
            ViewBag.IngredientesBuscados = "";
            ViewBag.MisRecetasEncontradas = "";
            ViewBag.CantRecetasEncontradas = 0;

            List<string> Lista;
            if (Session["ListaIngredientes"]==null)
            {
                Lista = new List<string>();
            }
            else
            {
                Lista = (List<string>)Session["ListaIngredientes"];
            }

            if(Buscar != null)
            {
                if (!Lista.Contains(Buscar))
                {
                    Lista.Add(Buscar);
                }
            }

            if(Eliminar != null)
            {
                Lista.Remove(Eliminar);
            }

            Session["ListaIngredientes"] = Lista;
            ViewBag.IngredientesBuscados = Lista;

            List<Receta> LasRecetasEncontradas = new List<Receta>();
            Session["ListaRecetasEncontradas"] = new List<Receta>();

            ViewBag.CantRecetasEncontradas = LasRecetasEncontradas.Count();

            List <Receta> RecetasEncontradas = new List<Receta>();
            List<List<Receta>> TodasLasRecetas = new List<List<Receta>>();
            List<Receta> RecetasAMostrar = new List<Receta>();
            bool Repetido = false;
            int i = 0;
            int Coincidencias = 0;
            
            foreach (string ElIngrediente in Lista)
            {
                RecetasEncontradas = BD.TraerRecetas(ElIngrediente);
                TodasLasRecetas.Add(RecetasEncontradas);
            }

            foreach (List<Receta> ListaRecetas in TodasLasRecetas)
            {
                foreach (Receta UnaReceta in ListaRecetas)
                {
                    Coincidencias = 0;
                    Repetido = false;

                    foreach (Ingrediente UnIngrediente in UnaReceta.Ingredientes)
                    {
                        i = 0;
                        if (Coincidencias != Lista.Count() && Lista.Count() != 0)
                        {
                            do
                            {
                                if (UnIngrediente.NombreIngrediente.ToLower() == Lista[i].ToLower())
                                {
                                    Coincidencias++;
                                }
                                i++;

                            } while (i - 1 != Lista.Count() - 1);
                        }

                        if (Coincidencias == Lista.Count() && Lista.Count() != 0)
                        {
                            foreach (Receta LaReceta in RecetasAMostrar)
                            {
                                if (LaReceta.NombreReceta.ToLower() == UnaReceta.NombreReceta.ToLower())
                                {
                                    Repetido = true;
                                }

                            } //Busqueda de repeticiones en las recetas (Descarte de recetas repetidas)

                            if (Repetido == false)
                            {
                                RecetasAMostrar.Add(UnaReceta);
                                Coincidencias = 0;
                            }
                        }
                    }
                }
            }
            
            if (RecetasAMostrar.Count != 0)
            {
                foreach (Receta UnaReceta in RecetasAMostrar)
                {
                    LasRecetasEncontradas.Add(UnaReceta);
                }
            }

            Session["ListaRecetasEncontradas"] = LasRecetasEncontradas;
            ViewBag.MisRecetasEncontradas = LasRecetasEncontradas;
            ViewBag.CantRecetasEncontradas = LasRecetasEncontradas.Count();

            return View("BuscarXIng");
        }
        public ActionResult Favoritos(int IdRec, int IdUsu)
        {
            BD.InsertarFavorito(IdUsu, IdRec);
            return View("BuscarXIng");
        }
        public ActionResult VaciarLista(List<string> lista)
        {
            lista = null;
            ViewBag.IngredientesBuscados = lista;
            return View("BuscarXIng");
        }
    }
}