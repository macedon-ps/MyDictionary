using MyDictionary.Models;

namespace MyDictionary.Interfaces
{
    public interface IWordMoqInterface
    {
        /// <summary>
        /// Метод рандомного создания коллекции слов одной части речи, состоящей из заданного количества слов
        /// </summary>
        /// <returns></returns>
        List<Word> GetRandomWords();

    }
}
