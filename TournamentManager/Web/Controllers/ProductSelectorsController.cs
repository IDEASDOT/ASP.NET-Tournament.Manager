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
    public class ProductSelectorsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: ProductSelectors
        public ActionResult Index()
        {
            var productSelectors = db.ProductSelectors.Include(p => p.Manufactorer).Include(p => p.ManufactorerType).Include(p => p.ModelSerie).Include(p => p.ModelSerieType);
            return View(productSelectors.ToList());
        }

        // GET: ProductSelectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSelector productSelector = db.ProductSelectors.Find(id);
            if (productSelector == null)
            {
                return HttpNotFound();
            }
            return View(productSelector);
        }

        // GET: ProductSelectors/Create
        public ActionResult Create()
        {
            ViewBag.ManufactorerId = new SelectList(db.Manufactorers, "ManufactorerId", "ManufactorerName");
            ViewBag.ManufactorerTypeId = new SelectList(db.ManufactorerTypes, "ManufactorerTypeId", "ManufactorerTypeName");
            ViewBag.ModelSerieId = new SelectList(db.ModelSeries, "ModelSerieId", "ModelSerieName");
            ViewBag.ModelSerieTypeId = new SelectList(db.ModelSerieTypes, "ModelSerieTypeId", "ModelSerieTypeName");
            return View();
        }

        // POST: ProductSelectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductSelectorId,ManufactorerTypeId,ManufactorerId,ModelSerieId,ModelSerieTypeId")] ProductSelector productSelector)
        {
            if (ModelState.IsValid)
            {
                db.ProductSelectors.Add(productSelector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufactorerId = new SelectList(db.Manufactorers, "ManufactorerId", "ManufactorerName", productSelector.ManufactorerId);
            ViewBag.ManufactorerTypeId = new SelectList(db.ManufactorerTypes, "ManufactorerTypeId", "ManufactorerTypeName", productSelector.ManufactorerTypeId);
            ViewBag.ModelSerieId = new SelectList(db.ModelSeries, "ModelSerieId", "ModelSerieName", productSelector.ModelSerieId);
            ViewBag.ModelSerieTypeId = new SelectList(db.ModelSerieTypes, "ModelSerieTypeId", "ModelSerieTypeName", productSelector.ModelSerieTypeId);
            return View(productSelector);
        }

        // GET: ProductSelectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSelector productSelector = db.ProductSelectors.Find(id);
            if (productSelector == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufactorerId = new SelectList(db.Manufactorers, "ManufactorerId", "ManufactorerName", productSelector.ManufactorerId);
            ViewBag.ManufactorerTypeId = new SelectList(db.ManufactorerTypes, "ManufactorerTypeId", "ManufactorerTypeName", productSelector.ManufactorerTypeId);
            ViewBag.ModelSerieId = new SelectList(db.ModelSeries, "ModelSerieId", "ModelSerieName", productSelector.ModelSerieId);
            ViewBag.ModelSerieTypeId = new SelectList(db.ModelSerieTypes, "ModelSerieTypeId", "ModelSerieTypeName", productSelector.ModelSerieTypeId);
            return View(productSelector);
        }

        // POST: ProductSelectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductSelectorId,ManufactorerTypeId,ManufactorerId,ModelSerieId,ModelSerieTypeId")] ProductSelector productSelector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSelector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufactorerId = new SelectList(db.Manufactorers, "ManufactorerId", "ManufactorerName", productSelector.ManufactorerId);
            ViewBag.ManufactorerTypeId = new SelectList(db.ManufactorerTypes, "ManufactorerTypeId", "ManufactorerTypeName", productSelector.ManufactorerTypeId);
            ViewBag.ModelSerieId = new SelectList(db.ModelSeries, "ModelSerieId", "ModelSerieName", productSelector.ModelSerieId);
            ViewBag.ModelSerieTypeId = new SelectList(db.ModelSerieTypes, "ModelSerieTypeId", "ModelSerieTypeName", productSelector.ModelSerieTypeId);
            return View(productSelector);
        }

        // GET: ProductSelectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSelector productSelector = db.ProductSelectors.Find(id);
            if (productSelector == null)
            {
                return HttpNotFound();
            }
            return View(productSelector);
        }

        // POST: ProductSelectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSelector productSelector = db.ProductSelectors.Find(id);
            db.ProductSelectors.Remove(productSelector);
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
