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
            
            for (int i = 0; i < number; i++)
            {
                var isAddedNewWord = false;

                while (!isAddedNewWord)
                {
                    var randomWord = GetRandomWord();
                        
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
            
            for (int i = 0; i < number; i++)
            {
                var isAddedNewWord = false;

                while (!isAddedNewWord)
                {
                    var randomWord = GetRandomWord();

                    if ((int)randomWord.PartOfSpeech == numberOfPartOfSpeech && !randomWordsList.Contains(randomWord))
                    {
                        randomWordsList.Add(randomWord);
                        isAddedNewWord = true;
                    }
                }
            }
            return randomWordsList;
        }

        public Word GetRandomWord()
        {
            var rand = new Random();
            var numberOfAllWodrs = GetNumberOfAllWords();
            var randomWordNumber = rand.Next(numberOfAllWodrs);

            var arrayAllWordsIndex = GetArrayOfWordsIndex();
            var randomWordIndex = arrayAllWordsIndex[randomWordNumber];

            var word = _dbContext.Words.FirstOrDefault(x => x.Id == randomWordIndex);

            return word;
        }

        public List<Word> GetAllWords()
        {
            return _dbContext.Words.ToList();
        }

        public int GetNumberOfAllWords()
        {
            return _dbContext.Words.Count();
        }

        public int[] GetArrayOfWordsIndex()
        {
            var nuberOfWords = _dbContext.Words.Count();
            var arrayOfWordsIndex = new int[nuberOfWords];
            var allWords = _dbContext.Words.ToList();
            var i = 0;

            foreach (var word in allWords)
            {
                arrayOfWordsIndex[i] = word.Id;
                i++;
            }

            return arrayOfWordsIndex;
        }

        /* не реализовано
        public List<Word> GetWordsByPartOfSpeech(int partOfSpeech)
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
        */

        // Методы для предложений
        public Sentence GetRandomSentence()
        {
            //1. Рандомный выбор времени англ. языка
            int numberOfTence = WordsUtils.RandomChooseOfEnglishTence();

            var sentence = GetRandomSentenceByTence(numberOfTence);

            return sentence;
            
        }

        public Sentence GetRandomSentenceByTence(int numberOfTence)
        {
            var rand = new Random();
            var numberOfAllSentences = GetNumberOfAllSentences();
            var randomSentenceNumber = rand.Next(numberOfAllSentences);

            var arrayAllSentencesIndex = GetArrayOfSentencesIndex();
            var randomSentenceIndex = arrayAllSentencesIndex[randomSentenceNumber];

            var sentence = GetSentenceById(randomSentenceIndex);
            
            return sentence;
        }
        public List<Sentence> GetAllSentences()
        {
            return _dbContext.Sentences.ToList();
        }

        public Sentence GetSentenceById(int id)
        {
            return _dbContext.Sentences.FirstOrDefault(x => x.Id == id);
        }

        public int GetNumberOfAllSentences()
        {
            return _dbContext.Sentences.Count();
        }

        public int[] GetArrayOfSentencesIndex()
        {
            var nuberOfSentences = _dbContext.Sentences.Count();
            var arrayOfSentencesIndex = new int[nuberOfSentences];
            var allSentences = _dbContext.Sentences.ToList();
            var i = 0;

            foreach (var sentence in allSentences)
            {
                arrayOfSentencesIndex[i] = sentence.Id;
                i++;
            }

            return arrayOfSentencesIndex;
        }

        /* не реализовано 
        public List<Word> GetSentencesByTence(int tence)
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
         */
    }
}
