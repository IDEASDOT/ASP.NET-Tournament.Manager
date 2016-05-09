using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNet.Identity;
using Web.ViewModels;


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
            var vm = new PlayerIndexViewModel()
            {
                Players = _uow.Players.GetAllForUser(User.Identity.GetUserId<int>())
            };
            return View(vm);
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
            var vm = new PlayerCreateEditViewModel();
            vm.MapSelectList = new SelectList(_uow.Maps.All.Select(a => a.MapId));
            vm.TeamSelectList = new SelectList(_uow.Teams.All.Select(a => a.TeamId));
//            ViewBag.MapId = new SelectList(_uow.Maps.All, "MapId", "MapName");
//            ViewBag.TeamId = new SelectList(_uow.Teams.All, "TeamId", "TeamName");
            return View(vm);
        }

        // POST: players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // do not get user id from html get/post!!!!
                vm.Player.UserId = User.Identity.GetUserId<int>();

                _uow.Players.Add(vm.Player);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

            vm.MapSelectList = new SelectList(_uow.Maps.All.Select(a => a.MapId), vm.Player.MapId);
            vm.TeamSelectList = new SelectList(_uow.Teams.All.Select(a => a.TeamId), vm.Player.TeamId);
            return View(vm);
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
            var vm = new PlayerCreateEditViewModel()
            {
                Player = player
            };
            vm.MapSelectList = new SelectList(_uow.Maps.All.Select(a => a.MapId), vm.Player.MapId);
            vm.TeamSelectList = new SelectList(_uow.Teams.All.Select(a => a.TeamId), vm.Player.TeamId);
            return View(vm);
        }

        // POST: players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlayerCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // do not get user id from html get/post!!!!
                vm.Player.UserId = User.Identity.GetUserId<int>();

                _uow.Players.Update(vm.Player);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            vm.MapSelectList = new SelectList(_uow.Maps.All.Select(a => a.MapId), vm.Player.MapId);
            vm.TeamSelectList = new SelectList(_uow.Teams.All.Select(a => a.TeamId), vm.Player.TeamId);
            return View(vm);
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
        }
    }
}

