using Microsoft.AspNetCore.Mvc;
using MyDictionary.DBContext;
using MyDictionary.Interfaces;
using MyDictionary.ViewModels;
using System.Text.Json;

namespace MyDictionary.Controllers
{
    public class SentenceController : Controller
    {
        private readonly ISentenceInterface _sentences;
        private readonly WordsDbContext _dbContext;

        public SentenceController(ISentenceInterface sentences, WordsDbContext dbContext)
        {
            _sentences = sentences;
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// Метод рандомного выбора и проверки предложений
        /// </summary>
        /// <returns></returns>
        public IActionResult CheckSentences()
        {
            try
            {
                // получаем времена англ.языка либо по выбору пользователя, либо по дефолту
                var defoultEnglishTences = "[\"PresentSimple\",\"PastSimple\",\"FutureSimple\"]";

                var tencesJson = HttpContext.Session.GetString("listTences") ?? defoultEnglishTences;
                var tences = JsonSerializer.Deserialize<List<string>>(tencesJson);

                var randomSentence = _sentences.GetRandomSentence(tences);

                var viewModel = new CheckSentencesViewModel(randomSentence);

                return View(viewModel);
            }
            catch (Exception error)
            {
                var errorViewModel = new ErrorViewModel(error.Message);
                return View("Error", errorViewModel);
            }
        }

        [HttpPost]
        public IActionResult CheckSentences(int allQuestion, int goodAnswers, int badAnswers, string grades, string mark)
        {
            try
            {
                // получаем времена англ.языка либо по выбору пользователя, либо по дефолту
                var defoultEnglishTences = "[\"PresentSimple\",\"PastSimple\",\"FutureSimple\"]";

                var tencesJson = HttpContext.Session.GetString("listTences") ?? defoultEnglishTences;
                var tences = JsonSerializer.Deserialize<List<string>>(tencesJson);

                var randomSentence = _sentences.GetRandomSentence(tences);

                var viewModel = new CheckSentencesViewModel(randomSentence, allQuestion, goodAnswers, badAnswers, grades, mark);

                return View(viewModel);
            }
            catch (Exception error)
            {
                var errorViewModel = new ErrorViewModel(error.Message);
                return View("Error", errorViewModel);
            }
        }
    }
}
