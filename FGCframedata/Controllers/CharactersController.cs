using FGCFrameData.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FGCFrameData.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharactersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CharacterRosters/1
        public ActionResult Index(int id)
        {
            var moveList = new List<Move>();
            var moves = _context.Moves.ToList();

            foreach (var move in moves)
            {
                if (move.CharacterId == id)
                {
                    moveList.Add(move);
                }

            }
            return View(moveList);
        }
    }
}