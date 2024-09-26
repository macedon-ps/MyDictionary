using MyDictionary.DBContext;
using MyDictionary.Models;

namespace MyDictionary.Utils
{
    public class WordsUtils
    {
        private readonly WordsDbContext _dbWords;
        public static int[] _arrayAllWordsIndex;
        public static int _allWordsNumber;

        public WordsUtils(WordsDbContext dbWords)
        {
            _dbWords = dbWords;
            _allWordsNumber = _dbWords.Words.Count();
            _arrayAllWordsIndex = GetArrayOfWordsIndex();
        }

        public int[] GetArrayOfWordsIndex()
        {
            var nuberOfWords = _dbWords.Words.Count();
            var arrayOfWordsIndex = new int[nuberOfWords];
            var allWords = _dbWords.Words.ToList();
            var i = 0;

            foreach (var word in allWords)
            {
                arrayOfWordsIndex[i] = word.Id;
                i++;
            }

            return arrayOfWordsIndex;
        }

        public Word GetRandomWord()
        {
            var rand = new Random();
            var randomWordNumber = rand.Next(_allWordsNumber);
            var randomWordIndex = _arrayAllWordsIndex[randomWordNumber];

            var word = _dbWords.Words.FirstOrDefault(x => x.Id == randomWordIndex);

            return word;
        }

        /// <summary>
        /// Метод рандомного определения части речи
        /// </summary>
        /// <returns></returns>
        public static int RandomChooseOfPartOfSpeach()
        {
            // Количество частей речи в перечислении PartsOfSpeech
            var numberPartOfSpeach = Enum.GetNames(typeof(PartsOfSpeech)).Length;

            // Рандомное определение части речи
            var rand = new Random();
            //var currentRandomPartOfSpeech = rand.Next(numberPartOfSpeach);
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

    }
}
