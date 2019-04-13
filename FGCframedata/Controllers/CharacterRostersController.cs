using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FGCFrameData.Models;
using FGCFrameData.Utils;
using FGCFrameData.View_Models;

namespace FGCFrameData.Controllers
{
    public class CharacterRostersController : Controller
    {
       
        private ApplicationDbContext _context;

        public CharacterRostersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CharacterRosters
        public ActionResult Index()
        {
            var model = _context.CharacterRosters.ToList();
           
            return View(model);
        }

        public ActionResult New()
        {
            return View("CharacterRosterForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CharacterRoster characterRoster, HttpPostedFileBase photo)
        {
            
            if (!ModelState.IsValid)
            {
                var viewModel = new CharacterRosterFormViewModel
                {
                    CharacterRoster = characterRoster
                };
                return View("CharacterRosterForm", viewModel);
            }

            // TODO add error message for duplicates 
           
            var uploadHelper = new UploadHelper(Server);

            var filePath = uploadHelper.Upload(photo, nameof(CharacterRoster));
                   
            var characterRosterInDb = _context.CharacterRosters.SingleOrDefault(c => c.Id == characterRoster.Id) ??
                                      _context.CharacterRosters.Add(characterRoster);

            var characterRosterNnDbName =_context.CharacterRosters.SingleOrDefault(c => c.GameName == characterRoster.GameName);

            if (characterRosterNnDbName != null)
            {
                return RedirectToAction("New");
            }

            characterRosterInDb.GameName = characterRoster.GameName;
            if (!string.IsNullOrEmpty(filePath))
            {
                characterRosterInDb.ImagePath = filePath;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "CharacterRosters");
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            var characterRoster = _context.CharacterRosters.SingleOrDefault(c => c.Id == id);

            if (characterRoster == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CharacterRosterFormViewModel
            {
                CharacterRoster = characterRoster
            };
            return View("CharacterRosterForm", viewModel);
        }

        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var characterRosterInDb = _context.CharacterRosters.SingleOrDefault(c => c.Id == id);

            if (characterRosterInDb == null)
            {
                return HttpNotFound();
            }

            var characterRosterImage = Server.MapPath('/' + characterRosterInDb.ImagePath);

            if (System.IO.File.Exists(characterRosterImage))
            {
                System.IO.File.Delete(characterRosterImage);
            }

            _context.CharacterRosters.Remove(characterRosterInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "CharacterRosters");
        }
    }
}
