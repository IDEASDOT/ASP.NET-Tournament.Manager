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
    public class GameSpecificationsController : BaseController
    {
        private readonly IUOW _uow;
        //private DataBaseContext _uow = new DataBaseContext();
        public GameSpecificationsController(IUOW uow)
        {
            _uow = uow;
        }


        // GET: GameSpecifications
        public ActionResult Index()
        {
            //var gameSpecifications = _uow.GameSpecifications.Include(g => g.Player);
            return View(_uow.GameSpecifications.AllIncluding());
        }

        // GET: GameSpecifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSpecification gameSpecification = _uow.GameSpecifications.GetById(id);
            if (gameSpecification == null)
            {
                return HttpNotFound();
            }
            return View(gameSpecification);
        }

        // GET: GameSpecifications/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName");
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
                _uow.GameSpecifications.Add(gameSpecification);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName", gameSpecification.PlayerId);
            return View(gameSpecification);
        }

        // GET: GameSpecifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSpecification gameSpecification = _uow.GameSpecifications.GetById(id);
            if (gameSpecification == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName", gameSpecification.PlayerId);
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
                _uow.GameSpecifications.Update(gameSpecification);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName", gameSpecification.PlayerId);
            return View(gameSpecification);
        }

        // GET: GameSpecifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameSpecification gameSpecification = _uow.GameSpecifications.GetById(id);
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
            
            _uow.GameSpecifications.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.GameSpecifications.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
