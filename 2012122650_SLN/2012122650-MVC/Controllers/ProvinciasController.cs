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
    public class ProvinciasController : Controller
    {
        //private _2012122650DbContext db = new _2012122650DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public ProvinciasController()
        {

        }

        // GET: Provincias
        public ActionResult Index()
        {
            //var provincias = db.Provincias.Include(p => p.Departamento);
            //return View(provincias.ToList());

            return View(_UnityOfWork.Provincia.GetAll());
        }

        // GET: Provincias/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = _UnityOfWork.Provincia.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // GET: Provincias/Create
        public ActionResult Create()
        {
            //ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "departamento");
            return View();
        }

        // POST: Provincias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinciaId,nomProvincia,DepartamentoId")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                //db.Provincias.Add(provincia);
                //db.SaveChanges();

                _UnityOfWork.Provincia.Add(provincia);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }

            //ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "departamento", provincia.DepartamentoId);
            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = _UnityOfWork.Provincia.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            //ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "departamento", provincia.DepartamentoId);
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinciaId,nomProvincia,DepartamentoId")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(provincia).State = EntityState.Modified;
                //db.SaveChanges();

                _UnityOfWork.StateModified(provincia);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }
            //ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "departamento", provincia.DepartamentoId);
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = _UnityOfWork.Provincia.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provincia provincia = _UnityOfWork.Provincia.Get(id);
            //db.Provincias.Remove(provincia);
            //db.SaveChanges();

            _UnityOfWork.Provincia.Delete(provincia);
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
