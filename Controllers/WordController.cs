using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDictionary.DBContext;
using MyDictionary.Interfaces;
using MyDictionary.Models;
using MyDictionary.Utils;
using MyDictionary.ViewModels;
using System.Text.Json;

namespace MyDictionary.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordsInterface _words;
        private readonly WordsDbContext _dbContext;

        public WordController(IWordsInterface words, WordsDbContext dbContext) 
        {
            _words = words;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Метод создания слова
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateWord()
        {
            var word = new Word();
           
            return View("EditWord", word);
        }

        /// <summary>
        /// Метод редактирования слова по его id
        /// </summary>
        /// <param name="wordId">id слова</param>
        /// <returns></returns>
        public IActionResult EditWord(int wordId)
        {
            var word = _words.GetWordById(wordId);

            return View(word);
        }

        /// <summary>
        /// Метод удаления слова по его id
        /// </summary>
        /// <param name="wordId">id слова</param>
        /// <returns></returns>
        public IActionResult DeleteWord(int wordId) 
        {
            var word = _words.GetWordById(wordId);
            _dbContext.Words.Remove(word);
            _dbContext.SaveChanges();

            return View("SuccessDelete", word);
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
        /// Метод вывода списка слов по запросу
        /// </summary>
        /// <param name="viewModel">вьюмодель для запроса слов</param>
        /// <returns></returns>
        public IActionResult GetWordsQueryResult(EditItemsViewModel viewModel)
        {
            var listWords = new List<Word>();
            listWords = _dbContext.Words.Where(x => 
                    (x.RusValue.Contains(viewModel.RusValue) || 
                     x.EngValue.Contains(viewModel.EngValue))).ToList();

            return View(listWords);
        }

        /// <summary>
        /// Метод сохранения слова
        /// </summary>
        /// <param name="word">сохраняемое слово</param>
        /// <param name="formValues">данные полей ввода из формы ввода</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveWord(Word word, IFormCollection formValues)
        {
            try
            {
                var transcription = formValues["insertText"].ToString();
                if (transcription != null) word.Transcription = transcription;

                if (word != null && word.Id == 0)
                {
                    _dbContext.Words.Add(word);
                    _dbContext.SaveChanges();
                    return View("Success", word);
                }
                else if(word != null && word.Id != 0)
                {
                    _dbContext.Entry(word).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return View("Success", word);  
                }
                return View("EditWord", word);
            }
            catch (Exception error)
            {
                var errorViewModel = new ErrorViewModel(error.Message);
                return View("Error", errorViewModel);
            }
        }

        /// <summary>
        /// метод вывода полной информации о слове
        /// </summary>
        /// <param name="word">слово</param>
        /// <returns></returns>
        public IActionResult WordDetails(int wordId)
        {
            var word = _words.GetWordById(wordId);

            return PartialView("AnswerCardPartial", word);
        }
    }
}
