using MyDictionary.DBContext;
using MyDictionary.Interfaces;
using MyDictionary.Models;
using MyDictionary.Utils;
using MyDictionary.ViewModels;

namespace MyDictionary.Repository
{
    public class WordsRepository : IWordsInterface
    {
        private readonly WordsDbContext _dbContext;
        public WordsRepository(WordsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Методы для слов

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
            
            for (int i = 0; i < number; i++)
            {
                var isAddedNewWord = false;

                while (!isAddedNewWord)
                {
                    var randomWord = GetOneRandomWord(numberOfPartOfSpeech);

                    if (!randomWordsList.Contains(randomWord))
                    {
                        randomWordsList.Add(randomWord);
                        isAddedNewWord = true;
                    }
                }
            }
            return randomWordsList;
        }

        /// <summary>
        /// Метод рандомного создания одного слова
        /// </summary>
        /// <param name="numberOfPartOfSpeech">заданная часть речи</param>
        /// <returns></returns>
        public Word GetOneRandomWord(int numberOfPS)
        {
            var rand = new Random();
            var numberWodrsOfPS = GetNumberOfWordsOfPS(numberOfPS);
            var randomWordNumber = rand.Next(numberWodrsOfPS);

            var arrayOfPSWordsIndexes = GetArrayOfPSWordsIndexes(numberOfPS);
            var randomWordIndex = arrayOfPSWordsIndexes[randomWordNumber];

            var word = _dbContext.Words.FirstOrDefault(x => x.Id == randomWordIndex);

            return word;
        }

        /// <summary>
        /// Метод получения слова по его идентификатору
        /// </summary>
        /// <param name="wordId">идентификатор слова</param>
        /// <returns></returns>
        public Word GetWordById(int wordId)
        {
            return _dbContext.Words.FirstOrDefault(x => x.Id == wordId) ?? new Word();
        }

        /// <summary>
        /// Метод создания массива идентификаторов слов заданной части речи
        /// </summary>
        /// <param name="numberOfPS">номер заданной части речи</param>
        /// <returns></returns>
        public int[] GetArrayOfPSWordsIndexes(int numberOfPS)
        {
            var listWordsOfPS = GetListWordsOfPS(numberOfPS);
            var arraySize = listWordsOfPS.Count;
            
            var arrayOfPSWordsIndexes = new int[arraySize];
            var i = 0;

            foreach ( var word in listWordsOfPS)
            {
                arrayOfPSWordsIndexes[i] = word.Id;
                i++;
            }
            return arrayOfPSWordsIndexes;
        }

        /// <summary>
        /// Метод получения количества всех слов заданной части речи в БД
        /// </summary>
        /// <param name="numberOfPartOfSpeech">номер заданной части речи</param>
        /// <returns></returns>
        public int GetNumberOfWordsOfPS(int numberOfPartOfSpeech)
        {
            return _dbContext.Words.Where(x => (int)x.PartOfSpeech == numberOfPartOfSpeech).Count();
        }

        /// <summary>
        /// Метод получения коллекции слов заданной части речи в БД
        /// </summary>
        /// <param name="numberOfPartOfSpeech">номер заданной части речи</param>
        /// <returns></returns>
        public List<Word> GetListWordsOfPS(int numberOfPartOfSpeech)
        {
            return _dbContext.Words.Where(x => (int)x.PartOfSpeech == numberOfPartOfSpeech).ToList();
        }
    }
}
