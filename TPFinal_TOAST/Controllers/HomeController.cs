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
          ViewBag.ListaRecetas = ListaRecetas;
          return View();
        }
        public ActionResult ViewReceta(int id)
        {
            Receta rec = BD.TraerReceta(id);
            ViewBag.Usuario = BD.TraerUsuario(rec.Autor);
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
        public ActionResult RecetaSubida(HttpPostedFileBase foto, string titulo, string categoria, string ingredientes, string instrucciones, string dificultad, int tiempo_prep, int cant_platos)
        {
            Receta LaReceta = new Receta();
            LaReceta.Foto = foto;
            LaReceta.NombreReceta = titulo;
            LaReceta.Categoria = BD.TraerIDCategoria(categoria);
            List<string> ingredientes_separados = new List<string>();
            ingredientes_separados = cadena.Split(',');
            foreach (string ElIngrediente in ingredientes_separados)
            {
                BD.IngresarIngrediente(ElIngrediente);
            }
            LaReceta.Ingredientes = ingredientes_separados; //Validar por comas
            LaReceta.Preparacion = instrucciones;
            LaReceta.Dificultad = BD.TraerIDDificultad(dificultad);
            
            LaReceta.TiempoPreparacion = tiempo_prep;
            LaReceta.CantidadPlatos = cant_platos;

            if (LaReceta.Foto != null)
            {
                string NuevaUbicacion = Server.MapPath("~/Content/Fotos/Perfiles/") + LaReceta.Foto.FileName;
                LaReceta.Foto.SaveAs(NuevaUbicacion);
                LaReceta.NombreFoto = LaReceta.Foto.FileName;
                BD.IngresarReceta(LaReceta);
                return View("RecetaPublicada", LaReceta);
            }

            return View("SubirReceta", LaReceta);
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
        public ActionResult Favoritos(int IdRec, int IdUsu, string modo, string view)
        {
            if(modo=="Insertar")
            {
                BD.InsertarFavorito(IdUsu, IdRec);
            }
            else
            {
                BD.EliminarFavorito(IdUsu, IdRec);
            }
            return RedirectToAction(view);
        }
        public ActionResult VaciarLista(List<string> lista)
        {
            lista = null;
            ViewBag.IngredientesBuscados = lista;
            return View("BuscarXIng");
        }
    }
}