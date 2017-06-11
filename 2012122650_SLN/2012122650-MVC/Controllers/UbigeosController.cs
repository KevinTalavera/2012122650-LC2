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
    public class UbigeosController : Controller
    {
        //private _2012122650DbContext db = new _2012122650DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public UbigeosController()
        {

        }

        // GET: Ubigeos
        public async Task<ActionResult> Index()
        {
            //var ubigeos = db.Ubigeos.Include(u => u.Distrito);
            //return View(await ubigeos.ToListAsync());

            return View(_UnityOfWork.Ubigeo.GetAll());
        }

        // GET: Ubigeos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = _UnityOfWork.Ubigeo.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // GET: Ubigeos/Create
        public ActionResult Create()
        {
            //ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "nomDistrito");
            return View();
        }

        // POST: Ubigeos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UbigeoId,DistritoId")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                //db.Ubigeos.Add(ubigeo);
                //await db.SaveChangesAsync();

                _UnityOfWork.Ubigeo.Add(ubigeo);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }

            //ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "nomDistrito", ubigeo.DistritoId);
            return View(ubigeo);
        }

        // GET: Ubigeos/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = _UnityOfWork.Ubigeo.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            //ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "nomDistrito", ubigeo.DistritoId);
            return View(ubigeo);
        }

        // POST: Ubigeos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UbigeoId,DistritoId")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(ubigeo).State = EntityState.Modified;
                //await db.SaveChangesAsync();

                _UnityOfWork.StateModified(ubigeo);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }
            //ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "nomDistrito", ubigeo.DistritoId);
            return View(ubigeo);
        }

        // GET: Ubigeos/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = _UnityOfWork.Ubigeo.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // POST: Ubigeos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ubigeo ubigeo = _UnityOfWork.Ubigeo.Get(id);
            //db.Ubigeos.Remove(ubigeo);
            //await db.SaveChangesAsync();

            _UnityOfWork.Ubigeo.Delete(ubigeo);
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
