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
    public class MapPoolsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: MapPools
        public ActionResult Index()
        {
            return View(db.MapPools.ToList());
        }

        // GET: MapPools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPool mapPool = db.MapPools.Find(id);
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
                db.MapPools.Add(mapPool);
                db.SaveChanges();
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
            MapPool mapPool = db.MapPools.Find(id);
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
                db.Entry(mapPool).State = EntityState.Modified;
                db.SaveChanges();
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
            MapPool mapPool = db.MapPools.Find(id);
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
            MapPool mapPool = db.MapPools.Find(id);
            db.MapPools.Remove(mapPool);
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
