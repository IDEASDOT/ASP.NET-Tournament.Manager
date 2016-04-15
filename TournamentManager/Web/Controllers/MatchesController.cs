using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;

namespace Web.Controllers
{
    public class MatchesController : BaseController
    {
        private readonly IUOW _uow;
        //private DataBaseContext _uow = new DataBaseContext();

        public MatchesController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: Matches
        public ActionResult Index()
        {
            //var matches = _uow.Matches.Include(m => m.FirstTeam).Include(m => m.SecondTeam);
            var matches = _uow.Matches.AllIncluding();
            return View(matches);
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = _uow.Matches.GetById(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            ViewBag.FirstTeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName");
            ViewBag.SecondTeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Match match)
        {
            if (ModelState.IsValid)
            {
                _uow.Matches.Add(match);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.FirstTeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", match.FirstTeamId);
            ViewBag.SecondTeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", match.SecondTeamId);
            return View(match);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = _uow.Matches.GetById(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirstTeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", match.FirstTeamId);
            ViewBag.SecondTeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", match.SecondTeamId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Match match)
        {
            if (ModelState.IsValid)
            {
                _uow.Matches.Update(match);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.FirstTeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", match.FirstTeamId);
            ViewBag.SecondTeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName", match.SecondTeamId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = _uow.Matches.GetById(id);
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
            _uow.Matches.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
