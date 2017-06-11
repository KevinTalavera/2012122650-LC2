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
    public class EvaluacionsController : Controller
    {
        //private _2012122650DbContext db = new _2012122650DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public EvaluacionsController()
        {

        }

        // GET: Evaluacions
        public ActionResult Index()
        {
            //var evaluaciones = db.Evaluaciones.Include(e => e.CentroAtencion).Include(e => e.Cliente).Include(e => e.EquipoCelular).Include(e => e.LineaTelefonica).Include(e => e.Plan).Include(e => e.Trabajador);
            //return View(evaluaciones.ToList());

            return View(_UnityOfWork.Evaluacion.GetAll());
        }

        // GET: Evaluacions/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = _UnityOfWork.Evaluacion.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Create
        public ActionResult Create()
        {
            //ViewBag.CentroAtencionId = new SelectList(db.CentrosAtencion, "CentroAtencionId", "NombreCentroAtencion");
            //ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre");
            //ViewBag.EquipoCelularId = new SelectList(db.EquiposCelular, "EquipoCelularId", "Modelo");
            //ViewBag.LineaTelefonicaId = new SelectList(db.LineasTelefonica, "LineaTelefonicaId", "LineaTelefonicaId");
            //ViewBag.PlanId = new SelectList(db.Planes, "PlanId", "NombrePlan");
            //ViewBag.TrabajadorId = new SelectList(db.Trabajadores, "TrabajadorId", "NombreTrabajador");
            return View();
        }

        // POST: Evaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvaluacionId,TrabajadorId,EstadoEvaluacion,TipoEvaluacion,ClienteId,PlanId,CentroAtencionId,LineaTelefonicaId,EquipoCelularId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                //db.Evaluaciones.Add(evaluacion);
                //db.SaveChanges();

                _UnityOfWork.Evaluacion.Add(evaluacion);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }

            //ViewBag.CentroAtencionId = new SelectList(db.CentrosAtencion, "CentroAtencionId", "NombreCentroAtencion", evaluacion.CentroAtencionId);
            //ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", evaluacion.ClienteId);
            //ViewBag.EquipoCelularId = new SelectList(db.EquiposCelular, "EquipoCelularId", "Modelo", evaluacion.EquipoCelularId);
            //ViewBag.LineaTelefonicaId = new SelectList(db.LineasTelefonica, "LineaTelefonicaId", "LineaTelefonicaId", evaluacion.LineaTelefonicaId);
            //ViewBag.PlanId = new SelectList(db.Planes, "PlanId", "NombrePlan", evaluacion.PlanId);
            //ViewBag.TrabajadorId = new SelectList(db.Trabajadores, "TrabajadorId", "NombreTrabajador", evaluacion.TrabajadorId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = _UnityOfWork.Evaluacion.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CentroAtencionId = new SelectList(db.CentrosAtencion, "CentroAtencionId", "NombreCentroAtencion", evaluacion.CentroAtencionId);
            //ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", evaluacion.ClienteId);
            //ViewBag.EquipoCelularId = new SelectList(db.EquiposCelular, "EquipoCelularId", "Modelo", evaluacion.EquipoCelularId);
            //ViewBag.LineaTelefonicaId = new SelectList(db.LineasTelefonica, "LineaTelefonicaId", "LineaTelefonicaId", evaluacion.LineaTelefonicaId);
            //ViewBag.PlanId = new SelectList(db.Planes, "PlanId", "NombrePlan", evaluacion.PlanId);
            //ViewBag.TrabajadorId = new SelectList(db.Trabajadores, "TrabajadorId", "NombreTrabajador", evaluacion.TrabajadorId);
            return View(evaluacion);
        }

        // POST: Evaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvaluacionId,TrabajadorId,EstadoEvaluacion,TipoEvaluacion,ClienteId,PlanId,CentroAtencionId,LineaTelefonicaId,EquipoCelularId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(evaluacion).State = EntityState.Modified;
                //db.SaveChanges();

                _UnityOfWork.StateModified(evaluacion);
                _UnityOfWork.SaveChange();

                return RedirectToAction("Index");
            }
            //ViewBag.CentroAtencionId = new SelectList(db.CentrosAtencion, "CentroAtencionId", "NombreCentroAtencion", evaluacion.CentroAtencionId);
            //ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre", evaluacion.ClienteId);
            //ViewBag.EquipoCelularId = new SelectList(db.EquiposCelular, "EquipoCelularId", "Modelo", evaluacion.EquipoCelularId);
            //ViewBag.LineaTelefonicaId = new SelectList(db.LineasTelefonica, "LineaTelefonicaId", "LineaTelefonicaId", evaluacion.LineaTelefonicaId);
            //ViewBag.PlanId = new SelectList(db.Planes, "PlanId", "NombrePlan", evaluacion.PlanId);
            //ViewBag.TrabajadorId = new SelectList(db.Trabajadores, "TrabajadorId", "NombreTrabajador", evaluacion.TrabajadorId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = _UnityOfWork.Evaluacion.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluacion evaluacion = _UnityOfWork.Evaluacion.Get(id);
            //db.Evaluaciones.Remove(evaluacion);
            //db.SaveChanges();

            _UnityOfWork.Evaluacion.Delete(evaluacion);
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
