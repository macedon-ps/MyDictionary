using MyDictionary.Models;

namespace MyDictionary.ViewModels
{
    public class CheckWordsViewModel
    {
        public Word OneWord { get; set; } = new Word();

        public IEnumerable<Word> ListOfTranslatedWords { get; set; } = new List<Word>();

    }
}
