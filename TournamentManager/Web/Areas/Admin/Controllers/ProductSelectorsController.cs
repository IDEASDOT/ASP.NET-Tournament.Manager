using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
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
            var productSelectors = _uow.ProductSelectors.AllIncluding();
            return View(productSelectors);
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
            ViewBag.ManufactorerId = new SelectList(_uow.Manufactorers.All, "ManufactorerId", "ManufactorerName");
            ViewBag.ManufactorerTypeId = new SelectList(_uow.ManufactorerTypes.All, "ManufactorerTypeId", "ManufactorerTypeName");
            ViewBag.ModelSerieId = new SelectList(_uow.ModelSeries.All, "ModelSerieId", "ModelSerieName");
            ViewBag.ModelSerieTypeId = new SelectList(_uow.ModelSerieTypes.All, "ModelSerieTypeId", "ModelSerieTypeName");
            return View();
        }

        // POST: ProductSelectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductSelector productSelector)
        {
            if (ModelState.IsValid)
            {
                _uow.ProductSelectors.Add(productSelector);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.ManufactorerId = new SelectList(_uow.Manufactorers.All, "ManufactorerId", "ManufactorerName", productSelector.ManufactorerId);
            ViewBag.ManufactorerTypeId = new SelectList(_uow.ManufactorerTypes.All, "ManufactorerTypeId", "ManufactorerTypeName", productSelector.ManufactorerTypeId);
            ViewBag.ModelSerieId = new SelectList(_uow.ModelSeries.All, "ModelSerieId", "ModelSerieName", productSelector.ModelSerieId);
            ViewBag.ModelSerieTypeId = new SelectList(_uow.ModelSerieTypes.All, "ModelSerieTypeId", "ModelSerieTypeName", productSelector.ModelSerieTypeId);
            return View(productSelector);
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
            ViewBag.ManufactorerId = new SelectList(_uow.Manufactorers.All, "ManufactorerId", "ManufactorerName", productSelector.ManufactorerId);
            ViewBag.ManufactorerTypeId = new SelectList(_uow.ManufactorerTypes.All, "ManufactorerTypeId", "ManufactorerTypeName", productSelector.ManufactorerTypeId);
            ViewBag.ModelSerieId = new SelectList(_uow.ModelSeries.All, "ModelSerieId", "ModelSerieName", productSelector.ModelSerieId);
            ViewBag.ModelSerieTypeId = new SelectList(_uow.ModelSerieTypes.All, "ModelSerieTypeId", "ModelSerieTypeName", productSelector.ModelSerieTypeId);
            return View(productSelector);
        }

        // POST: ProductSelectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductSelector productSelector)
        {
            if (ModelState.IsValid)
            {
                _uow.ProductSelectors.Update(productSelector);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.ManufactorerId = new SelectList(_uow.Manufactorers.All, "ManufactorerId", "ManufactorerName", productSelector.ManufactorerId);
            ViewBag.ManufactorerTypeId = new SelectList(_uow.ManufactorerTypes.All, "ManufactorerTypeId", "ManufactorerTypeName", productSelector.ManufactorerTypeId);
            ViewBag.ModelSerieId = new SelectList(_uow.ModelSeries.All, "ModelSerieId", "ModelSerieName", productSelector.ModelSerieId);
            ViewBag.ModelSerieTypeId = new SelectList(_uow.ModelSerieTypes.All, "ModelSerieTypeId", "ModelSerieTypeName", productSelector.ModelSerieTypeId);
            return View(productSelector);
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