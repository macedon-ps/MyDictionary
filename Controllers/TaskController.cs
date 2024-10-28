using Microsoft.AspNetCore.Mvc;

namespace MyDictionary.Controllers
{
    public class TaskController : Controller
    {
        /// <summary>
        /// Метод вывода общих задач
        /// </summary>
        /// <returns></returns>
        public IActionResult CommonTask()
        {
            return View();
        }

        /// <summary>
        /// Метод вывода задач страницы Home
        /// </summary>
        /// <returns></returns>
        public IActionResult HomeTask()
        {
            return View();
        }

        /// <summary>
        /// Метод вывода задач страницы Edit
        /// </summary>
        /// <returns></returns>
        public IActionResult EditTask()
        {
            return View();
        }
    }
}
