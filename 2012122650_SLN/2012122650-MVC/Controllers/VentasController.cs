using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2012122650_ENT.Entities;
using _2012122650_PER;
using _2012122650_ENT.IRepositories;

namespace _2012122650_MVC.Controllers
{
    public class VentasController : Controller
    {
        //private _2012122650DbContext db = new _2012122650DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public VentasController()
        {

        }

        // GET: Ventas
        public async Task<ActionResult> Index()
        {
            //var ventas = db.Ventas.Include(v => v.Evaluacion);
            //return View(await ventas.ToListAsync());

            return View(_UnityOfWork.Venta.GetAll());
        }

        // GET: Ventas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = _UnityOfWork.Venta.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            //ViewBag.EvaluacionId = new SelectList(db.Evaluaciones, "EvaluacionId", "EvaluacionId");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VentaId,Precio,TipoPago,EvaluacionId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                //db.Ventas.Add(venta);
                //await db.SaveChangesAsync();

                _UnityOfWork.Venta.Add(venta);
                _UnityOfWork.SaveChange();
                return RedirectToAction("Index");
            }

            //ViewBag.EvaluacionId = new SelectList(db.Evaluaciones, "EvaluacionId", "EvaluacionId", venta.EvaluacionId);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = _UnityOfWork.Venta.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            //ViewBag.EvaluacionId = new SelectList(db.Evaluaciones, "EvaluacionId", "EvaluacionId", venta.EvaluacionId);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VentaId,Precio,TipoPago,EvaluacionId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(venta).State = EntityState.Modified;
                //await db.SaveChangesAsync();

                _UnityOfWork.StateModified(venta);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }
            //ViewBag.EvaluacionId = new SelectList(db.Evaluaciones, "EvaluacionId", "EvaluacionId", venta.EvaluacionId);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = _UnityOfWork.Venta.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Venta venta = _UnityOfWork.Venta.Get(id);
            //db.Ventas.Remove(venta);
            //await db.SaveChangesAsync();

            _UnityOfWork.Venta.Delete(venta);
            _UnityOfWork.SaveChange();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
