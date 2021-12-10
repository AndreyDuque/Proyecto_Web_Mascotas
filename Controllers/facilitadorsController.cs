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
    public class facilitadorsController : Controller
    {
        private Adopcion_PGEntities db = new Adopcion_PGEntities();

        // GET: facilitadors
        public ActionResult Index()
        {
            return View(db.facilitador.ToList());
        }

        // GET: facilitadors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facilitador facilitador = db.facilitador.Find(id);
            if (facilitador == null)
            {
                return HttpNotFound();
            }
            return View(facilitador);
        }

        // GET: facilitadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: facilitadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_facilitador,nom_facilitador,cel_facilitador,dir_facilitador,activo")] facilitador facilitador)
        {
            if (ModelState.IsValid)
            {
                db.facilitador.Add(facilitador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facilitador);
        }

        // GET: facilitadors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facilitador facilitador = db.facilitador.Find(id);
            if (facilitador == null)
            {
                return HttpNotFound();
            }
            return View(facilitador);
        }

        // POST: facilitadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_facilitador,nom_facilitador,cel_facilitador,dir_facilitador,activo")] facilitador facilitador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facilitador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facilitador);
        }

        // GET: facilitadors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facilitador facilitador = db.facilitador.Find(id);
            if (facilitador == null)
            {
                return HttpNotFound();
            }
            return View(facilitador);
        }

        // POST: facilitadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            facilitador facilitador = db.facilitador.Find(id);
            db.facilitador.Remove(facilitador);
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
