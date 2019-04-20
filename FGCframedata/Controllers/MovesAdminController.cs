using FGCFrameData.Models;
using FGCFrameData.View_Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FGCFrameData.Controllers
{
    public class MovesAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovesAdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Characters
        public ActionResult Index()
        {
            var model = _context.Moves.Include(g => g.Character).ToList();

            return View(model);
        }

        public ActionResult New()
        {
            var character = _context.Characters.ToList();

            var viewModel = new MoveFormViewModel()
            {
                Move = new Move(),
                Character = character
            };

            return View("MoveForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Move move)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MoveFormViewModel()
                {
                    Move = move
                };
                return View("MoveForm", viewModel);
            }

            var moveInDb = _context.Moves.SingleOrDefault(c => c.Id == move.Id) ??
                                      _context.Moves.Add(move);

            var moveInDbName = _context.Moves.FirstOrDefault(c => c.Name == move.Name);

            if (moveInDbName != null && moveInDbName.CharacterId == move.CharacterId)
            {
                return RedirectToAction("New");
            }

            moveInDb.Name = move.Name;

            _context.SaveChanges();
            return RedirectToAction("Index", "MovesAdmin");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var move = _context.Moves.SingleOrDefault(c => c.Id == id);

            if (move == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MoveFormViewModel()
            {
                Move = move,
                Character = _context.Characters.ToList()
            };
            return View("MoveForm", viewModel);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var moveInDb = _context.Moves.SingleOrDefault(c => c.Id == id);

            if (moveInDb == null)
            {
                return HttpNotFound();
            }

            _context.Moves.Remove(moveInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "MovesAdmin");
        }
    }
}