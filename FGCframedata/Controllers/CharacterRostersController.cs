using FGCFrameData.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FGCFrameData.Controllers
{
    public class CharacterRostersController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CharacterRostersController()
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
            var characterList = new List<Character>();
            var characters = _context.Characters.ToList();

            foreach (var character in characters)
            {
                if (character.CharacterRosterId == id)
                {
                    characterList.Add(character);
                }

            }
            return View(characterList);
        }
    }
}