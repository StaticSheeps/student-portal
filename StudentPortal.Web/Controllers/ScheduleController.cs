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
            return RedirectToAction("List");
        }
    }
}
