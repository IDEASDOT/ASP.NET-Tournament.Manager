using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManufactorerTypesController : BaseController
    {
        //private DataBaseContext _uow = new DataBaseContext();
        private readonly IUOW _uow;


        public ManufactorerTypesController(IUOW uow
        )
        {
            _uow = uow;
        }
        // GET: ManufactorerTypes
        public ActionResult Index()
        {
            return View(_uow.ManufactorerTypes.All);
        }

        // GET: ManufactorerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufactorerType manufactorerType = _uow.ManufactorerTypes.GetById(id);
            if (manufactorerType == null)
            {
                return HttpNotFound();
            }
            return View(manufactorerType);
        }

        // GET: ManufactorerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManufactorerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManufactorerType manufactorerType)
        {
            if (ModelState.IsValid)
            {
                _uow.ManufactorerTypes.Add(manufactorerType);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(manufactorerType);
        }

        // GET: ManufactorerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufactorerType manufactorerType = _uow.ManufactorerTypes.GetById(id);
            if (manufactorerType == null)
            {
                return HttpNotFound();
            }
            return View(manufactorerType);
        }

        // POST: ManufactorerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ManufactorerType manufactorerType)
        {
            if (ModelState.IsValid)
            {
               _uow.ManufactorerTypes.Update(manufactorerType);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(manufactorerType);
        }

        // GET: ManufactorerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufactorerType manufactorerType = _uow.ManufactorerTypes.GetById(id);
            if (manufactorerType == null)
            {
                return HttpNotFound();
            }
            return View(manufactorerType);
        }

        // POST: ManufactorerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.ManufactorerTypes.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
