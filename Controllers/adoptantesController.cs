using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class adoptantesController : Controller
    {
        private Adopcion_PGEntities db = new Adopcion_PGEntities();

        // GET: adoptantes
        public ActionResult Index()
        {
            return View(db.adoptante.ToList());
        }

        // GET: adoptantes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adoptante adoptante = db.adoptante.Find(id);
            if (adoptante == null)
            {
                return HttpNotFound();
            }
            return View(adoptante);
        }

        // GET: adoptantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: adoptantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_adoptante,nom_adoptante,cel_adoptante,dir_adoptante,ingresos_mensuales,activo")] adoptante adoptante)
        {
            if (ModelState.IsValid)
            {
                db.adoptante.Add(adoptante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adoptante);
        }

        // GET: adoptantes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adoptante adoptante = db.adoptante.Find(id);
            if (adoptante == null)
            {
                return HttpNotFound();
            }
            return View(adoptante);
        }

        // POST: adoptantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_adoptante,nom_adoptante,cel_adoptante,dir_adoptante,ingresos_mensuales,activo")] adoptante adoptante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adoptante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adoptante);
        }

        // GET: adoptantes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adoptante adoptante = db.adoptante.Find(id);
            if (adoptante == null)
            {
                return HttpNotFound();
            }
            return View(adoptante);
        }

        // POST: adoptantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            adoptante adoptante = db.adoptante.Find(id);
            db.adoptante.Remove(adoptante);
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
