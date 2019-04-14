using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FGCFrameData.Models;
using FGCFrameData.Utils;
using FGCFrameData.View_Models;
using System.Data.Entity;

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

        // GET: Characters
        public ActionResult Index()
        {
            var model = _context.Characters.Include(g=>g.CharacterRoster).ToList();

            return View(model);
        }

        public ActionResult New()
        {
            var characterRosters = _context.CharacterRosters.ToList();

            var viewModel = new CharacterFormViewModel
            {
                Character = new Character(),
                CharacterRoster = characterRosters
            };

            return View("CharacterForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Character character, HttpPostedFileBase photo)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CharacterFormViewModel
                {
                    Character = character
                };
                return View("CharacterForm", viewModel);
            }

            var uploadHelper = new UploadHelper(Server);

            var filePath = uploadHelper.Upload(photo, nameof(Character));

            var characterInDb = _context.Characters.SingleOrDefault(c => c.Id == character.Id) ??
                                      _context.Characters.Add(character);

            var characterInDbName = _context.Characters.SingleOrDefault(c => c.Name == character.Name);

            if (characterInDbName != null)
            {
                return RedirectToAction("New");
            }

            characterInDb.Name = character.Name;
            if (!string.IsNullOrEmpty(filePath))
            {
                characterInDb.ImagePath = filePath;
            }

            
            _context.SaveChanges();
            return RedirectToAction("Index", "Characters");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);

            if (character == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CharacterFormViewModel()
            {
                Character = character,
                CharacterRoster = _context.CharacterRosters.ToList()
            };
            return View("CharacterForm", viewModel);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var characterInDb = _context.Characters.SingleOrDefault(c => c.Id == id);

            if (characterInDb == null)
            {
                return HttpNotFound();
            }

            var characterImage = Server.MapPath('/' + characterInDb.ImagePath);

            if (System.IO.File.Exists(characterImage))
            {
                System.IO.File.Delete(characterImage);
            }

            _context.Characters.Remove(characterInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Characters");
        }
    }
}