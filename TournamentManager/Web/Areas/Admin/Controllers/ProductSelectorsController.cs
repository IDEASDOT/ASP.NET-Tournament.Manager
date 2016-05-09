using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductSelectorsController : BaseController
    {
        private readonly IUOW _uow;
        //private DataBaseContext _uow = new DataBaseContext();

        public ProductSelectorsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: ProductSelectors
        public ActionResult Index()
        {
            var vm = new ProductSelectorIndexViewModel()
            {
                ProductSelectors = _uow.ProductSelectors.AllIncluding()
            };
            return View(vm);
        }

        // GET: ProductSelectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSelector productSelector = _uow.ProductSelectors.GetById(id);
            if (productSelector == null)
            {
                return HttpNotFound();
            }
            return View(productSelector);
        }

        // GET: ProductSelectors/Create
        public ActionResult Create()
        {
            var vm = new ProductSelectorCreateEditViewModel();
            vm.ManufactorerSelectList = new SelectList(_uow.Manufactorers.All.Select(a => a.ManufactorerId));
            vm.ManufactorerTypeSelectList = new SelectList(_uow.ManufactorerTypes.All.Select(a => a.ManufactorerTypeId));
            vm.ModelSerieSelectList = new SelectList(_uow.ModelSeries.All.Select(a => a.ModelSerieId));
            vm.ModelSerieTypeSelectList = new SelectList(_uow.ModelSerieTypes.All.Select(a => a.ModelSerieTypeId));

//            ViewBag.ManufactorerId = new SelectList(_uow.Manufactorers.All, "ManufactorerId", "ManufactorerName");
//            ViewBag.ManufactorerTypeId = new SelectList(_uow.ManufactorerTypes.All, "ManufactorerTypeId", "ManufactorerTypeName");
//            ViewBag.ModelSerieId = new SelectList(_uow.ModelSeries.All, "ModelSerieId", "ModelSerieName");
//            ViewBag.ModelSerieTypeId = new SelectList(_uow.ModelSerieTypes.All, "ModelSerieTypeId", "ModelSerieTypeName");
            return View(vm);
        }

        // POST: ProductSelectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductSelectorCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.ProductSelectors.Add(vm.ProductSelector);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            vm.ManufactorerSelectList = new SelectList(_uow.Manufactorers.All.Select(a => a.ManufactorerId), vm.ProductSelector.ManufactorerId);
            vm.ManufactorerTypeSelectList = new SelectList(_uow.ManufactorerTypes.All.Select(a => a.ManufactorerTypeId), vm.ProductSelector.ManufactorerTypeId);
            vm.ModelSerieSelectList = new SelectList(_uow.ModelSeries.All.Select(a => a.ModelSerieId), vm.ProductSelector.ModelSerieId);
            vm.ModelSerieTypeSelectList = new SelectList(_uow.ModelSerieTypes.All.Select(a => a.ModelSerieTypeId), vm.ProductSelector.ModelSerieTypeId); 
            return View(vm);
        }

        // GET: ProductSelectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSelector productSelector = _uow.ProductSelectors.GetById(id);
            if (productSelector == null)
            {
                return HttpNotFound();
            }
            var vm = new ProductSelectorCreateEditViewModel()
            {
                ProductSelector = productSelector
            };
            vm.ManufactorerSelectList = new SelectList(_uow.Manufactorers.All.Select(a => a.ManufactorerId), vm.ProductSelector.ManufactorerId);
            vm.ManufactorerTypeSelectList = new SelectList(_uow.ManufactorerTypes.All.Select(a => a.ManufactorerTypeId), vm.ProductSelector.ManufactorerTypeId);
            vm.ModelSerieSelectList = new SelectList(_uow.ModelSeries.All.Select(a => a.ModelSerieId), vm.ProductSelector.ModelSerieId);
            vm.ModelSerieTypeSelectList = new SelectList(_uow.ModelSerieTypes.All.Select(a => a.ModelSerieTypeId), vm.ProductSelector.ModelSerieTypeId);
            return View(vm);
        }

        // POST: ProductSelectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductSelectorCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.ProductSelectors.Update(vm.ProductSelector);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.ManufactorerSelectList = new SelectList(_uow.Manufactorers.All.Select(a => a.ManufactorerId), vm.ProductSelector.ManufactorerId);
            vm.ManufactorerTypeSelectList = new SelectList(_uow.ManufactorerTypes.All.Select(a => a.ManufactorerTypeId), vm.ProductSelector.ManufactorerTypeId);
            vm.ModelSerieSelectList = new SelectList(_uow.ModelSeries.All.Select(a => a.ModelSerieId), vm.ProductSelector.ModelSerieId);
            vm.ModelSerieTypeSelectList = new SelectList(_uow.ModelSerieTypes.All.Select(a => a.ModelSerieTypeId), vm.ProductSelector.ModelSerieTypeId);
            return View(vm);
        }

        // GET: ProductSelectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSelector productSelector = _uow.ProductSelectors.GetById(id);
            if (productSelector == null)
            {
                return HttpNotFound();
            }
            return View(productSelector);
        }

        // POST: ProductSelectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            _uow.ProductSelectors.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}