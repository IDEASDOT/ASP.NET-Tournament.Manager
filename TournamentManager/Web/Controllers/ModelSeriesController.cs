using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Domain;

namespace Web.Controllers
{
    public class ModelSeriesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: ModelSeries
        public ActionResult Index()
        {
            return View(db.ModelSeries.ToList());
        }

        // GET: ModelSeries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerie modelSerie = db.ModelSeries.Find(id);
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
                db.ModelSeries.Add(modelSerie);
                db.SaveChanges();
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
            ModelSerie modelSerie = db.ModelSeries.Find(id);
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
                db.Entry(modelSerie).State = EntityState.Modified;
                db.SaveChanges();
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
            ModelSerie modelSerie = db.ModelSeries.Find(id);
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
            ModelSerie modelSerie = db.ModelSeries.Find(id);
            db.ModelSeries.Remove(modelSerie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
