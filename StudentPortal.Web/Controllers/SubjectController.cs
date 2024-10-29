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
    }
}
