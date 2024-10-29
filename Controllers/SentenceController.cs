using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDictionary.DBContext;
using MyDictionary.Interfaces;
using MyDictionary.Models;
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
        /// Метод создания предложения
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateSentence()
        {
            var sentence = new Sentence();

            return View("EditSentence", sentence);
        }

        /// <summary>
        /// Метод редактирования предложения по его id
        /// </summary>
        /// <param name="sentencedId">id предложения</param>
        /// <returns></returns>
        public IActionResult EditSentence(int sentenceId)
        {
            var sentence = _sentences.GetSentenceById(sentenceId);

            // TODO: create view EditSentence
            return View(sentence);
        }

        /// <summary>
        /// Метод удаления предложения по его id
        /// </summary>
        /// <param name="sentenceId">id предложения</param>
        /// <returns></returns>
        public IActionResult DeleteSentence(int sentenceId)
        {
            var sentence = _sentences.GetSentenceById(sentenceId);
            _dbContext.Sentences.Remove(sentence);
            _dbContext.SaveChanges();

            return View("SuccessDelete", sentence);
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

        /// <summary>
        /// Метод вывода списка предложений по запросу
        /// </summary>
        /// <param name="viewModel">вьюмодель для запроса предложений</param>
        /// <returns></returns>
        public IActionResult GetSentencesQueryResult(EditItemsViewModel viewModel)
        {
            var listSentences = new List<Sentence>();
            listSentences = _dbContext.Sentences.Where(x =>
                    (x.RusValue.Contains(viewModel.RusValue) ||
                     x.EngValue.Contains(viewModel.EngValue))).ToList();

            return View(listSentences);
        }

        /// <summary>
        /// Метод сохранения предложения
        /// </summary>
        /// <param name="sentence">сохраняемое предложение</param>
        /// <param name="formValues">данные полей ввода из формы ввода</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveSentence(Sentence sentence, IFormCollection formValues)
        {
            try
            {
                if (sentence != null && sentence.Id == 0)
                {
                    _dbContext.Sentences.Add(sentence);
                    _dbContext.SaveChanges();
                    return View("Success", sentence);
                }
                else if (sentence != null && sentence.Id != 0)
                {
                    _dbContext.Entry(sentence).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return View("Success", sentence);
                }
                return View("EditSentence", sentence);
            }
            catch (Exception error)
            {
                var errorViewModel = new ErrorViewModel(error.Message);
                return View("Error", errorViewModel);
            }
        }
    }
}
