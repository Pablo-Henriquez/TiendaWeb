using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaWeb.Models;

namespace TiendaWeb.Controllers
{
    public class JuegosController : Controller
    {
        private TiendaJuegosEntities db = new TiendaJuegosEntities();

        // GET: Juegos
        public ActionResult Index()
        {
            var juego = db.Juego.Include(j => j.Categoria).Include(j => j.Compania).Include(j => j.Plataforma);
            return View(juego.ToList());
        }

        // GET: Juegos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // GET: Juegos/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categoria.OrderBy(x=>x.Nombre), "IdCategoria", "Nombre");
            ViewBag.IdCompania = new SelectList(db.Compania.OrderBy(x => x.Nombre), "IdCompania", "Nombre");
            ViewBag.Idplataforma = new SelectList(db.Plataforma.OrderBy(x => x.Nombre), "IdPlataforma", "Nombre");
            return View();
        }

        // POST: Juegos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdJuego,Codigo,Nombre,Precio,Descripcion,IdCompania,IdCategoria,Idplataforma")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                db.Juego.Add(juego);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nombre", juego.IdCategoria);
            ViewBag.IdCompania = new SelectList(db.Compania, "IdCompania", "Nombre", juego.IdCompania);
            ViewBag.Idplataforma = new SelectList(db.Plataforma, "IdPlataforma", "Nombre", juego.Idplataforma);
            return View(juego);
        }

        // GET: Juegos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nombre", juego.IdCategoria);
            ViewBag.IdCompania = new SelectList(db.Compania, "IdCompania", "Nombre", juego.IdCompania);
            ViewBag.Idplataforma = new SelectList(db.Plataforma, "IdPlataforma", "Nombre", juego.Idplataforma);
            return View(juego);
        }

        // POST: Juegos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdJuego,Codigo,Nombre,Precio,Descripcion,IdCompania,IdCategoria,Idplataforma")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Nombre", juego.IdCategoria);
            ViewBag.IdCompania = new SelectList(db.Compania, "IdCompania", "Nombre", juego.IdCompania);
            ViewBag.Idplataforma = new SelectList(db.Plataforma, "IdPlataforma", "Nombre", juego.Idplataforma);
            return View(juego);
        }

        // GET: Juegos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // POST: Juegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Juego juego = db.Juego.Find(id);
            db.Juego.Remove(juego);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
