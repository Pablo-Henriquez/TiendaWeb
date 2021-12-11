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
    public class PlataformasController : Controller
    {
        private TiendaJuegosEntities db = new TiendaJuegosEntities();

        // GET: Plataformas
        public ActionResult Index()
        {
            return View(db.Plataforma.ToList());
        }

        // GET: Plataformas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plataforma plataforma = db.Plataforma.Find(id);
            if (plataforma == null)
            {
                return HttpNotFound();
            }
            return View(plataforma);
        }

        // GET: Plataformas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plataformas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPlataforma,Nombre")] Plataforma plataforma)
        {
            if (ModelState.IsValid)
            {
                db.Plataforma.Add(plataforma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plataforma);
        }

        // GET: Plataformas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plataforma plataforma = db.Plataforma.Find(id);
            if (plataforma == null)
            {
                return HttpNotFound();
            }
            return View(plataforma);
        }

        // POST: Plataformas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPlataforma,Nombre")] Plataforma plataforma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plataforma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plataforma);
        }

        // GET: Plataformas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plataforma plataforma = db.Plataforma.Find(id);
            if (plataforma == null)
            {
                return HttpNotFound();
            }
            return View(plataforma);
        }

        // POST: Plataformas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plataforma plataforma = db.Plataforma.Find(id);
            db.Plataforma.Remove(plataforma);
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
