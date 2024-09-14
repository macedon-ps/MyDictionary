using MyDictionary.Models;

namespace MyDictionary.ViewModels
{
    public class CheckWordsViewModel
    {
        public int IndexOfCheckedWord { get; set; } 

        public IEnumerable<Word> SelectedWords { get; set; } = new List<Word>();

    }
}
