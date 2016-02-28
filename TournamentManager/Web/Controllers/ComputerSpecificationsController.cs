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
    public class ComputerSpecificationsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: ComputerSpecifications
        public ActionResult Index()
        {
            var computerSpecifications = db.ComputerSpecifications.Include(c => c.Player);
            return View(computerSpecifications.ToList());
        }

        // GET: ComputerSpecifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerSpecification computerSpecification = db.ComputerSpecifications.Find(id);
            if (computerSpecification == null)
            {
                return HttpNotFound();
            }
            return View(computerSpecification);
        }

        // GET: ComputerSpecifications/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName");
            return View();
        }

        // POST: ComputerSpecifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompSpecId,ProcessorName,GraphicName,StorageName,RamName,OsName,MouseName,MousePadName,HeadsetName,KeyboardName,PlayerId,CompWins,CompLost")] ComputerSpecification computerSpecification)
        {
            if (ModelState.IsValid)
            {
                db.ComputerSpecifications.Add(computerSpecification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName", computerSpecification.PlayerId);
            return View(computerSpecification);
        }

        // GET: ComputerSpecifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerSpecification computerSpecification = db.ComputerSpecifications.Find(id);
            if (computerSpecification == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName", computerSpecification.PlayerId);
            return View(computerSpecification);
        }

        // POST: ComputerSpecifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompSpecId,ProcessorName,GraphicName,StorageName,RamName,OsName,MouseName,MousePadName,HeadsetName,KeyboardName,PlayerId,CompWins,CompLost")] ComputerSpecification computerSpecification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computerSpecification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "FirstName", computerSpecification.PlayerId);
            return View(computerSpecification);
        }

        // GET: ComputerSpecifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerSpecification computerSpecification = db.ComputerSpecifications.Find(id);
            if (computerSpecification == null)
            {
                return HttpNotFound();
            }
            return View(computerSpecification);
        }

        // POST: ComputerSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComputerSpecification computerSpecification = db.ComputerSpecifications.Find(id);
            db.ComputerSpecifications.Remove(computerSpecification);
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
