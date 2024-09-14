using MyDictionary.Models;

namespace MyDictionary.Interfaces
{
    public interface IWordsInterface
    {
        int RandomChooseOfPartOfSpeach();  
        
        List<Word> GetRandomWords(int numberWords);

        int GetIndexCheckedWord(List<Word> randomWords);
    }
}
