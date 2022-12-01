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
    public class FacturasController : Controller
    {
        private AbarroteriaEntities db = new AbarroteriaEntities();

        // GET: Facturas
        public ActionResult Index()
        {
            return View(db.Facturas.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            var clienteList = db.Clientes.Select(x => new
            {
                ClienteID = x.ClienteID,
                Nombre = x.RTN + " - " + x.Nombre
            });

            ViewBag.ClienteId = new SelectList(clienteList, "ClienteID", "Nombre");
            ViewBag.ProductoId = new SelectList(db.Productos, "ProductoID", "Descripcion");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaID,CodigoFactura,ClienteId,TipoFactura,FechaFactura,FechaVencimiento,ValorFactura,SaldoPendiente")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacturaID,CodigoFactura,ClienteId,TipoFactura,FechaFactura,FechaVencimiento,ValorFactura,SaldoPendiente")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            db.Facturas.Remove(factura);
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
