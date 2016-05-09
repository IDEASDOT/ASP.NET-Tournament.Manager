using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class MapInfosController : BaseController
    {
        private readonly IUOW _uow;
        //private DataBaseContext _uow = new DataBaseContext();

        public MapInfosController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: MapInfos
        public ActionResult Index()
        {
            //var mapInfos = _uow.MapInfos.Include(m => m.Map).Include(m => m.Match);
            var vm = new MapInfoIndexViewModel()
            {
                MapInfos = _uow.MapInfos.AllIncluding()
            };

            return View(vm);
        }

        // GET: MapInfos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapInfo mapInfo = _uow.MapInfos.GetById(id);
            if (mapInfo == null)
            {
                return HttpNotFound();
            }
            return View(mapInfo);
        }

        // GET: MapInfos/Create
        public ActionResult Create()
        {
            var vm = new MapInfoCreateEditViewModel();
            vm.MapSelectList = new SelectList(_uow.Maps.All.Select(a => a.MapId));
            vm.MatchSelectList = new SelectList(_uow.Matches.All.Select(a => a.MatchId));
            return View(vm);
        }

        // POST: MapInfos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MapInfoCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.MapInfos.Add(vm.MapInfo);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            vm.MapSelectList = new SelectList(_uow.Maps.All.Select(a => a.MapId), vm.MapInfo.MapId);
            vm.MatchSelectList = new SelectList(_uow.Matches.All.Select(a => a.MatchId), vm.MapInfo.MatchId);
            return View(vm);
        }

        // GET: MapInfos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapInfo mapInfo = _uow.MapInfos.GetById(id);
            if (mapInfo == null)
            {
                return HttpNotFound();
            }
            var vm = new MapInfoCreateEditViewModel()
            {
                MapInfo = mapInfo
            };

            vm.MapSelectList = new SelectList(_uow.Maps.All.Select(a => a.MapName), vm.MapInfo.MapId);
            vm.MatchSelectList = new SelectList(_uow.Matches.All.Select(a => a.MatchId), vm.MapInfo.MatchId);
            return View(vm);
        }

        // POST: MapInfos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MapInfoCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.MapInfos.Update(vm.MapInfo);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.MapSelectList = new SelectList(_uow.Maps.All.Select(a => a.MapName), vm.MapInfo.MapId);
            vm.MatchSelectList = new SelectList(_uow.Matches.All.Select(a => a.MatchId), vm.MapInfo.MatchId);
            return View(vm);
        }

        // GET: MapInfos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapInfo mapInfo = _uow.MapInfos.GetById(id);
            if (mapInfo == null)
            {
                return HttpNotFound();
            }
            return View(mapInfo);
        }

        // POST: MapInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.MapInfos.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
