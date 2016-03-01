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
    public class ModelSerieTypesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: ModelSerieTypes
        public ActionResult Index()
        {
            return View(db.ModelSerieTypes.ToList());
        }

        // GET: ModelSerieTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerieType modelSerieType = db.ModelSerieTypes.Find(id);
            if (modelSerieType == null)
            {
                return HttpNotFound();
            }
            return View(modelSerieType);
        }

        // GET: ModelSerieTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelSerieTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelSerieTypeId,ModelSerieTypeName")] ModelSerieType modelSerieType)
        {
            if (ModelState.IsValid)
            {
                db.ModelSerieTypes.Add(modelSerieType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelSerieType);
        }

        // GET: ModelSerieTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerieType modelSerieType = db.ModelSerieTypes.Find(id);
            if (modelSerieType == null)
            {
                return HttpNotFound();
            }
            return View(modelSerieType);
        }

        // POST: ModelSerieTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelSerieTypeId,ModelSerieTypeName")] ModelSerieType modelSerieType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelSerieType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelSerieType);
        }

        // GET: ModelSerieTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerieType modelSerieType = db.ModelSerieTypes.Find(id);
            if (modelSerieType == null)
            {
                return HttpNotFound();
            }
            return View(modelSerieType);
        }

        // POST: ModelSerieTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelSerieType modelSerieType = db.ModelSerieTypes.Find(id);
            db.ModelSerieTypes.Remove(modelSerieType);
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
