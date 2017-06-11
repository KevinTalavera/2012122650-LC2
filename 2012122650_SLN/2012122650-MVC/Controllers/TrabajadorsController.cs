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
    public class TrabajadorsController : Controller
    {
        //private _2012122650DbContext db = new _2012122650DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public TrabajadorsController()
        {

        }

        // GET: Trabajadors
        public async Task<ActionResult> Index()
        {
            //return View(await db.Trabajadores.ToListAsync());

            return View(_UnityOfWork.Trabajador.GetAll());
        }

        // GET: Trabajadors/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = _UnityOfWork.Trabajador.Get(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: Trabajadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trabajadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TrabajadorId,NombreTrabajador,TipoTrabajador")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                //db.Trabajadores.Add(trabajador);
                //await db.SaveChangesAsync();

                _UnityOfWork.Trabajador.Add(trabajador);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }

            return View(trabajador);
        }

        // GET: Trabajadors/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = _UnityOfWork.Trabajador.Get(id);
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TrabajadorId,NombreTrabajador,TipoTrabajador")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(trabajador).State = EntityState.Modified;
                //await db.SaveChangesAsync();

                _UnityOfWork.StateModified(trabajador);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }
            return View(trabajador);
        }

        // GET: Trabajadors/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = _UnityOfWork.Trabajador.Get(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trabajador trabajador = _UnityOfWork.Trabajador.Get(id);
            //db.Trabajadores.Remove(trabajador);
            //await db.SaveChangesAsync();

            _UnityOfWork.Trabajador.Delete(trabajador);
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
