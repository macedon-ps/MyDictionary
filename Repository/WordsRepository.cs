using Microsoft.EntityFrameworkCore;
using MyDictionary.DBContext;
using MyDictionary.Interfaces;
using MyDictionary.Models;
using MyDictionary.Utils;
using MyDictionary.ViewModels;

namespace MyDictionary.Repository
{
    public class WordsRepository : IWordsInterface
    {
        private readonly WordsDbContext _dbWords;
        
        public WordsRepository(WordsDbContext dbWords)
        {
            _dbWords = dbWords;
        }
            
        /// <summary>
        /// Метод рандомного создания коллекции слов одной части речи, состоящей из заданного количества слов
        /// </summary>
        /// <param name="number">заданное количество слов в коллекции</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Word> GetRandomWords()
        {
            //1. Рандомный выбор части речи
            var numberOfPartOfSpeech = WordsUtils.RandomChooseOfPartOfSpeach();

            // 2. Определение количества вариантов ответа
            var number = new CheckWordsViewModel().GetNumberOfWords();

            // 3. Создание коллекции слов List<Word> в количестве number слов
            var randomWordsList = new List<Word>();
            var utils = new WordsUtils(_dbWords);

            for (int i = 0; i < number; i++)
            {
                var isAddedNewWord = false;

                while (!isAddedNewWord)
                {
                    
                    var randomWord = utils.GetRandomWord();
                        
                    if ((int)randomWord.PartOfSpeech == numberOfPartOfSpeech && !randomWordsList.Contains(randomWord))
                    {
                        randomWordsList.Add(randomWord);
                        isAddedNewWord = true;
                    }
                }
            }
            return randomWordsList;
        }

        /// <summary>
        /// Метод рандомного создания коллекции слов одной или нескольких частей речи, состоящей из заданного количества слов
        /// </summary>
        /// <param name="partSpeech">список частей речи, выбранных пользователем</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Word> GetRandomWords(List<string> partSpeech)
        {
            //1. Рандомный выбор части речи
            var numberOfPartOfSpeech = WordsUtils.RandomChooseOfPartOfSpeach(partSpeech);

            // 2. Определение количества вариантов ответа
            var number = new CheckWordsViewModel().GetNumberOfWords();

            // 3. Создание коллекции слов List<Word> в количестве number слов
            var randomWordsList = new List<Word>();
            var utils = new WordsUtils(_dbWords);

            for (int i = 0; i < number; i++)
            {
                var isAddedNewWord = false;

                while (!isAddedNewWord)
                {
                    var randomWord = utils.GetRandomWord();

                    if ((int)randomWord.PartOfSpeech == numberOfPartOfSpeech && !randomWordsList.Contains(randomWord))
                    {
                        randomWordsList.Add(randomWord);
                        isAddedNewWord = true;
                    }
                }
            }
            return randomWordsList;
        }
                
        public List<Word> GetAllWords()
        {
            var allWords = _dbWords.Words.ToList();

            return allWords;
        }

        public List<Word> GetWordsByPartOfSpeech(PartsOfSpeech partOfSpeech)
        {
            throw new NotImplementedException();
        }

        public Word GetWordById(int id)
        {
            throw new NotImplementedException();
        }

        public Word GetWordByRusValue(string rusValue)
        {
            throw new NotImplementedException();
        }

        public Word GetWordByEngValue(string engValue)
        {
            throw new NotImplementedException();
        }

        public void SaveWoord(Word word, int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteWoord(Word word, int id)
        {
            throw new NotImplementedException();
        }

        public List<Sentence> GetAllSentences()
        {
            throw new NotImplementedException();
        }

        public List<Word> GetSentencesByTence(Tenses tence)
        {
            throw new NotImplementedException();
        }

        public Word GetSentenceById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveSentence(Word word, int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSentence(Word word, int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
