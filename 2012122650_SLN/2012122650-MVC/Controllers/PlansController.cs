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
    public class PlansController : Controller
    {
        //private _2012122650DbContext db = new _2012122650DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public PlansController()
        {

        }

        // GET: Plans
        public ActionResult Index()
        {
            //return View(db.Planes.ToList());
            return View(_UnityOfWork.Plan.GetAll());
        }

        // GET: Plans/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _UnityOfWork.Plan.Get(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plans/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanId,NombrePlan,TipoPlan")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                //db.Planes.Add(plan);
                //db.SaveChanges();

                _UnityOfWork.Plan.Add(plan);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }

            return View(plan);
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _UnityOfWork.Plan.Get(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanId,NombrePlan,TipoPlan")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(plan).State = EntityState.Modified;
                //db.SaveChanges();

                _UnityOfWork.StateModified(plan);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }
            return View(plan);
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _UnityOfWork.Plan.Get(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = _UnityOfWork.Plan.Get(id);
            //db.Planes.Remove(plan);
            //db.SaveChanges();

            _UnityOfWork.Plan.Delete(plan);
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
