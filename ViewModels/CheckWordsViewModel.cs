using MyDictionary.Models;

namespace MyDictionary.ViewModels
{
    public class CheckWordsViewModel
    {
        /// <summary>
        /// Индекс выбранного слова из коллекции слов
        /// </summary>
        public int IndexOfCheckedWord { get; set; }

        /// <summary>
        /// Рандомно созданная коллекция слов
        /// </summary>
        public List<Word> RandomWords { get; set; } = new List<Word>();

        /// <summary>
        /// Количество вариантов для перевода слова
        /// </summary>
        private int NumberOfWords { get; set; } = 5;

        /// <summary>
        /// Количество всех ответов
        /// </summary>
        public int AllQuestionsNumber { get; set; }

        /// <summary>
        /// Количество правильных ответов
        /// </summary>
        public int GoodAnswersNumber { get; set; }

        /// <summary>
        /// Количество неправильных ответов
        /// </summary>
        public int BadAnswersNumber { get; set; }

        /// <summary>
        /// Словесная оценка пользователя за его ответ
        /// </summary>
        public string Grades { get; set; } = "";

        public CheckWordsViewModel() { }

        /// <summary>
        /// Метод получения количества слов в коллекции - для количества вариантов ответа 
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfWords()
        {
            return this.NumberOfWords;
        }

        public CheckWordsViewModel(List<Word> randomWords, int indexOfCheckedWord)
        {
            RandomWords = randomWords;
            IndexOfCheckedWord = indexOfCheckedWord;
        }

        public CheckWordsViewModel(List<Word> randomWords, int indexOfCheckedWord, int idWord, int allQuestion, int goodAnswers, int badAnswers, string grades, int idSelectedAnswer) : this(randomWords, indexOfCheckedWord)
        {
            IndexOfCheckedWord = idWord;
            AllQuestionsNumber = allQuestion;
            GoodAnswersNumber = goodAnswers;
            BadAnswersNumber = badAnswers;
            Grades = grades;

            AllQuestionsNumber++;

            if (idSelectedAnswer == idWord)
            {
                GoodAnswersNumber++;
                Grades = "Good job!!!";
            }
            else
            {
                BadAnswersNumber++;
                Grades = "Bad, very bad!!!";
            }

            RandomWords = randomWords;
            IndexOfCheckedWord = indexOfCheckedWord;
        }
    }
}
