using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FGCframedata.Models;
using FGCframedata.View_Models;

namespace FGCframedata.Controllers
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

            // TODO relative path
            // TODO fix duplicate image names
            // TODO fixing duplicate entries
            const string directory = @"D:\FGC Frame Data Project\FGCframedata\FGCframedata\Content\AppFile\Images\";

            
            string filePath = null;

            if (photo != null && photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);



                filePath = Path.Combine(directory, fileName);
                photo.SaveAs(filePath);

            }
          
            var characterRosterInDb = _context.CharacterRosters.SingleOrDefault(c => c.Id == characterRoster.Id) ??
                                      _context.CharacterRosters.Add(characterRoster);

            characterRosterInDb.GameName = characterRoster.GameName;
            if (!string.IsNullOrEmpty(filePath))
            {
                characterRosterInDb.ImagePath = filePath;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "CharacterRosters");
        }

        
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
            return View("CharacterRosterForm",viewModel);
        }

        
        public ActionResult Delete(int id)
        {
            var characterRosterInDb = _context.CharacterRosters.SingleOrDefault(c => c.Id == id);

            if (characterRosterInDb == null)
            {
                return HttpNotFound();
            }

            _context.CharacterRosters.Remove(characterRosterInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "CharacterRosters");
        }
    }
}
