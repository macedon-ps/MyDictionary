using MyDictionary.Models;

namespace MyDictionary.ViewModels
{
    public class CheckSentencesViewModel
    {
        /// <summary>
        /// Рандомно выбранное предложение
        /// </summary>
        public Sentence RandomSentence { get; set; } = null!;

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

        public CheckSentencesViewModel(Sentence sentence) 
        {
            RandomSentence = sentence;
        }
    }
}
