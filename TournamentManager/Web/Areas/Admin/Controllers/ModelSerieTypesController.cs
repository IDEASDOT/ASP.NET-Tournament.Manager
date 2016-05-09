using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ModelSerieTypesController : BaseController
    {
        private readonly IUOW _uow;
        //private DataBaseContext _uow = new DataBaseContext();

        public ModelSerieTypesController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: ModelSerieTypes
        public ActionResult Index()
        {
            var vm = new ModelSerieTypeIndexViewModel()
            {
                ModelSerieTypes = _uow.ModelSerieTypes.All
            };
            return View(vm);
        }

        // GET: ModelSerieTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerieType modelSerieType = _uow.ModelSerieTypes.GetById(id);
            if (modelSerieType == null)
            {
                return HttpNotFound();
            }
            return View(modelSerieType);
        }

        // GET: ModelSerieTypes/Create
        public ActionResult Create()
        {
            var vm = new ModelSerieTypeCreateEditViewModel();
            return View(vm);
        }

        // POST: ModelSerieTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ModelSerieTypeCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.ModelSerieTypes.Add(vm.ModelSerieType);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: ModelSerieTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerieType modelSerieType = _uow.ModelSerieTypes.GetById(id);
            if (modelSerieType == null)
            {
                return HttpNotFound();
            }
            var vm = new ModelSerieTypeCreateEditViewModel()
            {
                ModelSerieType = modelSerieType
            };
            return View(vm);
        }

        // POST: ModelSerieTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModelSerieTypeCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.ModelSerieTypes.Update(vm.ModelSerieType);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: ModelSerieTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerieType modelSerieType = _uow.ModelSerieTypes.GetById(id);
            if (modelSerieType == null)
            {
                return HttpNotFound();
            }
            return View(modelSerieType);
        }

        // POST: ModelSerieTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.ModelSerieTypes.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.ModelSerieTypes.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
