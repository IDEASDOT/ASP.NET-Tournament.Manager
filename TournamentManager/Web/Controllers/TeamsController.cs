using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;

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
            return View(_uow.Teams.All);
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
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _uow.Teams.Add(team);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(team);
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
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                _uow.Teams.Update(team);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(team);
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
