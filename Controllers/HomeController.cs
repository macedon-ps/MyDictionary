using Microsoft.AspNetCore.Mvc;
using MyDictionary.DBContext;
using MyDictionary.Interfaces;
using MyDictionary.Utils;
using MyDictionary.ViewModels;
using System.Text.Json;

namespace MyDictionary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWordsInterface _words;
        private readonly WordsDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, IWordsInterface words, WordsDbContext dbContext)
        {
            _logger = logger;
            _words = words;
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
        /// Метод рандомного выбора и проверки слов
        /// </summary>
        /// <returns></returns>
        public IActionResult CheckWords()
        {
            try
            {
                // получаем части речи либо по выбору пользователя, либо по дефолту
                var defoultPartOfSpeech = "[\"Noun\",\"Verb\",\"Adjective\",\"Adverb\"]";
                
                var partSpeechJson = HttpContext.Session.GetString("listPartOfSpeech") ?? defoultPartOfSpeech;
                var partSpeech = JsonSerializer.Deserialize<List<string>>(partSpeechJson);

                var randomWords = _words.GetRandomWords(partSpeech);
                
                var indexOfCheckedWord = WordsUtils.GetIndexCheckedWord(randomWords);

                var viewModel = new CheckWordsViewModel(randomWords, indexOfCheckedWord);

                return View(viewModel);
            }
            catch (Exception error)
            {
                var errorViewModel = new ErrorViewModel(error.Message);
                return View("Error", errorViewModel);
            }
        }

        /// <summary>
        /// Метод рандомного выбора и проверки слов (POST версия)
        /// </summary>
        /// <param name="idWord">индекс слова, кот. будет проверяться на правильный перевод</param>
        /// <param name="allQuestion">количество переведенных слов</param>
        /// <param name="goodAnswers">количество правильных ответов</param>
        /// <param name="badAnswers">количество неправильных ответо</param>
        /// <param name="grades">описание оценки</param>
        /// <param name="idSelectedAnswer">индекс слова - одного из многих вариантов перевода</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CheckWords(int idWord, int allQuestion, int goodAnswers, int badAnswers, string grades, int idSelectedAnswer)
        {
            try
            {
                // при нажатии на кнопку с вариантом ответа б. сгенерированы и отрендерены новые данные для списка слов и индекса выбранного слова (применятся в конце)
                // получаем части речи либо по выбору пользователя, либо по дефолту
                var defoultPartOfSpeech = "[\"Noun\",\"Verb\",\"Adjective\",\"Adverb\"]";

                var partSpeechJson = HttpContext.Session.GetString("listPartOfSpeech") ?? defoultPartOfSpeech;
                var partSpeech = JsonSerializer.Deserialize<List<string>>(partSpeechJson);

                var newRandomWords = _words.GetRandomWords(partSpeech);
                var newIndexOfCheckedWord = WordsUtils.GetIndexCheckedWord(newRandomWords);

                var viewModel = new CheckWordsViewModel(newRandomWords, newIndexOfCheckedWord, idWord, allQuestion, goodAnswers, badAnswers, grades, idSelectedAnswer);
             
                return View(viewModel);
            }
            catch (Exception error)
            {
                var errorViewModel = new ErrorViewModel(error.Message);
                return View("Error", errorViewModel);
            }
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

                return RedirectToAction("CheckWords", "Home");
            }
            catch (Exception error)
            {
                var errorViewModel = new ErrorViewModel(error.Message);
                return View("Error", errorViewModel);
            }
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

                var randomSentence = _words.GetRandomSentence(tences);
               
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

                var randomSentence = _words.GetRandomSentence(tences);

                var viewModel = new CheckSentencesViewModel(randomSentence, allQuestion, goodAnswers, badAnswers, grades, mark);

                return View(viewModel);
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
                var utils = new WordsUtils(_dbContext);

                // проверка, есть ли выбранные пользователем времена англ. языка в словах в БД
                var isMatchTences = utils.TestingOfUsersTencesChoose(tences);

                // TODO: проверка, есть ли хотя бы 5 слов по каждой из выбранных частей речи в БД
                var isMatchSentenceNumberOfTence = WordsUtils.TestingOfSentenceNumber(tences);

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

                return RedirectToAction("CheckSentences", "Home");
            }
            catch (Exception error)
            {
                var errorViewModel = new ErrorViewModel(error.Message);
                return View("Error", errorViewModel);
            }
        }

        /// <summary>
        /// Метод вывода страницы ввода, редактирования, удаления слов / предложений / грамматики
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {
            return View();
        }

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
