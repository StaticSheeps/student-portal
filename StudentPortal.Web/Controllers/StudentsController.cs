using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult List()
        {
            List<Student> objStudentList = _db.Students.ToList();
            return View(objStudentList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return RedirectToAction("List");

        }

        public IActionResult Edit(int studentId)
        {
            Student? studentFromDb = _db.Students.Find(studentId);
            if (studentFromDb == null)
            {
                return RedirectToAction("Error", "Home");
                // return NotFound();
            }
            return View(studentFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid && student.Id > 0)
            {
                _db.Students.Update(student);
                _db.SaveChanges();
                return RedirectToAction("List");
            }

            return View();

        }
        public IActionResult Delete(int studentId)
        {
            Student? studentFromDb = _db.Students.FirstOrDefault(u => u.Id == studentId);
            if (studentFromDb is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(studentFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            Student? studentFromDb = _db.Students.FirstOrDefault(u => u.Id == student.Id);
            if (studentFromDb is not null)
            {
                _db.Students.Remove(studentFromDb);
                _db.SaveChanges();
                TempData["success"] = "The student has been deleted successfully";
                return RedirectToAction("List");
            }
            TempData["error"] = "The student could not be deleted successfully";
            return View();

        }
    }
}
