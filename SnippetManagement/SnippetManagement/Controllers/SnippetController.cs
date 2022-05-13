using Microsoft.AspNetCore.Mvc;

namespace SnippetManagement.Controllers
{
    public class SnippetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
