using Microsoft.AspNetCore.Mvc;

namespace Contacts.MVC.Controllers
{
    public class ReadController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
