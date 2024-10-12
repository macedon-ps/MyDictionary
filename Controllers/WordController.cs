using Microsoft.AspNetCore.Mvc;
using MyDictionary.Models;
using System.Reflection.Metadata;

namespace MyDictionary.Controllers
{
    public class WordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateWord()
        {
            var word = new Word();
           
            return View("EditWord", word);
        }

        public IActionResult EditWord()
        {
            return View();
        }

        public IActionResult DeleteWord() 
        {
            return View();
        }

        public IActionResult SaveWord(Word word)
        {
            return View();
        }
    }
}
