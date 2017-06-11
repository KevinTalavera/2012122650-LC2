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
    public class DistritoesController : Controller
    {
        //private _2012122650DbContext db = new _2012122650DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public DistritoesController()
        {

        }

        // GET: Distritoes
        public ActionResult Index()
        {
            //var distritos = db.Distritos.Include(d => d.Provincia);
            //return View(distritos.ToList());

            return View(_UnityOfWork.Distrito.GetAll());
        }

        // GET: Distritoes/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = _UnityOfWork.Distrito.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // GET: Distritoes/Create
        public ActionResult Create()
        {
            //ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "nomProvincia");
            return View();
        }

        // POST: Distritoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistritoId,nomDistrito,ProvinciaId")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                //db.Distritos.Add(distrito);
                //db.SaveChanges();

                _UnityOfWork.Distrito.Add(distrito);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }

            //ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "nomProvincia", distrito.ProvinciaId);
            return View(distrito);
        }

        // GET: Distritoes/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = _UnityOfWork.Distrito.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "nomProvincia", distrito.ProvinciaId);
            return View(distrito);
        }

        // POST: Distritoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistritoId,nomDistrito,ProvinciaId")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(distrito).State = EntityState.Modified;
                //db.SaveChanges();

                _UnityOfWork.StateModified(distrito);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }
            //ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "nomProvincia", distrito.ProvinciaId);
            return View(distrito);
        }

        // GET: Distritoes/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = _UnityOfWork.Distrito.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distrito distrito = _UnityOfWork.Distrito.Get(id);
            //db.Distritos.Remove(distrito);
            //db.SaveChanges();

            _UnityOfWork.Distrito.Delete(distrito);
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
