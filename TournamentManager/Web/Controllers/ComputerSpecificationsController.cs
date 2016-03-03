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
    public class ComputerSpecificationsController : Controller
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;
        public ComputerSpecificationsController(IUOW uow)
        {
            _uow = uow;

        }
        // GET: ComputerSpecifications
        public ActionResult Index()
        {
            //var computerSpecifications = db.ComputerSpecifications.Include(c => c.Player).Include(c => c.ProductSelector);
            var computerSpecifications = _uow.ComputerSpecifications.GetAllIncluding();
            return View(computerSpecifications);
        }

        // GET: ComputerSpecifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerSpecification computerSpecification = _uow.ComputerSpecifications.GetById(id);
            if (computerSpecification == null)
            {
                return HttpNotFound();
            }
            return View(computerSpecification);
        }

        // GET: ComputerSpecifications/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(_uow.ComputerSpecifications.All, "PlayerId", "FirstName");
            ViewBag.ProductSelectorId = new SelectList(_uow.ComputerSpecifications.All, "ProductSelectorId", "ProductSelectorId");
            return View();
        }

        // POST: ComputerSpecifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompSpecId,ProductSelectorId,OsName,PlayerId,CompWins,CompLost")] ComputerSpecification computerSpecification)
        {
            if (ModelState.IsValid)
            {
                _uow.ComputerSpecifications.Add(computerSpecification);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName", computerSpecification.PlayerId);
            ViewBag.ProductSelectorId = new SelectList(_uow.ProductSelectors.All, "ProductSelectorId", "ProductSelectorId", computerSpecification.ProductSelectorId);
            return View(computerSpecification);
        }

        // GET: ComputerSpecifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerSpecification computerSpecification = _uow.ComputerSpecifications.GetById(id);
            if (computerSpecification == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName", computerSpecification.PlayerId);
            ViewBag.ProductSelectorId = new SelectList(_uow.ProductSelectors.All, "ProductSelectorId", "ProductSelectorId", computerSpecification.ProductSelectorId);
            return View(computerSpecification);
        }

        // POST: ComputerSpecifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompSpecId,ProductSelectorId,OsName,PlayerId,CompWins,CompLost")] ComputerSpecification computerSpecification)
        {
            if (ModelState.IsValid)
            {
                _uow.ComputerSpecifications.Update(computerSpecification);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName", computerSpecification.PlayerId);
            ViewBag.ProductSelectorId = new SelectList(_uow.ProductSelectors.All, "ProductSelectorId", "ProductSelectorId", computerSpecification.ProductSelectorId);
            return View(computerSpecification);
        }

        // GET: ComputerSpecifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerSpecification computerSpecification = _uow.ComputerSpecifications.GetById(id);
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
            _uow.ComputerSpecifications.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.ComputerSpecifications.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
