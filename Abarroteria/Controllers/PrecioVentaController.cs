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
    public class PrecioVentaController : Controller
    {
        private AbarroteriaEntities db = new AbarroteriaEntities();

        // GET: PrecioVenta
        public ActionResult Index()
        {
            var precioVenta = db.PrecioVenta.Include(p => p.ListaPrecio1).Include(p => p.Productos);
            return View(precioVenta.ToList());
        }

        // GET: PrecioVenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioVenta precioVenta = db.PrecioVenta.Find(id);
            if (precioVenta == null)
            {
                return HttpNotFound();
            }
            return View(precioVenta);
        }

        // GET: PrecioVenta/Create
        public ActionResult Create()
        {
            ViewBag.ListaPrecio = new SelectList(db.ListaPrecios, "ListaPrecioId", "Descripcion");
            ViewBag.ProductoID = new SelectList(db.Productos, "productoId", "descripcion");
            return View();
        }

        // POST: PrecioVenta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrecioVentaID,ProductoID,Precio,FechaDesde,FechaHasta,ListaPrecio")] PrecioVenta precioVenta)
        {
            if (ModelState.IsValid)
            {
                db.PrecioVenta.Add(precioVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListaPrecio = new SelectList(db.ListaPrecios, "ListaPrecioId", "Codigo", precioVenta.ListaPrecio);
            ViewBag.ProductoID = new SelectList(db.Productos, "productoId", "codigo", precioVenta.ProductoID);
            return View(precioVenta);
        }

        // GET: PrecioVenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioVenta precioVenta = db.PrecioVenta.Find(id);
            if (precioVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListaPrecio = new SelectList(db.ListaPrecios, "ListaPrecioId", "Codigo", precioVenta.ListaPrecio);
            ViewBag.ProductoID = new SelectList(db.Productos, "productoId", "codigo", precioVenta.ProductoID);
            return View(precioVenta);
        }

        // POST: PrecioVenta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrecioVentaID,ProductoID,Precio,FechaDesde,FechaHasta,ListaPrecio")] PrecioVenta precioVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precioVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListaPrecio = new SelectList(db.ListaPrecios, "ListaPrecioId", "Codigo", precioVenta.ListaPrecio);
            ViewBag.ProductoID = new SelectList(db.Productos, "productoId", "codigo", precioVenta.ProductoID);
            return View(precioVenta);
        }

        // GET: PrecioVenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioVenta precioVenta = db.PrecioVenta.Find(id);
            if (precioVenta == null)
            {
                return HttpNotFound();
            }
            return View(precioVenta);
        }

        // POST: PrecioVenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrecioVenta precioVenta = db.PrecioVenta.Find(id);
            db.PrecioVenta.Remove(precioVenta);
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
