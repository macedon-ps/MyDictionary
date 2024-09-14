using Microsoft.AspNetCore.Mvc;
using MyDictionary.Interfaces;
using MyDictionary.Models;
using MyDictionary.ViewModels;
using System.Diagnostics;

namespace MyDictionary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWordsInterface _words;

        public HomeController(ILogger<HomeController> logger, IWordsInterface words)
        {
            _logger = logger;
            _words = words;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
        
        public IActionResult CommonTask()
        {
            return View();
        }
        
        public IActionResult HomeTask()
        {
            return View();
        }
        
        public IActionResult EditTask()
        {
            return View();
        }
        
        /// <summary>
        /// Метод рандомного выбора и проверки слов
        /// </summary>
        /// <returns></returns>
        public IActionResult CheckWords()
        {
            var interval = 5;

            var randomWords = _words.GetRandomWords(interval);
            var indexOfCheckedWord = _words.GetIndexCheckedWord(randomWords);

            var viewModel = new CheckWordsViewModel();
            viewModel.SelectedWords = randomWords;
            viewModel.IndexOfCheckedWord = indexOfCheckedWord;

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
