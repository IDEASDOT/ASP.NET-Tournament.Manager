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
    public class MapPoolsController : Controller
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;
        public MapPoolsController(IUOW uow)
        {
            _uow = uow;

        }
        // GET: MapPools
        public ActionResult Index()
        {
            var mapPool = _uow.MapPools.All;
            return View(mapPool);
        }

        // GET: MapPools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPool mapPool = _uow.MapPools.GetById(id);
            if (mapPool == null)
            {
                return HttpNotFound();
            }
            return View(mapPool);
        }

        // GET: MapPools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MapPools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapId,MapName")] MapPool mapPool)
        {
            if (ModelState.IsValid)
            {
                _uow.MapPools.Add(mapPool);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(mapPool);
        }

        // GET: MapPools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPool mapPool = _uow.MapPools.GetById(id);
            if (mapPool == null)
            {
                return HttpNotFound();
            }
            return View(mapPool);
        }

        // POST: MapPools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapId,MapName")] MapPool mapPool)
        {
            if (ModelState.IsValid)
            {
                _uow.MapPools.Update(mapPool);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(mapPool);
        }

        // GET: MapPools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPool mapPool = _uow.MapPools.GetById(id);
            if (mapPool == null)
            {
                return HttpNotFound();
            }
            return View(mapPool);
        }

        // POST: MapPools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.MapPools.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.MapPools.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
