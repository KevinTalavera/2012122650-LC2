using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2012122650_ENT.Entities;
using _2012122650_PER;
using _2012122650_ENT.IRepositories;

namespace _2012122650_MVC.Controllers
{
    public class ContratoesController : Controller
    {
        //private _2012122650DbContext db = new _2012122650DbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public ContratoesController()
        {

        }

        // GET: Contratoes
        public ActionResult Index()
        {
            //var contratos = db.Contratos.Include(c => c.Venta);
            //return View(contratos.ToList());

            return View(_UnityOfWork.Contrato.GetAll());
        }

        // GET: Contratoes/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = _UnityOfWork.Contrato.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratoes/Create
        public ActionResult Create()
        {
            //ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId");
            return View();
        }

        // POST: Contratoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContratoId,FechaContrato,VentaId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                //db.Contratos.Add(contrato);
                //db.SaveChanges();

                _UnityOfWork.Contrato.Add(contrato);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }

            //ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", contrato.VentaId);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = _UnityOfWork.Contrato.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            //ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", contrato.VentaId);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContratoId,FechaContrato,VentaId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(contrato).State = EntityState.Modified;
                //db.SaveChanges();

                _UnityOfWork.StateModified(contrato);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }
            //ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", contrato.VentaId);
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = _UnityOfWork.Contrato.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = _UnityOfWork.Contrato.Get(id);
            //db.Contratos.Remove(contrato);
            //db.SaveChanges();

            _UnityOfWork.Contrato.Delete(contrato);
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
