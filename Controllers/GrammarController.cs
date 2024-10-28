using Microsoft.AspNetCore.Mvc;

namespace MyDictionary.Controllers
{
    public class GrammarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
