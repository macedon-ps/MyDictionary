using Microsoft.AspNetCore.Mvc;
using MyDictionary.DBContext;
using MyDictionary.Interfaces;
using MyDictionary.Models;
using MyDictionary.Utils;
using MyDictionary.ViewModels;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        
        public IActionResult GetPartOfSpeech()
        {
            return PartialView("ChoosePartOfSpeechPartial");
        }

        [HttpPost]
        public IActionResult GetPartOfSpeech(List<string> partSpeech)
        {
            try
            {
                // TODO: проверка, есть ли выбранные пользователем части речи в словах в БД
                var utils = new WordsUtils(_dbContext);
                
                var isMatchPartsOfSpeech = utils.TestingOfUsersChoose(partSpeech);

                // TODO: проверка, есть ли хотя бы 5 слов по каждой из выбранных частей речи в БД
                var isMatchWordsNumberOfPartOfSpeech = WordsUtils.TestingOfWordsNumber(partSpeech);

                if(isMatchPartsOfSpeech && isMatchWordsNumberOfPartOfSpeech)
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
        /// Метод рандомного выбора и проверки слов
        /// </summary>
        /// <returns></returns>
        /*
        public IActionResult CheckWords()
        {
            var randomWords = _words.GetRandomWords();
            var indexOfCheckedWord = _words.GetIndexCheckedWord(randomWords);

            var viewModel = _words.GetCheckWordsViewModel(randomWords, indexOfCheckedWord);
  
            return View(viewModel);
        }*/

        public IActionResult CheckWords()
        {
            var partSpeechJson = HttpContext.Session.GetString("listPartOfSpeech");
            var partSpeech = JsonSerializer.Deserialize<List<string>>(partSpeechJson);

            var randomWords = new List<Word>();
            
            if(partSpeech == null)
            {
                randomWords = _words.GetRandomWords();
            }
            else
            {
                randomWords = _words.GetRandomWords(partSpeech);
            }
            
            var indexOfCheckedWord = WordsUtils.GetIndexCheckedWord(randomWords);

            var viewModel = new CheckWordsViewModel(randomWords, indexOfCheckedWord);

            return View(viewModel);
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

                var newRandomWords = _words.GetRandomWords();
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

        public IActionResult GetAllWords()
        {
            var words = _words.GetAllWords();
            return View(words);
        }

        public IActionResult CheckSentences()
        {
            var randomSentence = _words.GetRandomSentence();
            
            var viewModel = new CheckSentencesViewModel(randomSentence);

            return View(viewModel);
        }
    }
}
