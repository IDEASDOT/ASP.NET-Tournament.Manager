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
    public class GameSpecificationsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: GameSpecifications
        public ActionResult Index()
        {
            var gameSpecifications = db.GameSpecifications.Include(g => g.Player);
            return View(gameSpecifications.ToList());
        }

        // GET: GameSpecifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSpecification gameSpecification = db.GameSpecifications.Find(id);
            if (gameSpecification == null)
            {
                return HttpNotFound();
            }
            return View(gameSpecification);
        }

        // GET: GameSpecifications/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName");
            return View();
        }

        // POST: GameSpecifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameSpecId,DpiValue,SensitivityValue,PlayerId,GameWins,GameLost")] GameSpecification gameSpecification)
        {
            if (ModelState.IsValid)
            {
                db.GameSpecifications.Add(gameSpecification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName", gameSpecification.PlayerId);
            return View(gameSpecification);
        }

        // GET: GameSpecifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSpecification gameSpecification = db.GameSpecifications.Find(id);
            if (gameSpecification == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName", gameSpecification.PlayerId);
            return View(gameSpecification);
        }

        // POST: GameSpecifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameSpecId,DpiValue,SensitivityValue,PlayerId,GameWins,GameLost")] GameSpecification gameSpecification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameSpecification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName", gameSpecification.PlayerId);
            return View(gameSpecification);
        }

        // GET: GameSpecifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSpecification gameSpecification = db.GameSpecifications.Find(id);
            if (gameSpecification == null)
            {
                return HttpNotFound();
            }
            return View(gameSpecification);
        }

        // POST: GameSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameSpecification gameSpecification = db.GameSpecifications.Find(id);
            db.GameSpecifications.Remove(gameSpecification);
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
