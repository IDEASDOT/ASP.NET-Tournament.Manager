﻿using System;
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
    public class PlayersController : BaseController
    {
        //TODO FIX ALL THINGIES
        private readonly IUOW _uow;
        //private DataBaseContext _uow = new DataBaseContext();

        public PlayersController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: Players
        public ActionResult Index()
        {
            //var players = _uow.Players.Include(p => p.FavouriteMap).Include(p => p.Team).Include(p => p.User);
            //return System.Web.UI.WebControls.View(_uow.Players.GetAllForUser(User.Identity.GetUserId<int>()));
            var players = _uow.Players.AllIncluding();
            return View(players);
        }

        // GET: Players/Details/5
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

        // GET: Players/Create
        public ActionResult Create()
        {
//            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName");
//            ViewBag.TeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName");
                    //ViewBag.UserId = new SelectList(_uow.UserInts.All, "Id", "Email");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerId,FirstName,NickName,LastName,MapId,AllTimeWins,CurrentWins,AllTimeLost,CurrentLost,TeamId,UserId")] Player player)
        {
            if (ModelState.IsValid)
            {

                //Player.UserId= User.Identity.GetUserId<int>();
                _uow.Players.Add(player);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName", player.MapId);
            ViewBag.TeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", player.TeamId);
            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Player player = _uow.Players.GetForUser(id.Value, User.Identity.GetUserId<int>());
            Player player = _uow.Players.GetById(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName", player.MapId);
            ViewBag.TeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", player.TeamId);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerId,FirstName,NickName,LastName,MapId,AllTimeWins,CurrentWins,AllTimeLost,CurrentLost,TeamId,UserId")] Player player)
        {
            if (ModelState.IsValid)
            {
                player.UserId = User.Identity.GetUserId<int>();
                _uow.Players.Update(player);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName", player.MapId);
            ViewBag.TeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", player.TeamId);
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Player player = _uow.Players.GetForUser(id.Value, User.Identity.GetUserId<int>());
            Player player = _uow.Players.GetById(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            _uow.Players.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Players.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
