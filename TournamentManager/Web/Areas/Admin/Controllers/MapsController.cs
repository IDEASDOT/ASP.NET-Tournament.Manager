using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MapsController : BaseController
    {
        //private DataBaseContext _uow = new DataBaseContext();
        private readonly IUOW _uow;

        public MapsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Maps
        public ActionResult Index()
        {
            var vm = new MapIndexViewModel() { 
               Maps =  _uow.Maps.All
            };
            return View(vm);
        }

        // GET: Maps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = _uow.Maps.GetById(id);
            if (map == null)
            {
                return HttpNotFound();
            }
            return View(map);
        }

        // GET: Maps/Create
        public ActionResult Create()
        {
            var vm = new MapCreateEditViewModel();
            return View(vm);
        }

        // POST: Maps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MapCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Maps.Add(vm.Map);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Maps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = _uow.Maps.GetById(id);
            if (map == null)
            {
                return HttpNotFound();
            }
            var vm = new MapCreateEditViewModel()
            {
                Map = map
            };
            return View(vm);
        }

        // POST: Maps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MapCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Maps.Update(vm.Map);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Maps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = _uow.Maps.GetById(id);
            if (map == null)
            {
                return HttpNotFound();
            }
            return View(map);
        }

        // POST: Maps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Maps.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        { 
        }
    }
}
