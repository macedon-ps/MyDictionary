using Microsoft.AspNetCore.Mvc;
using MyDictionary.Models;
using MyDictionary.ViewModels;

namespace MyDictionary.Controllers
{
    public class EditController : Controller
    {
        /// <summary>
        /// Метод вывода страницы ввода, редактирования, удаления слов / предложений / грамматики
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(string type = "Word")
        {
            var model = new EditItemsViewModel(type);

            return View(model);
        }

    }
}
