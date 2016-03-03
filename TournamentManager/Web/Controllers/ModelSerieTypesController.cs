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
    public class ModelSerieTypesController : Controller
    {
        //private DataBaseContext _uow = new DataBaseContext();
        private readonly IUOW _uow;
        public ModelSerieTypesController(IUOW uow)
        {
            _uow = uow;

        }
        // GET: ModelSerieTypes
        public ActionResult Index()
        {
            var modelSerieType = _uow.ModelSerieTypes.All;
            return View(modelSerieType);
        }

        // GET: ModelSerieTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerieType modelSerieType = _uow.ModelSerieTypes.GetById(id);
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
                _uow.ModelSerieTypes.Add(modelSerieType);
                _uow.Commit();
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
            ModelSerieType modelSerieType = _uow.ModelSerieTypes.GetById(id);
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
                _uow.ModelSerieTypes.Update(modelSerieType);
                _uow.Commit();
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
            ModelSerieType modelSerieType = _uow.ModelSerieTypes.GetById(id);
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
            _uow.ModelSerieTypes.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.ModelSerieTypes.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
