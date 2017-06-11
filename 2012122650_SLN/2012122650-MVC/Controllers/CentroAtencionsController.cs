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
    public class CentroAtencionsController : Controller
    {
        //private _2012122650DbContext db = new _2012122650DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public CentroAtencionsController()
        {

        }

        // GET: CentroAtencions
        public ActionResult Index()
        {
            //var centrosAtencion = db.CentrosAtencion.Include(c => c.Ubigeo);
            //return View(centrosAtencion.ToList());

            return View(_UnityOfWork.CentroAtencion.GetAll());
        }

        // GET: CentroAtencions/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencion.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Create
        public ActionResult Create()
        {
            //ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId");
            return View();
        }

        // POST: CentroAtencions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CentroAtencionId,NombreCentroAtencion,Direccion,Telefono,UbigeoId")] CentroAtencion centroAtencion)
        {
            if (ModelState.IsValid)
            {
                //db.CentrosAtencion.Add(centroAtencion);
                //db.SaveChanges();

                _UnityOfWork.CentroAtencion.Add(centroAtencion);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }

           //ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", centroAtencion.UbigeoId);
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencion.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", centroAtencion.UbigeoId);
            return View(centroAtencion);
        }

        // POST: CentroAtencions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CentroAtencionId,NombreCentroAtencion,Direccion,Telefono,UbigeoId")] CentroAtencion centroAtencion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(centroAtencion);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }
            //ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", centroAtencion.UbigeoId);
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencion.Get(id);
            {
                return HttpNotFound();
            }
            return View(centroAtencion);
        }

        // POST: CentroAtencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencion.Get(id);
            //db.CentrosAtencion.Remove(centroAtencion);
            //db.SaveChanges();

            _UnityOfWork.CentroAtencion.Delete(centroAtencion);
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
