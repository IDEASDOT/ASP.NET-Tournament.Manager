using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ModelSeriesController : BaseController
    {
        private readonly IUOW _uow;
        //private DataBaseContext _uow = new DataBaseContext();

        public ModelSeriesController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: ModelSeries
        public ActionResult Index()
        {
            var vm = new ModelSerieIndexViewModel()
            {
                ModelSeries = _uow.ModelSeries.All
            };
            return View(vm);
        }

        // GET: ModelSeries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerie modelSerie = _uow.ModelSeries.GetById(id);
            if (modelSerie == null)
            {
                return HttpNotFound();
            }
            return View(modelSerie);
        }

        // GET: ModelSeries/Create
        public ActionResult Create()
        {
            var vm = new ModelSerieCreateEditViewModel();
            return View(vm);
        }

        // POST: ModelSeries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ModelSerieCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.ModelSeries.Add(vm.ModelSerie);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: ModelSeries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerie modelSerie = _uow.ModelSeries.GetById(id);
            if (modelSerie == null)
            {
                return HttpNotFound();
            }

            var vm = new ModelSerieCreateEditViewModel()
            {
                ModelSerie = modelSerie
            };

            return View(vm);
        }

        // POST: ModelSeries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModelSerieCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.ModelSeries.Update(vm.ModelSerie);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: ModelSeries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelSerie modelSerie = _uow.ModelSeries.GetById(id);
            if (modelSerie == null)
            {
                return HttpNotFound();
            }
            return View(modelSerie);
        }

        // POST: ModelSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            _uow.ModelSeries.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
