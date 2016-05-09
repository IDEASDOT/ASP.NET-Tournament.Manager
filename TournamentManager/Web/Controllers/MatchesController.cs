using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.ViewModels;

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
            var vm = new MatchIndexViewModel()
            {
                Matches = _uow.Matches.AllIncluding()
            };
            
            return View(vm);
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
            var vm = new MatchCreateEditViewModel();
            vm.FirstTeamSelectList = new SelectList(_uow.Teams.All, nameof(Team.TeamId), nameof(Team.TeamName));
            vm.SecondTeamSelectList = new SelectList(_uow.Teams.All, nameof(Team.TeamId), nameof(Team.TeamName));
            return View(vm);
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MatchCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Matches.Add(vm.Match);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            vm.FirstTeamSelectList = new SelectList(_uow.Teams.All, nameof(Team.TeamId), nameof(Team.TeamName), vm.Match.FirstTeamId);
            vm.SecondTeamSelectList = new SelectList(_uow.Teams.All, nameof(Team.TeamId), nameof(Team.TeamName), vm.Match.SecondTeamId);
            return View(vm);
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

            var vm = new MatchCreateEditViewModel()
            {
                Match = match
            };
            vm.FirstTeamSelectList = new SelectList(_uow.Teams.All, nameof(Team.TeamId), nameof(Team.TeamName), vm.Match.FirstTeamId);
            vm.SecondTeamSelectList = new SelectList(_uow.Teams.All, nameof(Team.TeamId), nameof(Team.TeamName), vm.Match.SecondTeamId);
            return View(vm);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MatchCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Matches.Update(vm.Match);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.FirstTeamSelectList = new SelectList(_uow.Teams.All, nameof(Team.TeamId), nameof(Team.TeamName), vm.Match.FirstTeamId);
            vm.SecondTeamSelectList = new SelectList(_uow.Teams.All, nameof(Team.TeamId), nameof(Team.TeamName), vm.Match.SecondTeamId);
            return View(vm);
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
