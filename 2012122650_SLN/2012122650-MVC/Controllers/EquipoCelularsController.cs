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
    public class EquipoCelularsController : Controller
    {
        //private _2012122650DbContext db = new _2012122650DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public EquipoCelularsController()
        {

        }

        // GET: EquipoCelulars
        public ActionResult Index()
        {
            //return View(db.EquiposCelular.ToList());

            return View(_UnityOfWork.EquipoCelular.GetAll());
        }

        // GET: EquipoCelulars/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelular.Get(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipoCelulars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipoCelularId,Modelo")] EquipoCelular equipoCelular)
        {
            if (ModelState.IsValid)
            {
                //db.EquiposCelular.Add(equipoCelular);
                //db.SaveChanges();

                _UnityOfWork.EquipoCelular.Add(equipoCelular);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }

            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelular.Get(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoCelular);
        }

        // POST: EquipoCelulars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipoCelularId,Modelo")] EquipoCelular equipoCelular)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(equipoCelular).State = EntityState.Modified;
                //db.SaveChanges();

                _UnityOfWork.StateModified(equipoCelular);
                _UnityOfWork.SaveChange();


                return RedirectToAction("Index");
            }
            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelular.Get(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoCelular);
        }

        // POST: EquipoCelulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelular.Get(id);
            //db.EquiposCelular.Remove(equipoCelular);
            //db.SaveChanges();

            _UnityOfWork.EquipoCelular.Delete(equipoCelular);
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
