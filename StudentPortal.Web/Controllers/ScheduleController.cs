using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ScheduleController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult ListSchedule()
        {
            List<Schedule> objScheduleList = _db.Schedules.ToList();
            return View(objScheduleList);
        }

        [HttpGet]
        public IActionResult AddSchedule()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSchedule(Schedule schedule)
        {
            _db.Schedules.Add(schedule);
            _db.SaveChanges();
            return RedirectToAction("ListSchedule");
        }

        public IActionResult EditSchedule(string Days)
        {
            Schedule? scheduleFromDb = _db.Schedules.Find(Days);
            if (scheduleFromDb == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(scheduleFromDb);
        }

        [HttpPost]
        public IActionResult EditSchedule(Schedule schedule)
        {
            if (ModelState.IsValid && schedule.Days != null)
            {
                _db.Schedules.Update(schedule);
                _db.SaveChanges();
                return RedirectToAction("ListSchedule");
            }

            return View();

        }

        public IActionResult DeleteSchedule(string Days)
        {
            Schedule? scheduleFromDb = _db.Schedules.FirstOrDefault(u => u.Days == Days);
            if (scheduleFromDb is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(scheduleFromDb);
        }

        [HttpPost]
        public IActionResult DeleteSchedule(Schedule schedule)
        {
            Schedule? scheduleFromDb = _db.Schedules.FirstOrDefault(u => u.Days == schedule.Days);
            if (scheduleFromDb is not null)
            {
                _db.Schedules.Remove(scheduleFromDb);
                _db.SaveChanges();
                TempData["success"] = "The Schedule has been deleted successfully";
                return RedirectToAction("ListSchedule");
            }
            TempData["error"] = "The Schedule could not be deleted successfully";
            return View();
        }
    }
}
