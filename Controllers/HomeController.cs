using Microsoft.AspNetCore.Mvc;
using MyDictionary.DBContext;
using MyDictionary.Interfaces;
using MyDictionary.Models;
using MyDictionary.Utils;
using MyDictionary.ViewModels;
using System.Text.Json;

namespace MyDictionary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WordsDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, IWordsInterface words, WordsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Метод вывода стартовой страницы
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Метод вывода модального окна с выбором частей речи
        /// </summary>
        /// <returns></returns>
        public IActionResult GetPartOfSpeech()
        {
            return PartialView("ChoosePartOfSpeechPartial");
        }

        /// <summary>
        /// Метод вывода модального окна с выбором частей речи (POST версия)
        /// </summary>
        /// <param name="partSpeech">коллекция частей речи по выбору пользователя</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetPartOfSpeech(List<string> partSpeech)
        {
            try
            {
                var utils = new WordsUtils(_dbContext);

                // проверка, есть ли выбранные пользователем части речи в словах в БД
                var isMatchPartsOfSpeech = utils.TestingOfUsersPSChoose(partSpeech);

                // TODO: проверка, есть ли хотя бы 5 слов по каждой из выбранных частей речи в БД
                var isMatchWordsNumberOfPartOfSpeech = WordsUtils.TestingOfWordsNumber(partSpeech);

                if (isMatchPartsOfSpeech && isMatchWordsNumberOfPartOfSpeech)
                {
                    var partSpeechJson = JsonSerializer.Serialize(partSpeech);

                    // устанавливаем переменную сесии partSpeechJson
                    HttpContext.Session.SetString("listPartOfSpeech", partSpeechJson);
                }
                else
                {
                    var errorViewModel = new ErrorViewModel("К сожалению, не все выбранные части речи представлены примерами слов в БД");
                    return View("Error", errorViewModel);
                }

                return RedirectToAction("CheckWords", "Word");
            }
            catch (Exception error)
            {
                var errorViewModel = new ErrorViewModel(error.Message);
                return View("Error", errorViewModel);
            }
        }

        /// <summary>
        /// Метод вывода модального окна с выбором времен англ. языка
        /// </summary>
        /// <returns></returns>
        public IActionResult GetTence()
        {
            return PartialView("ChooseTencePartial");
        }

        /// <summary>
        /// Метод вывода модального окна с выбором времен англ. языка (POST версия)
        /// </summary>
        /// <param name="tences">коллекция времен англ. языка по выбору пользователя</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetTence(List<string> tences)
        {
            try
            {
                var utils = new SentencesUtils(_dbContext);

                // проверка, есть ли выбранные пользователем времена англ. языка в словах в БД
                var isMatchTences = utils.TestingOfUsersTencesChoose(tences);

                // TODO: проверка, есть ли хотя бы 5 слов по каждой из выбранных частей речи в БД
                var isMatchSentenceNumberOfTence = SentencesUtils.TestingOfSentenceNumber(tences);

                if (isMatchTences && isMatchSentenceNumberOfTence)
                {
                    var tencesJson = JsonSerializer.Serialize(tences);

                    // устанавливаем переменную сесии partSpeechJson
                    HttpContext.Session.SetString("listTences", tencesJson);
                }
                else
                {
                    var errorViewModel = new ErrorViewModel("К сожалению, не все выбранные времена англ. языка представлены примерами слов в БД");
                    return View("Error", errorViewModel);
                }

                return RedirectToAction("CheckSentences", "Sentence");
            }
            catch (Exception error)
            {
                var errorViewModel = new ErrorViewModel(error.Message);
                return View("Error", errorViewModel);
            }
        }
    }
}
