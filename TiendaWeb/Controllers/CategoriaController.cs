using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaWeb.Models;

namespace TiendaWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private TiendaJuegosEntities db = new TiendaJuegosEntities();
        // GET: Categoria
        public ActionResult Index()
        {
            var listaCat = db.Categoria.ToList();
            return View(listaCat);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Categoria cat)
        {
            db.Categoria.Add(cat);
            db.SaveChanges();

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var categorias = db.Categoria.Find(id);
                if (categorias != null)
                {
                    return View(categorias);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Categoria cat)
        {
            db.Entry(cat).State = EntityState.Modified; //Modifica los registros
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var categorias = db.Categoria.Find(id);
                if (categorias != null)
                {
                    return View(categorias);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(Categoria cat)
        {
            var c = db.Categoria.Find(cat.IdCategoria);

            db.Categoria.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}