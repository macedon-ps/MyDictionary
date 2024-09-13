using MyDictionary.Models;

namespace MyDictionary.Interfaces
{
    public interface IWordsInterface
    {
        List<Word> GetAllWords();

        Word GetWord();

        Word GetWord(int id);

        List<Word> GetAllWordsByType(int parthOfSpeach);

        List<Word> GetWordsByType(int middleNumber, int interval, int parthOfSpeach);

        (int, int) Get2Numbers(int middleNumber, int interval);
    }
}
