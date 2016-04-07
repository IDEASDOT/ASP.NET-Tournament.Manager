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
    public class PieceInComputersController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: PieceInComputers
        public ActionResult Index()
        {
            var pieceInComputers = db.PieceInComputers.Include(p => p.ComputerSpecification).Include(p => p.ProductSelector);
            return View(pieceInComputers.ToList());
        }

        // GET: PieceInComputers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieceInComputer pieceInComputer = db.PieceInComputers.Find(id);
            if (pieceInComputer == null)
            {
                return HttpNotFound();
            }
            return View(pieceInComputer);
        }

        // GET: PieceInComputers/Create
        public ActionResult Create()
        {
            ViewBag.CompSpecId = new SelectList(db.ComputerSpecifications, "CompSpecId", "OsName");
            ViewBag.ProductSelectorId = new SelectList(db.ProductSelectors, "ProductSelectorId", "ProductSelectorId");
            return View();
        }

        // POST: PieceInComputers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PieceInComputerId,Quantity,ProductSelectorId,CompSpecId")] PieceInComputer pieceInComputer)
        {
            if (ModelState.IsValid)
            {
                db.PieceInComputers.Add(pieceInComputer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompSpecId = new SelectList(db.ComputerSpecifications, "CompSpecId", "OsName", pieceInComputer.CompSpecId);
            ViewBag.ProductSelectorId = new SelectList(db.ProductSelectors, "ProductSelectorId", "ProductSelectorId", pieceInComputer.ProductSelectorId);
            return View(pieceInComputer);
        }

        // GET: PieceInComputers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieceInComputer pieceInComputer = db.PieceInComputers.Find(id);
            if (pieceInComputer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompSpecId = new SelectList(db.ComputerSpecifications, "CompSpecId", "OsName", pieceInComputer.CompSpecId);
            ViewBag.ProductSelectorId = new SelectList(db.ProductSelectors, "ProductSelectorId", "ProductSelectorId", pieceInComputer.ProductSelectorId);
            return View(pieceInComputer);
        }

        // POST: PieceInComputers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PieceInComputerId,Quantity,ProductSelectorId,CompSpecId")] PieceInComputer pieceInComputer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pieceInComputer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompSpecId = new SelectList(db.ComputerSpecifications, "CompSpecId", "OsName", pieceInComputer.CompSpecId);
            ViewBag.ProductSelectorId = new SelectList(db.ProductSelectors, "ProductSelectorId", "ProductSelectorId", pieceInComputer.ProductSelectorId);
            return View(pieceInComputer);
        }

        // GET: PieceInComputers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieceInComputer pieceInComputer = db.PieceInComputers.Find(id);
            if (pieceInComputer == null)
            {
                return HttpNotFound();
            }
            return View(pieceInComputer);
        }

        // POST: PieceInComputers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PieceInComputer pieceInComputer = db.PieceInComputers.Find(id);
            db.PieceInComputers.Remove(pieceInComputer);
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
