using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Domain;

namespace Web.Controllers
{
    public class ModelSeriesController : Controller
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;
        public ModelSeriesController(IUOW uow)
        {
            _uow = uow;

        }
        // GET: ModelSeries
        public ActionResult Index()
        {
            return View(_uow.ModelSeries.All);
        }

        // GET: ModelSeries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerie modelSerie = _uow.ModelSeries.GetById(id);
            if (modelSerie == null)
            {
                return HttpNotFound();
            }
            return View(modelSerie);
        }

        // GET: ModelSeries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelSeries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelSerieId,ModelSerieName")] ModelSerie modelSerie)
        {
            if (ModelState.IsValid)
            {
                _uow.ModelSeries.Add(modelSerie);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(modelSerie);
        }

        // GET: ModelSeries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerie modelSerie = _uow.ModelSeries.GetById(id);
            if (modelSerie == null)
            {
                return HttpNotFound();
            }
            return View(modelSerie);
        }

        // POST: ModelSeries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelSerieId,ModelSerieName")] ModelSerie modelSerie)
        {
            if (ModelState.IsValid)
            {
                _uow.ModelSeries.Update(modelSerie);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(modelSerie);
        }

        // GET: ModelSeries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerie modelSerie = _uow.ModelSeries.GetById(id);
            if (modelSerie == null)
            {
                return HttpNotFound();
            }
            return View(modelSerie);
        }

        // POST: ModelSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.ModelSeries.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.ModelSeries.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
