using Microsoft.AspNetCore.Mvc;
using MyDictionary.Models;

namespace MyDictionary.Controllers
{
    public class EditController : Controller
    {
        /// <summary>
        /// Метод вывода страницы ввода, редактирования, удаления слов / предложений / грамматики
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var model = new Word();

            return View(model);
        }


    }
}
