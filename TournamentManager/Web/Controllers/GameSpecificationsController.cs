using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNet.Identity;
using Web.ViewModels;

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
            var vm = new GameSpecificationIndexViewModel()
            {
                GameSpecifications = _uow.GameSpecifications.AllIncluding()
            };
            //var gameSpecifications = _uow.GameSpecifications.Include(g => g.Player);
            return View(vm);
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
            var vm = new GameSpecificationCreateEditViewModel();
            vm.PlayerSelectList = new SelectList(_uow.Players.GetAllForUser(User.Identity.GetUserId<int>()), nameof(Player.PlayerId), nameof(Player.FullName));
            //ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName");
            return View(vm);
        }

        // POST: GameSpecifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameSpecificationCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.GameSpecifications.Add(vm.GameSpecification);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            vm.PlayerSelectList = new SelectList(_uow.Players.GetAllForUser(User.Identity.GetUserId<int>()), nameof(Player.PlayerId), nameof(Player.FullName), vm.GameSpecification.PlayerId);
            return View(vm);
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

            var vm = new GameSpecificationCreateEditViewModel()
            {
                GameSpecification = gameSpecification
            };

            vm.PlayerSelectList = new SelectList(_uow.Players.GetAllForUser(User.Identity.GetUserId<int>()), nameof(Player.PlayerId), nameof(Player.FullName), vm.GameSpecification.PlayerId);
            return View(vm);
        }

        // POST: GameSpecifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( GameSpecificationCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.GameSpecifications.Update(vm.GameSpecification);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.PlayerSelectList = new SelectList(_uow.Players.GetAllForUser(User.Identity.GetUserId<int>()), nameof(Player.PlayerId), nameof(Player.FullName), vm.GameSpecification.PlayerId);
            return View(vm);
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
        }
    }
}
