﻿using System;
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
    public class MatchesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Matches
        public ActionResult Index()
        {
            var matches = db.Matches.Include(m => m.FirstTeam).Include(m => m.SecondTeam);
            return View(matches.ToList());
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            ViewBag.FirstTeamId = new SelectList(db.Teams, "TeamId", "TeamName");
            ViewBag.SecondTeamId = new SelectList(db.Teams, "TeamId", "TeamName");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchId,FirstTeamId,SecondTeamId,NumberOfMapsPlayed,FirstTeamFirstMapRoundsWon,SecondTeamFirstMapRoundsWon,FirstTeamSecondMapRoundsWon,SecondTeamSecondMapRoundsWon,FirstTeamThirdMapRoundsWon,SecondTeamThirdMapRoundsWon,FirstTeamFourthMapRoundsWon,SecondTeamFourthMapRoundsWon,FirstTeamFifthMapRoundsWon,SecondTeamFifthMapRoundsWon")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FirstTeamId = new SelectList(db.Teams, "TeamId", "TeamName", match.FirstTeamId);
            ViewBag.SecondTeamId = new SelectList(db.Teams, "TeamId", "TeamName", match.SecondTeamId);
            return View(match);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirstTeamId = new SelectList(db.Teams, "TeamId", "TeamName", match.FirstTeamId);
            ViewBag.SecondTeamId = new SelectList(db.Teams, "TeamId", "TeamName", match.SecondTeamId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchId,FirstTeamId,SecondTeamId,NumberOfMapsPlayed,FirstTeamFirstMapRoundsWon,SecondTeamFirstMapRoundsWon,FirstTeamSecondMapRoundsWon,SecondTeamSecondMapRoundsWon,FirstTeamThirdMapRoundsWon,SecondTeamThirdMapRoundsWon,FirstTeamFourthMapRoundsWon,SecondTeamFourthMapRoundsWon,FirstTeamFifthMapRoundsWon,SecondTeamFifthMapRoundsWon")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirstTeamId = new SelectList(db.Teams, "TeamId", "TeamName", match.FirstTeamId);
            ViewBag.SecondTeamId = new SelectList(db.Teams, "TeamId", "TeamName", match.SecondTeamId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
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
