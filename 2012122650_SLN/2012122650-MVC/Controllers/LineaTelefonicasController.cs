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
    public class LineaTelefonicasController : Controller
    {
        //private _2012122650DbContext db = new _2012122650DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public LineaTelefonicasController()
        {

        }

        // GET: LineaTelefonicas
        public ActionResult Index()
        {
            //return View(db.LineasTelefonica.ToList());

            return View(_UnityOfWork.LineaTelefonica.GetAll());
        }

        // GET: LineaTelefonicas/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonica.Get(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LineaTelefonicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LineaTelefonicaId,NumeroLinea,TipoLinea")] LineaTelefonica lineaTelefonica)
        {
            if (ModelState.IsValid)
            {
                //db.LineasTelefonica.Add(lineaTelefonica);
                //db.SaveChanges();

                _UnityOfWork.LineaTelefonica.Add(lineaTelefonica);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }

            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonica.Get(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // POST: LineaTelefonicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LineaTelefonicaId,NumeroLinea,TipoLinea")] LineaTelefonica lineaTelefonica)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(lineaTelefonica).State = EntityState.Modified;
                //db.SaveChanges();

                _UnityOfWork.StateModified(lineaTelefonica);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonica.Get(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // POST: LineaTelefonicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonica.Get(id);
            //db.LineasTelefonica.Remove(lineaTelefonica);
            //db.SaveChanges();

            _UnityOfWork.LineaTelefonica.Delete(lineaTelefonica);
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
