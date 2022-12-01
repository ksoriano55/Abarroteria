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
    public class InventariosController : Controller
    {
        private AbarroteriaEntities db = new AbarroteriaEntities();

        // GET: Inventarios
        public ActionResult Index()
        {
            var inventario = db.Inventario.Include(i => i.Bodega).Include(i => i.Productos);
            return View(inventario.ToList());
        }

        // GET: Inventarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // GET: Inventarios/Create
        public ActionResult Create()
        {
            ViewBag.BodegaId = new SelectList(db.Bodegas, "BodegaId", "Nombre");
            ViewBag.ProductoId = new SelectList(db.Productos, "productoId", "descripcion");
            return View();
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventarioId,BodegaId,ProductoId,Disponible")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Inventario.Add(inventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BodegaId = new SelectList(db.Bodegas, "BodegaId", "Codigo", inventario.BodegaId);
            ViewBag.ProductoId = new SelectList(db.Productos, "productoId", "codigo", inventario.ProductoId);
            return View(inventario);
        }

        // GET: Inventarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            ViewBag.BodegaId = new SelectList(db.Bodegas, "BodegaId", "Nombre", inventario.BodegaId);
            ViewBag.ProductoId = new SelectList(db.Productos, "productoId", "descripcion", inventario.ProductoId);
            return View(inventario);
        }
        [HttpPost]
        public JsonResult InsertInventario(Inventario Inventario)
        {
            List<Inventario> sessionInventario = new List<Inventario>();

            var list = (List<Inventario>)Session["Inventario"];

            if (list == null)
            {
                sessionInventario.Add(Inventario);
                Session["Inventario"] = sessionInventario;
            }
            else
            {
                list.Add(Inventario);
                Session["Inventario"] = list;
            }
            return Json("Exito", JsonRequestBehavior.AllowGet);
        }
        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventarioId,BodegaId,ProductoId,Disponible")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BodegaId = new SelectList(db.Bodegas, "BodegaId", "Codigo", inventario.BodegaId);
            ViewBag.ProductoId = new SelectList(db.Productos, "productoId", "codigo", inventario.ProductoId);
            return View(inventario);
        }

        // GET: Inventarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventario inventario = db.Inventario.Find(id);
            db.Inventario.Remove(inventario);
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
