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
    public class SeguimientoesController : Controller
    {
        private Adopcion_PGEntities db = new Adopcion_PGEntities();

        // GET: Seguimientoes
        public ActionResult Index()
        {
            return View(db.Seguimiento.ToList());
        }

        // GET: Seguimientoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguimiento seguimiento = db.Seguimiento.Find(id);
            if (seguimiento == null)
            {
                return HttpNotFound();
            }
            return View(seguimiento);
        }

        // GET: Seguimientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seguimientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_seguimiento,fecha,id_facilitador,id_mascota,id_adoptante,estado_mascota,observaciones,activo")] Seguimiento seguimiento)
        {
            if (ModelState.IsValid)
            {
                db.Seguimiento.Add(seguimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seguimiento);
        }

        // GET: Seguimientoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguimiento seguimiento = db.Seguimiento.Find(id);
            if (seguimiento == null)
            {
                return HttpNotFound();
            }
            return View(seguimiento);
        }

        // POST: Seguimientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_seguimiento,fecha,id_facilitador,id_mascota,id_adoptante,estado_mascota,observaciones,activo")] Seguimiento seguimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seguimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seguimiento);
        }

        // GET: Seguimientoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguimiento seguimiento = db.Seguimiento.Find(id);
            if (seguimiento == null)
            {
                return HttpNotFound();
            }
            return View(seguimiento);
        }

        // POST: Seguimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Seguimiento seguimiento = db.Seguimiento.Find(id);
            db.Seguimiento.Remove(seguimiento);
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
