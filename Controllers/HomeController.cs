using Microsoft.AspNetCore.Mvc;
using MyDictionary.Interfaces;

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
        
        /// <summary>
        /// Метод рандомного выбора и проверки слов
        /// </summary>
        /// <returns></returns>
        public IActionResult CheckWords()
        {
            var randomWords = _words.GetRandomWords();
            var indexOfCheckedWord = _words.GetIndexCheckedWord(randomWords);

            var viewModel = _words.GetCheckWordsViewModel(indexOfCheckedWord, randomWords);
  
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
                var newIndexOfCheckedWord = _words.GetIndexCheckedWord(newRandomWords);

                var viewModel = _words.GetCheckWordsViewModel(idWord, allQuestion, goodAnswers, badAnswers, grades, idSelectedAnswer, newRandomWords, newIndexOfCheckedWord);
             
                return View(viewModel);
            }
            catch (Exception ex) 
            { 
                return View("Error", ex);
            }
            
        }

        public IActionResult GetAllWords()
        {
            var words = _words.GetAllWords();
            return View(words);
        }
    }
}
