using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Abarroteria.DataBase;

namespace Abarroteria.Controllers
{
    public class BodegaController : Controller
    {
        private AbarroteriaEntities db = new AbarroteriaEntities();

        // GET: Bodega
        public ActionResult Index()
        {
            return View(db.Bodegas.ToList());
        }

        // GET: Bodega/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodega bodega = db.Bodegas.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            return View(bodega);
        }

        // GET: Bodega/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bodega/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BodegaId,Codigo,Nombre")] Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                db.Bodegas.Add(bodega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bodega);
        }

        // GET: Bodega/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodega bodega = db.Bodegas.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            return View(bodega);
        }

        // POST: Bodega/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BodegaId,Codigo,Nombre")] Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bodega);
        }

        // GET: Bodega/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodega bodega = db.Bodegas.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            return View(bodega);
        }

        // POST: Bodega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bodega bodega = db.Bodegas.Find(id);
            db.Bodegas.Remove(bodega);
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
