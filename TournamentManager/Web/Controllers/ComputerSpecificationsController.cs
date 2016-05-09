using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNet.Identity;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class ComputerSpecificationsController : BaseController
    {
        //Taipohh kui ma kuskil _uow näen
        //private DataBaseContext _uow = new DataBaseContext();

        private readonly IUOW _uow;

        public ComputerSpecificationsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: ComputerSpecifications
        public ActionResult Index()
        {
            var vm = new ComputerSpecificationIndexViewModel()
            {
                ComputerSpecifications = _uow.ComputerSpecifications.AllIncluding()
            };
            return View(vm);
        }

        // GET: ComputerSpecifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerSpecification computerSpecification = _uow.ComputerSpecifications.GetById(id);
            if (computerSpecification == null)
            {
                return HttpNotFound();
            }
            return View(computerSpecification);
        }

        // GET: ComputerSpecifications/Create
        public ActionResult Create()
        {
            var vm = new ComputerSpecificationCreateEditViewModel();
            vm.PlayerSelectList = new SelectList(_uow.Players.GetAllForUser(User.Identity.GetUserId<int>()), nameof(Player.PlayerId), nameof(Player.FullName));
            //ViewBag.PlayerId = new SelectList(_uow.Players.All, "PlayerId", "FirstName");
            return View(vm);
        }

        // POST: ComputerSpecifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComputerSpecificationCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.ComputerSpecifications.Add(vm.ComputerSpecification);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.PlayerSelectList = new SelectList(_uow.Players.GetAllForUser(User.Identity.GetUserId<int>()), nameof(Player.PlayerId), nameof(Player.FullName), vm.ComputerSpecification.PlayerId);
            return View(vm);
        }

        // GET: ComputerSpecifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerSpecification computerSpecification = _uow.ComputerSpecifications.GetById(id);
            if (computerSpecification == null)
            {
                return HttpNotFound();
            }

            var vm = new ComputerSpecificationCreateEditViewModel()
            {
                ComputerSpecification = computerSpecification
            };

            vm.PlayerSelectList = new SelectList(_uow.Players.GetAllForUser(User.Identity.GetUserId<int>()), nameof(Player.PlayerId), nameof(Player.FullName), vm.ComputerSpecification.PlayerId);
            return View(vm);
        }

        // POST: ComputerSpecifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComputerSpecificationCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.ComputerSpecifications.Update(vm.ComputerSpecification);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.PlayerSelectList = new SelectList(_uow.Players.GetAllForUser(User.Identity.GetUserId<int>()), nameof(Player.PlayerId), nameof(Player.FullName), vm.ComputerSpecification.PlayerId);
            return View(vm);
        }

        // GET: ComputerSpecifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerSpecification computerSpecification = _uow.ComputerSpecifications.GetById(id);
            if (computerSpecification == null)
            {
                return HttpNotFound();
            }
            return View(computerSpecification);
        }

        // POST: ComputerSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           _uow.ComputerSpecifications.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
