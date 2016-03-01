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
    public class ManufactorerTypesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: ManufactorerTypes
        public ActionResult Index()
        {
            return View(db.ManufactorerTypes.ToList());
        }

        // GET: ManufactorerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufactorerType manufactorerType = db.ManufactorerTypes.Find(id);
            if (manufactorerType == null)
            {
                return HttpNotFound();
            }
            return View(manufactorerType);
        }

        // GET: ManufactorerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManufactorerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManufactorerTypeId,ManufactorerTypeName")] ManufactorerType manufactorerType)
        {
            if (ModelState.IsValid)
            {
                db.ManufactorerTypes.Add(manufactorerType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manufactorerType);
        }

        // GET: ManufactorerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufactorerType manufactorerType = db.ManufactorerTypes.Find(id);
            if (manufactorerType == null)
            {
                return HttpNotFound();
            }
            return View(manufactorerType);
        }

        // POST: ManufactorerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManufactorerTypeId,ManufactorerTypeName")] ManufactorerType manufactorerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufactorerType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufactorerType);
        }

        // GET: ManufactorerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufactorerType manufactorerType = db.ManufactorerTypes.Find(id);
            if (manufactorerType == null)
            {
                return HttpNotFound();
            }
            return View(manufactorerType);
        }

        // POST: ManufactorerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManufactorerType manufactorerType = db.ManufactorerTypes.Find(id);
            db.ManufactorerTypes.Remove(manufactorerType);
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
