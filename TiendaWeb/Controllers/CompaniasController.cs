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
    public class CompaniasController : Controller
    {
        private TiendaJuegosEntities db = new TiendaJuegosEntities();

        // GET: Companias
        public ActionResult Index()
        {
            return View(db.Compania.ToList());
        }

        // GET: Companias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compania compania = db.Compania.Find(id);
            if (compania == null)
            {
                return HttpNotFound();
            }
            return View(compania);
        }

        // GET: Companias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCompania,Nombre")] Compania compania)
        {
            if (ModelState.IsValid)
            {
                db.Compania.Add(compania);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compania);
        }

        // GET: Companias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compania compania = db.Compania.Find(id);
            if (compania == null)
            {
                return HttpNotFound();
            }
            return View(compania);
        }

        // POST: Companias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCompania,Nombre")] Compania compania)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compania).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compania);
        }

        // GET: Companias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compania compania = db.Compania.Find(id);
            if (compania == null)
            {
                return HttpNotFound();
            }
            return View(compania);
        }

        // POST: Companias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compania compania = db.Compania.Find(id);
            db.Compania.Remove(compania);
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
