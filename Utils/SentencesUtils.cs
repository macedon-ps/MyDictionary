using MyDictionary.DBContext;
using MyDictionary.Models;

namespace MyDictionary.Utils
{
    public class SentencesUtils
    {
        private readonly WordsDbContext _dbContext;

        public SentencesUtils(WordsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Метод рандомного определения времени англ. языка из тех, что выбраны пользователем
        /// </summary>
        /// <param name="Tences">список времен англ. языка, выбранных пользователем</param>
        /// <returns></returns>
        public static int RandomChooseOfTence(List<string> Tences)
        {
            // Количество времен в английском языке в перечислении Tenses
            var numberAllTences = Enum.GetNames(typeof(Tences)).Length;
            /* номера времен англ. языка
            0 - PresentSimple, 1 - PresentContinuous, 2 - PresentPerfect, 3 - PresentPerfectContinuous,
            4 - PastSimple, 5 - PastContinuous, 6 - PastPerfect, 7 - PastPerfectContinuous,
            8 - FutureSimple, 9 - FutureContinuous, 10 - FuturePerfect, 11 - FuturePerfectContinuous,
            12 -Mixt 
            */

            var listSize = Tences.Count;
            var arraySelectedTences = new int[listSize];
            var numberOfTences = 0;

            var i = 0;
            foreach (var item in Tences)
            {
                switch (item)
                {
                    case "PresentSimple":
                        numberOfTences = 0;
                        break;
                    case "PresentContinuous":
                        numberOfTences = 1;
                        break;
                    case "PresentPerfect":
                        numberOfTences = 2;
                        break;
                    case "PresentPerfectContinuous":
                        numberOfTences = 3;
                        break;
                    case "PastSimple":
                        numberOfTences = 4;
                        break;
                    case "PastContinuous":
                        numberOfTences = 5;
                        break;
                    case "PastPerfect":
                        numberOfTences = 6;
                        break;
                    case "PastPerfectContinuous":
                        numberOfTences = 7;
                        break;
                    case "FutureSimple":
                        numberOfTences = 8;
                        break;
                    case "FutureContinuous":
                        numberOfTences = 9;
                        break;
                    case "FuturePerfect":
                        numberOfTences = 10;
                        break;
                    case "FuturePerfectContinuous":
                        numberOfTences = 11;
                        break;
                    case "Mixt":
                        numberOfTences = 12;
                        break;
                }
                arraySelectedTences[i] = numberOfTences;
                i++;
            }

            var rand = new Random();
            var randomNumberOfTences = rand.Next(listSize);
            var numberTence = arraySelectedTences[randomNumberOfTences];

            return numberTence;
        }

        /// <summary>
        /// Метод проверки времен англ. языка, выбранных пользователем, на предмет наличия для них слов в БД
        /// </summary>
        /// <param name="tences">времена англ. языка, выбранные пользователем</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool TestingOfUsersTencesChoose(List<string> tences)
        {
            var areExistResult = true;

            foreach (var tence in tences)
            {
                switch (tence)
                {
                    case "PresentSimple":
                        var presentSimple = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.PresentSimple) ?? null;
                        areExistResult = presentSimple != null;
                        break;
                    case "PresentContinuous":
                        var presentContinuous = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.PresentContinuous) ?? null;
                        areExistResult = presentContinuous != null;
                        break;
                    case "PresentPerfect":
                        var presentPerfect = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.PresentPerfect) ?? null;
                        areExistResult = presentPerfect != null;
                        break;
                    case "PresentPerfectContinuous":
                        var presentPerfectContinuous = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.PresentPerfectContinuous) ?? null;
                        areExistResult = presentPerfectContinuous != null;
                        break;
                    case "PastSimple":
                        var pastSimple = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.PastSimple) ?? null;
                        areExistResult = pastSimple != null;
                        break;
                    case "PastContinuous":
                        var pastContinuous = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.PastContinuous) ?? null;
                        areExistResult = pastContinuous != null;
                        break;
                    case "PastPerfect":
                        var pastPerfect = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.PastPerfect) ?? null;
                        areExistResult = pastPerfect != null;
                        break;
                    case "PastPerfectContinuous":
                        var pastPerfectContinuous = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.PastPerfectContinuous) ?? null;
                        areExistResult = pastPerfectContinuous != null;
                        break;
                    case "FutureSimple":
                        var futureSimple = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.FutureSimple) ?? null;
                        areExistResult = futureSimple != null;
                        break;
                    case "FutureContinuous":
                        var futureContinuous = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.FutureContinuous) ?? null;
                        areExistResult = futureContinuous != null;
                        break;
                    case "FuturePerfect":
                        var futurePerfect = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.FuturePerfect) ?? null;
                        areExistResult = futurePerfect != null;
                        break;
                    case "FuturePerfectContinuous":
                        var futurePerfectContinuous = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.FuturePerfectContinuous) ?? null;
                        areExistResult = futurePerfectContinuous != null;
                        break;
                    case "Mixt":
                        var mixt = _dbContext.Sentences.FirstOrDefault(x => x.Tense == Tences.Mixt) ?? null;
                        areExistResult = mixt != null;
                        break;
                }
                if (!areExistResult) break;
            }

            return areExistResult;
        }

        /// <summary>
        /// Метод проверки достаточного количества слов для каждого времени англ. языка
        /// </summary>
        /// <param name="tences">времена англ. языка, выбранные пользователем</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool TestingOfSentenceNumber(List<string> tences)
        {
            // TODO: реализовать метод TestingOfSentenceNumber()
            return true;
        }
    }
}
