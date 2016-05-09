using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManufactorersController : BaseController
    {
        
        //private DataBaseContext _uow = new DataBaseContext();
        private readonly IUOW _uow;

        public ManufactorersController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Manufactorers
        public ActionResult Index()
        {
            var vm = new ManufactorerIndexViewModel()
            {
                Manufactorers = _uow.Manufactorers.All
            };
            return View(vm);
        }

        // GET: Manufactorers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufactorer manufactorer = _uow.Manufactorers.GetById(id);
            if (manufactorer == null)
            {
                return HttpNotFound();
            }
            return View(manufactorer);
        }

        // GET: Manufactorers/Create
        public ActionResult Create()
        {
            var vm = new ManufactorerCreateEditViewModel();
            return View(vm);
        }

        // POST: Manufactorers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //TODO fix this shit
        public ActionResult Create( ManufactorerCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Manufactorers.Add(vm.Manufactorer);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Manufactorers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufactorer manufactorer = _uow.Manufactorers.GetById(id);
            if (manufactorer == null)
            {
                return HttpNotFound();
            }
            var vm = new ManufactorerCreateEditViewModel()
            {
                Manufactorer = manufactorer
            };
            return View(vm);
        }

        // POST: Manufactorers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ManufactorerCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Manufactorers.Update(vm.Manufactorer);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Manufactorers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufactorer manufactorer = _uow.Manufactorers.GetById(id);
            if (manufactorer == null)
            {
                return HttpNotFound();
            }
            return View(manufactorer);
        }

        // POST: Manufactorers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Manufactorers.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
