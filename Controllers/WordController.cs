using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDictionary.DBContext;
using MyDictionary.Interfaces;
using MyDictionary.Models;
using MyDictionary.ViewModels;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateWord()
        {
            var word = new Word();
           
            return View("EditWord", word);
        }

        public IActionResult EditWord(int wordId)
        {
            var word = _words.GetWordById(wordId);

            return View(word);
        }

        public IActionResult DeleteWord(int wordId) 
        {
            return View();
        }

        public IActionResult GetWordsQueryResult(EditItemsViewModel viewModel)
        {
            var listWords = new List<Word>();
            listWords = _dbContext.Words.Where(x => 
                    (x.RusValue.Contains(viewModel.RusValue) || 
                     x.EngValue.Contains(viewModel.EngValue))).ToList();

            return View(listWords);
        }

        [HttpPost]
        public IActionResult SaveWord(Word word)
        {
            try
            {
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
                    return View("UnSuccess", word);  
                }
                return View("EditWord", word);
            }
            catch (Exception error)
            {
                var errorViewModel = new ErrorViewModel(error.Message);
                return View("Error", errorViewModel);
            }
        }
    }
}
