using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SubjectController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult ListSubject()
        {
            List<Subject> objSubjectList = _db.Subjects.ToList();
            return View(objSubjectList);
        }

        [HttpGet]
        public IActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSubject(Subject subject)
        {
            _db.Subjects.Add(subject);
            _db.SaveChanges();
            return RedirectToAction("ListSubject");

        }

        public IActionResult EditSubject(int subjectCode)
        {
            Subject? subjectFromDb = _db.Subjects.Find(subjectCode);
            if (subjectFromDb == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(subjectFromDb);
        }

        [HttpPost]
        public IActionResult EditSubject(Subject subject)
        {
            if (ModelState.IsValid && subject.SubjectCode > 0)
            {
                _db.Subjects.Update(subject);
                _db.SaveChanges();
                return RedirectToAction("ListSubject");
            }

            return View();

        }

        public IActionResult DeleteSubject(int subjectCode)
        {
            Subject? subjectFromDb = _db.Subjects.FirstOrDefault(u => u.SubjectCode == subjectCode);
            if (subjectFromDb is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(subjectFromDb);
        }

        [HttpPost]
        public IActionResult DeleteSubject(Subject subject)
        {
            Subject? subjectFromDb = _db.Subjects.FirstOrDefault(u => u.SubjectCode == subject.SubjectCode);
            if (subjectFromDb is not null)
            {
                _db.Subjects.Remove(subjectFromDb);
                _db.SaveChanges();
                TempData["success"] = "The Subject has been deleted successfully";
                return RedirectToAction("ListSubject");
            }
            TempData["error"] = "The Subject could not be deleted successfully";
            return View();
        }
    }
}
