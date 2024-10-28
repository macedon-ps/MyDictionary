using MyDictionary.DBContext;
using MyDictionary.Interfaces;
using MyDictionary.Models;
using MyDictionary.Utils;

namespace MyDictionary.Repository
{
    public class SentencesRepository : ISentenceInterface
    {
        private readonly WordsDbContext _dbContext;
        public SentencesRepository(WordsDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        /// <summary>
        /// Метод рандомного предложения для заданной коллекции времен англ. языка
        /// </summary>
        /// <param name="englishTences">коллекция времен англ. языка</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Sentence GetRandomSentence(List<string> englishTences)
        {
            //1. Рандомный выбор времени англ. языка
            int numberOfTence = SentencesUtils.RandomChooseOfTence(englishTences);

            var sentence = GetRandomTenceSentence(numberOfTence);

            return sentence;
        }

        /// <summary>
        /// Метод рандомного выбора предложения для заданного времени англ. языка
        /// </summary>
        /// <param name="numberOfTence">время англ. языка</param>
        /// <returns></returns>
        public Sentence GetRandomTenceSentence(int numberOfTence)
        {
            var rand = new Random();
            var numberSentencesOfTence = GetNumberOfSentencesOfTence(numberOfTence);
            var randomSentenceNumber = rand.Next(numberSentencesOfTence);

            var arrayOfTenceSentencesIndexes = GetArrayOfTenceSentencesIndexes(numberOfTence);
            var randomSentenceIndex = arrayOfTenceSentencesIndexes[randomSentenceNumber];

            var sentence = _dbContext.Sentences.FirstOrDefault(x => x.Id == randomSentenceIndex);

            return sentence;
        }

        /// <summary>
        /// Метод создания массива идентификаторов слов заданного времени англ. языка
        /// </summary>
        /// <param name="numberOfTence">номер заданного времени англ. языка</param>
        /// <returns></returns>
        public int[] GetArrayOfTenceSentencesIndexes(int numberOfTence)
        {
            var listSentencesOfTence = GetListSentencesOfTence(numberOfTence);
            var arraySize = listSentencesOfTence.Count;

            var arrayOfSentencesIndex = new int[arraySize];
            var i = 0;

            foreach (var sentence in listSentencesOfTence)
            {
                arrayOfSentencesIndex[i] = sentence.Id;
                i++;
            }

            return arrayOfSentencesIndex;
        }

        /// <summary>
        /// Метод получения количества всех слов заданного времени англ. языка
        /// </summary>
        /// <param name="numberOfTence">номер заданного времени англ. языка</param>
        /// <returns></returns>
        public int GetNumberOfSentencesOfTence(int numberOfTence)
        {
            return _dbContext.Sentences.Where(x => (int)x.Tense == numberOfTence).Count();
        }

        /// <summary>
        /// Метод получения коллекции слов заданного времени англ. языка
        /// </summary>
        /// <param name="numberOfTence">номер заданного времени англ. языка</param>
        /// <returns></returns>
        public List<Sentence> GetListSentencesOfTence(int numberOfTence)
        {
            return _dbContext.Sentences.Where(x => (int)x.Tense == numberOfTence).ToList();
        }
    }
}
