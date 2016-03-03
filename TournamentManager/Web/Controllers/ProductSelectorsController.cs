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
    public class ProductSelectorsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;
        public ProductSelectorsController(IUOW uow)
        {
            _uow = uow;

        }
        // GET: ProductSelectors
        public ActionResult Index()
        {
            var productSelectors = _uow.ProductSelectors.All;
            return View(productSelectors);
        }

        // GET: ProductSelectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSelector productSelector = _uow.ProductSelectors.GetById(id);
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
                _uow.ProductSelectors.Add(productSelector);
                _uow.Commit();
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
            ProductSelector productSelector = _uow.ProductSelectors.GetById(id);
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
                _uow.ProductSelectors.Update(productSelector);
                _uow.Commit();
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
            ProductSelector productSelector = _uow.ProductSelectors.GetById(id);
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
            _uow.ProductSelectors.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.ProductSelectors.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
