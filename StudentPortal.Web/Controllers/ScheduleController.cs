using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Web.Controllers
{
    public class ScheduleController : Controller
    {
        [HttpGet]
        public IActionResult AddSchedule()
        {
            return View();
        }
    }
}
