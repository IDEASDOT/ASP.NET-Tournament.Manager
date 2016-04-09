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
    public class MapInfosController : BaseController
    {
        private readonly IUOW _uow;
        //private DataBaseContext _uow = new DataBaseContext();

        public MapInfosController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: MapInfos
        public ActionResult Index()
        {
            //var mapInfos = _uow.MapInfos.Include(m => m.Map).Include(m => m.Match);
            var mapInfos = _uow.MapInfos.AllIncluding();
            return View(mapInfos);
        }

        // GET: MapInfos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapInfo mapInfo = _uow.MapInfos.GetById(id);
            if (mapInfo == null)
            {
                return HttpNotFound();
            }
            return View(mapInfo);
        }

        // GET: MapInfos/Create
        public ActionResult Create()
        {
            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName");
            ViewBag.MatchId = new SelectList(_uow.Matches.All, "MatchId", "MatchId");
            return View();
        }

        // POST: MapInfos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapInfoId,MapId,MatchId,FirstTeamScore,SecondTeamScore")] MapInfo mapInfo)
        {
            if (ModelState.IsValid)
            {
                _uow.MapInfos.Add(mapInfo);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName", mapInfo.MapId);
            ViewBag.MatchId = new SelectList(_uow.Matches.All, "MatchId", "MatchId", mapInfo.MatchId);
            return View(mapInfo);
        }

        // GET: MapInfos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapInfo mapInfo = _uow.MapInfos.GetById(id);
            if (mapInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName", mapInfo.MapId);
            ViewBag.MatchId = new SelectList(_uow.Matches.All, "MatchId", "MatchId", mapInfo.MatchId);
            return View(mapInfo);
        }

        // POST: MapInfos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapInfoId,MapId,MatchId,FirstTeamScore,SecondTeamScore")] MapInfo mapInfo)
        {
            if (ModelState.IsValid)
            {
                _uow.MapInfos.Update(mapInfo);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName", mapInfo.MapId);
            ViewBag.MatchId = new SelectList(_uow.Matches.All, "MatchId", "MatchId", mapInfo.MatchId);
            return View(mapInfo);
        }

        // GET: MapInfos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapInfo mapInfo = _uow.MapInfos.GetById(id);
            if (mapInfo == null)
            {
                return HttpNotFound();
            }
            return View(mapInfo);
        }

        // POST: MapInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.MapInfos.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.MapInfos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
