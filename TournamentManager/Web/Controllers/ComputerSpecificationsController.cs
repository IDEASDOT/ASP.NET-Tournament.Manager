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
    [Authorize]
    public class ComputerSpecificationsController : BaseController
    {
        //Taipohh kui ma kuskil _uow näen
        //private DataBaseContext _uow = new DataBaseContext();

        private readonly IUOW _uow;

        public ComputerSpecificationsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: ComputerSpecifications
        public ActionResult Index()
        {
            return View(_uow.ComputerSpecifications.AllIncluding());
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
            ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName");
            return View();
        }

        // POST: ComputerSpecifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompSpecId,OsName,PlayerId,CompWins,CompLost")] ComputerSpecification computerSpecification)
        {
            if (ModelState.IsValid)
            {
                _uow.ComputerSpecifications.Add(computerSpecification);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName", computerSpecification.PlayerId);
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
            return View(computerSpecification);
        }

        // POST: ComputerSpecifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompSpecId,OsName,PlayerId,CompWins,CompLost")] ComputerSpecification computerSpecification)
        {
            if (ModelState.IsValid)
            {
                _uow.ComputerSpecifications.Update(computerSpecification);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName", computerSpecification.PlayerId);
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
