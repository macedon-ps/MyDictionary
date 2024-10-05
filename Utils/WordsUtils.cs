using Microsoft.Extensions.FileProviders;
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
        /// Метод рандомного определения части речи
        /// </summary>
        /// <returns></returns>
        public static int RandomChooseOfPartOfSpeach()
        {
            // Количество частей речи в перечислении PartsOfSpeech
            var numberAllPartOfSpeach = Enum.GetNames(typeof(PartsOfSpeech)).Length;

            // Рандомное определение части речи
            var rand = new Random();
            //var currentRandomPartOfSpeech = rand.Next(numberAllPartOfSpeach);
            // м. вручную выставить: 0 - существительные, 1 - глаголы, 2 - прилагательные, 4 - наречмя и т.д.
            var currentRandomPartOfSpeech = 1;

            // TODO: м.б. сделать возможным выбор пользователем части  речи самостоятельно

            // TODO: сделать проверку существуют ли в словаре слова данной части речи (для полной версии PartsOfSpeech)

            return currentRandomPartOfSpeech;
        }

        /// <summary>
        /// Метод рандомного определения части речи из тех, что выбраны пользователем
        /// </summary>
        /// <param name="partSpeech">список частей речи, выбранных пользователем</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static int RandomChooseOfPartOfSpeach(List<string> partSpeech)
        {
            // преобразование List<string> partSpeech в массив чисел - значений частей речи из enum PartsOfSpeech
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

        public static int RandomChooseOfEnglishTence()
        {
            // Количество времен в английском языке в перечислении Tenses
            var numberAllTences = Enum.GetNames(typeof(Tences)).Length;

            // Рандомное определение времени английского языка

            // var rand = new Random();
            // var currentRandomTence = rand.Next(numberAllTences);
            // м. вручную выставить:
            // 0 - PresentSimple, 1 - PresentContinuous, 2 - PresentPerfect, 3 - PresentPerfectContinuous,
            // 4 - PastSimple, 5 - PastContinuous, 6 - PastPerfect, 7 - PastPerfectContinuous,
            // 8 - FutureSimple, 9 - FutureContinuous, 10 - FuturePerfect, 11 - FuturePerfectContinuous,
            // 12 -Mixt
            var currentRandomTence = 8;

            // TODO: м.б. сделать возможным выбор пользователем времени английского языка самостоятельно

            // TODO: сделать проверку существуют ли в словаре предложения данного времени английского языка (для полной версии Tenses)

            return currentRandomTence;
        }

        public bool TestingOfUsersChoose(List<string> partSpeech)
        {
            // TODO: реализовать метод TestingOfUsersChoose()
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
                if(!areExistResult) break;
            }

            return areExistResult;
        }

        public static bool TestingOfWordsNumber(List<string> partSpeech)
        {
            // TODO: реализовать метод TestingOfWordsNumber()
            return true;
        }
    }
}
