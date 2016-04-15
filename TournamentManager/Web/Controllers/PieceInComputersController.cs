using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;

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
            //var pieceInComputers = _uow.PieceInComputers.Include(p => p.ComputerSpecification).Include(p => p.ProductSelector);
            var pieceInComputers = _uow.PieceInComputers.AllIncluding();
            return View(pieceInComputers);
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
            ViewBag.CompSpecId = new SelectList(_uow.ComputerSpecifications.All, "CompSpecId", "OsName");
            ViewBag.ProductSelectorId = new SelectList(_uow.ProductSelectors.All, "ProductSelectorId", "ProductSelectorId");
            return View();
        }

        // POST: PieceInComputers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PieceInComputer pieceInComputer)
        {
            if (ModelState.IsValid)
            {
                _uow.PieceInComputers.Add(pieceInComputer);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.CompSpecId = new SelectList(_uow.ComputerSpecifications.All, "CompSpecId", "OsName", pieceInComputer.CompSpecId);
            ViewBag.ProductSelectorId = new SelectList(_uow.ProductSelectors.All, "ProductSelectorId", "ProductSelectorId", pieceInComputer.ProductSelectorId);
            return View(pieceInComputer);
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
            ViewBag.CompSpecId = new SelectList(_uow.ComputerSpecifications.All, "CompSpecId", "OsName", pieceInComputer.CompSpecId);
            ViewBag.ProductSelectorId = new SelectList(_uow.ProductSelectors.All, "ProductSelectorId", "ProductSelectorId", pieceInComputer.ProductSelectorId);
            return View(pieceInComputer);
        }

        // POST: PieceInComputers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PieceInComputer pieceInComputer)
        {
            if (ModelState.IsValid)
            {
                _uow.PieceInComputers.Update(pieceInComputer);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.CompSpecId = new SelectList(_uow.ComputerSpecifications.All, "CompSpecId", "OsName", pieceInComputer.CompSpecId);
            ViewBag.ProductSelectorId = new SelectList(_uow.ProductSelectors.All, "ProductSelectorId", "ProductSelectorId", pieceInComputer.ProductSelectorId);
            return View(pieceInComputer);
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