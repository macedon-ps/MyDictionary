using MyDictionary.DBContext;
using MyDictionary.Models;

namespace MyDictionary.Utils
{
    public class WordsUtils
    {

        private readonly WordsDbContext _dbContext;
        public WordsUtils(WordsDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }
                
        /// <summary>
        /// Метод рандомного определения части речи из тех, что выбраны пользователем
        /// </summary>
        /// <param name="partSpeech">список частей речи, выбранных пользователем</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static int RandomChooseOfPartOfSpeach(List<string> partSpeech)
        {
            // преобразование List<string> partSpeech в int[]
            var listSize = partSpeech.Count;
            var arraySelectedPS = new int[listSize];
            var numberOfPS = 0;

            var i = 0;
            foreach (var item in partSpeech)
            {
                switch (item)
                {
                    case "Noun":
                        numberOfPS = 0;
                        break;
                    case "Verb":
                        numberOfPS = 1;
                        break;
                    case "Adjective":
                        numberOfPS = 2;
                        break;
                    case "Adverb":
                        numberOfPS = 3;
                        break;
                    case "Pronoun":
                        numberOfPS = 4;
                        break;
                    case "Preposition":
                        numberOfPS = 5;
                        break;
                    case "Conjunction":
                        numberOfPS = 6;
                        break;
                    case "Interjection":
                        numberOfPS = 7;
                        break;
                }
                arraySelectedPS[i] = numberOfPS;
                i++;
            }

            var rand = new Random();
            var randomNumberOfPS = rand.Next(listSize);
            var numberPartOfSpeach = arraySelectedPS[randomNumberOfPS];

            return numberPartOfSpeach;
        }

        /// <summary>
        /// Метод рандомного определения индекса выбранного слова из коллекции слов
        /// </summary>
        /// <param name="randomWords">рандомно созданная коллекция слов</param>
        /// <returns></returns>
        public static int GetIndexCheckedWord(List<Word> randomWords)
        {
            var rand = new Random();
            var index = rand.Next(randomWords.Count);
            var indexOfWord = randomWords[index].Id;

            return indexOfWord;
        }

        /// <summary>
        /// Метод проверки частей речи, выбранных пользователем, на предмет наличия для них слов в БД
        /// </summary>
        /// <param name="partSpeech">части речи, выбранные пользователем</param>
        /// <returns></returns>
        public bool TestingOfUsersPSChoose(List<string> partSpeech)
        {
            var areExistResult = true;

            foreach (var speech in partSpeech)
            {
                switch (speech)
                {
                    case "Noun":
                        var noun = _dbContext.Words.FirstOrDefault(x => x.PartOfSpeech == PartsOfSpeech.Noun) ?? null;
                        areExistResult = noun != null;
                        break;
                    case "Verb":
                        var verb = _dbContext.Words.FirstOrDefault(x => x.PartOfSpeech == PartsOfSpeech.Verb) ?? null;
                        areExistResult = verb != null;
                        break;
                    case "Adjective":
                        var ajective = _dbContext.Words.FirstOrDefault(x => x.PartOfSpeech == PartsOfSpeech.Adjective) ?? null;
                        areExistResult = ajective != null;
                        break;
                    case "Adverb":
                        var adverb = _dbContext.Words.FirstOrDefault(x => x.PartOfSpeech == PartsOfSpeech.Adverb) ?? null;
                        areExistResult = adverb != null;
                        break;
                    case "Pronoun":
                        var pronoun = _dbContext.Words.FirstOrDefault(x => x.PartOfSpeech == PartsOfSpeech.Pronoun) ?? null;
                        areExistResult = pronoun != null;
                        break;
                    case "Preposition":
                        var preposition = _dbContext.Words.FirstOrDefault(x => x.PartOfSpeech == PartsOfSpeech.Preposition) ?? null;
                        areExistResult = preposition != null;
                        break;
                    case "Conjunction":
                        var conjuction = _dbContext.Words.FirstOrDefault(x => x.PartOfSpeech == PartsOfSpeech.Conjunction) ?? null;
                        areExistResult = conjuction != null;
                        break;
                    case "Interjection":
                        var interjection = _dbContext.Words.FirstOrDefault(x => x.PartOfSpeech == PartsOfSpeech.Interjection) ?? null;
                        areExistResult = interjection != null;
                        break;
                }
                if (!areExistResult) break;
            }

            return areExistResult;
        }

        /// <summary>
        /// Метод проверки достаточного количества слов для каждой части речи
        /// </summary>
        /// <param name="partSpeech">части речи, выбранные пользователем</param>
        /// <returns></returns>
        public static bool TestingOfWordsNumber(List<string> partSpeech)
        {
            // TODO: реализовать метод TestingOfWordsNumber()
            return true;
        }
    }
}
