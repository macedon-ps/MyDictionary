using MyDictionary.Models;
using MyDictionary.ViewModels;

namespace MyDictionary.Interfaces
{
    public interface IWordsInterface
    {
        int RandomChooseOfPartOfSpeach();  
        
        List<Word> GetRandomWords(int numberWords);

        int GetIndexCheckedWord(List<Word> randomWords);

        CheckWordsViewModel GetCheckWordsViewModel(
            int indexOfCheckedWord, 
            List<Word> randomWords);

        CheckWordsViewModel GetCheckWordsViewModel(
            int idWord, 
            int allQuestion, 
            int goodAnswers, 
            int badAnswers, 
            string grades, 
            int idSelectedAnswer, 
            List<Word> newRandomWords, 
            int newIndexOfCheckedWord);
    }
}
