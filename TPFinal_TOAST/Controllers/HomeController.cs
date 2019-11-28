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
        public ActionResult BuscarXIng()
        {
            return View();
        }
        public ActionResult BusqXIng(string Buscar)
        {
            ViewBag.IngredientesBuscados = "";
            List<string> Lista;
            if (Session["ListaIngredientes"]==null)
            {
                Lista = new List<string>();
            }
            else
            {
                Lista = (List<string>)Session["ListaIngredientes"];
            }

            if (!Lista.Contains(Buscar))
            {
                Lista.Add(Buscar);
            } 

            Session["ListaIngredientes"] = Lista;
            ViewBag.IngredientesBuscados = Lista;















            List<Receta> RecetasEncontradas = new List<Receta>();
            List<List<Receta>> TodasLasRecetas = new List<List<Receta>>();
            List<Receta> RecetasAMostrar = new List<Receta>();
            bool Repetido = false;
            int i = 0;
            int Coincidencias = 0;

            //DEBERIA AGREGAR A LA LISTA QUE SE CONECTA CON UL
            
/*            if (ing != "") 
            {
                IngredientesCLST.Add(ing);
            }

            //DEBERIA, EN BASE A LA LISTA DE UL (INGREDIENTES INGRESADOS), BUSCAR LAS RECETAS POR INGREDIENTE EN LA BASE DE DATOS
            
            foreach (string ElIngrediente in IngredientesCLST)
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
                        if (Coincidencias != IngredientesCLST.Count() && IngredientesCLST.Count() != 0)
                        {
                            do
                            {
                                if (UnIngrediente.NombreIngrediente.ToLower() == IngredientesCLST[i].ToLower())
                                {
                                    Coincidencias++;
                                }
                                i++;

                            } while (i - 1 != IngredientesCLST.Count() - 1);
                        }

                        if (Coincidencias == IngredientesCLST.Count() && IngredientesCLST.Count() != 0)
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

            lstRecetasEncontradas.Items.Clear();
            if (RecetasAMostrar.Count != 0)
            {
                foreach (Receta UnaReceta in RecetasAMostrar)
                {
                    lstRecetasEncontradas.Items.Add(UnaReceta.NombreReceta);
                }
            }*/

            return View("BuscarXIng");
        }
    }
}