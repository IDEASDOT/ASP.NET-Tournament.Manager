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
    public class ManufactorersController : Controller
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;
        public ManufactorersController(IUOW uow)
        {
            _uow = uow;

        }
        // GET: Manufactorers
        public ActionResult Index()
        {
            var manufactorers = _uow.Manufactorers.All;
            return View(manufactorers);
        }

        // GET: Manufactorers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufactorer manufactorer = _uow.Manufactorers.GetById(id);
            if (manufactorer == null)
            {
                return HttpNotFound();
            }
            return View(manufactorer);
        }

        // GET: Manufactorers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manufactorers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManufactorerId,ManufactorerName")] Manufactorer manufactorer)
        {
            if (ModelState.IsValid)
            {
                _uow.Manufactorers.Add(manufactorer);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(manufactorer);
        }

        // GET: Manufactorers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufactorer manufactorer = _uow.Manufactorers.GetById(id);
            if (manufactorer == null)
            {
                return HttpNotFound();
            }
            return View(manufactorer);
        }

        // POST: Manufactorers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManufactorerId,ManufactorerName")] Manufactorer manufactorer)
        {
            if (ModelState.IsValid)
            {
                _uow.Manufactorers.Update(manufactorer);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(manufactorer);
        }

        // GET: Manufactorers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufactorer manufactorer = _uow.Manufactorers.GetById(id);
            if (manufactorer == null)
            {
                return HttpNotFound();
            }
            return View(manufactorer);
        }

        // POST: Manufactorers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Manufactorers.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Manufactorers.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
