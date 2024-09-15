using MyDictionary.Models;

namespace MyDictionary.ViewModels
{
    public class CheckWordsViewModel
    {
        public int IndexOfCheckedWord { get; set; } 

        public IEnumerable<Word> SelectedWords { get; set; } = new List<Word>();

        public int AllQuestionsNumber { get; set; }

        public int GoodAnswersNumber { get; set; }

        public int BadAnswersNunber { get; set; }

        public string Grades {  get; set; }

    }
}
