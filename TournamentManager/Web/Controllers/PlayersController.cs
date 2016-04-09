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
using Microsoft.AspNet.Identity;


namespace Web.Controllers
{
    [Authorize]
    public class PlayersController : BaseController
    {
        private readonly IUOW _uow;

        public PlayersController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: players
        public ActionResult Index()
        {
            return View(_uow.Players.GetAllForUser(User.Identity.GetUserId<int>()));
        }

        // GET: players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _uow.Players.GetById(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: players/Create
        public ActionResult Create()
        {
            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName");
            ViewBag.TeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName");
            return View();
        }

        // POST: players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                // do not get user id from html get/post!!!!
                player.UserId = User.Identity.GetUserId<int>();

                _uow.Players.Add(player);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName", player.MapId);
            ViewBag.TeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", player.TeamId);
            return View(player);
        }

        // GET: players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // check user id!!!!
            Player player = _uow.Players.GetForUser(id.Value, User.Identity.GetUserId<int>());
            if (player == null)
            {
                return HttpNotFound();
            }


            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName", player.MapId);
            ViewBag.TeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", player.TeamId);
            return View(player);
        }

        // POST: players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                // do not get user id from html get/post!!!!
                player.UserId = User.Identity.GetUserId<int>();

                _uow.Players.Update(player);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName", player.MapId);
            ViewBag.TeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", player.TeamId);
            return View(player);
        }

        // GET: players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _uow.Players.GetForUser(id.Value, User.Identity.GetUserId<int>());
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Players.Delete(id);
            _uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}

