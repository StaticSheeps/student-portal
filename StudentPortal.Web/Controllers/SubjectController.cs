using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Web.Controllers
{
    public class SubjectController : Controller
    {
        [HttpGet]
        public IActionResult AddSubject()
        {
            return View();
        }
    }
}
