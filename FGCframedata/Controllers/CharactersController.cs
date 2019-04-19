using FGCFrameData.Models;
using FGCFrameData.View_Models;
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

        // GET: character/1
        public ActionResult Index(int id)
        {
            
            var moves = _context.Moves.Where(m=>m.CharacterId == id).ToList();
            var characterName = _context.Characters.Single(c => c.Id == id).Name;

            return View(new MovesViewModel(moves, characterName));
        }
    }
}