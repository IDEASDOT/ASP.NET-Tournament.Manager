using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class TeamsController : BaseController
    {
        private readonly IUOW _uow;
        //private DataBaseContext _uow = new DataBaseContext();
        public TeamsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Teams
        public ActionResult Index()
        {
            var vm = new TeamIndexViewModel()
            {
                Teams = _uow.Teams.All
            };
            return View(vm);
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = _uow.Teams.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            var vm = new TeamCreateEditViewModel();
            return View(vm);
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Teams.Add(vm.Team);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = _uow.Teams.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }

            var vm = new TeamCreateEditViewModel()
            {
                Team = team
            };

            return View(vm);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeamCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Teams.Update(vm.Team);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = _uow.Teams.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Teams.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
