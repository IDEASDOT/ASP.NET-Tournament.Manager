using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class PieceInComputersController : BaseController
    {
        private readonly IUOW _uow;
        //private DataBaseContext _uow = new DataBaseContext();

        public PieceInComputersController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: PieceInComputers
        public ActionResult Index()
        {
            var vm = new PieceInComputerIndexViewModel()
            {
                PieceInComputers = _uow.PieceInComputers.AllIncluding()
            };
            //var pieceInComputers = _uow.PieceInComputers.Include(p => p.ComputerSpecification).Include(p => p.ProductSelector);
            return View(vm);
        }

        // GET: PieceInComputers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieceInComputer pieceInComputer = _uow.PieceInComputers.GetById(id);
            if (pieceInComputer == null)
            {
                return HttpNotFound();
            }
            return View(pieceInComputer);
        }

        // GET: PieceInComputers/Create
        public ActionResult Create()
        {
            var vm = new PieceInComputerCreateEditViewModel();
            vm.ComputerSpecificationSelectList = new SelectList(_uow.ComputerSpecifications.All.Select(a => a.CompSpecId));
            vm.ProductSelectorSelectList = new SelectList(_uow.ProductSelectors.All.Select(a => a.ProductSelectorId));
            return View(vm);
        }

        // POST: PieceInComputers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PieceInComputerCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.PieceInComputers.Add(vm.PieceInComputer);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            vm.ComputerSpecificationSelectList = new SelectList(_uow.ComputerSpecifications.All.Select(a => a.CompSpecId), vm.PieceInComputer.CompSpecId);
            vm.ProductSelectorSelectList = new SelectList(_uow.ProductSelectors.All.Select(a => a.ProductSelectorId), vm.PieceInComputer.ProductSelectorId);
            return View(vm);
        }

        // GET: PieceInComputers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieceInComputer pieceInComputer = _uow.PieceInComputers.GetById(id);
            if (pieceInComputer == null)
            {
                return HttpNotFound();
            }
            var vm = new PieceInComputerCreateEditViewModel()
            {
                PieceInComputer = pieceInComputer
            };
            vm.ComputerSpecificationSelectList = new SelectList(_uow.ComputerSpecifications.All.Select(a => a.CompSpecId), vm.PieceInComputer.CompSpecId);
            vm.ProductSelectorSelectList = new SelectList(_uow.ProductSelectors.All.Select(a => a.ProductSelectorId), vm.PieceInComputer.ProductSelectorId);
            return View(vm);
        }

        // POST: PieceInComputers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PieceInComputerCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.PieceInComputers.Update(vm.PieceInComputer);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            vm.ComputerSpecificationSelectList = new SelectList(_uow.ComputerSpecifications.All.Select(a => a.CompSpecId), vm.PieceInComputer.CompSpecId);
            vm.ProductSelectorSelectList = new SelectList(_uow.ProductSelectors.All.Select(a => a.ProductSelectorId), vm.PieceInComputer.ProductSelectorId);
            return View(vm);
        }

        // GET: PieceInComputers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieceInComputer pieceInComputer = _uow.PieceInComputers.GetById(id);
            if (pieceInComputer == null)
            {
                return HttpNotFound();
            }
            return View(pieceInComputer);
        }

        // POST: PieceInComputers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.PieceInComputers.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

    }
}