using MyDictionary.Models;

namespace MyDictionary.Interfaces
{
    public interface IWordsInterface
    {
        /// <summary>
        /// Метод рандомного создания коллекции слов одной или нескольких частей речи, состоящей из заданного количества слов
        /// </summary>
        /// <param name="partSpeech">список частей речи, выбранных пользователем</param>
        /// <returns></returns>
        List<Word> GetRandomWords(List<string> partSpeech);

        /// <summary>
        /// Метод рандомного создания одного слова
        /// </summary>
        /// <param name="numberOfPartOfSpeech">номер заданной части речи</param>
        /// <returns></returns>
        Word GetOneRandomWord(int numberOfPartOfSpeech);

        /// <summary>
        /// Метод получения слова по его идентификатору
        /// </summary>
        /// <param name="wordId">идентификатор слова</param>
        /// <returns></returns>
        Word GetWordById(int wordId);

        /// <summary>
        /// Метод рандомного предложения для заданной коллекции времен англ. языка
        /// </summary>
        /// <param name="englishTences">коллекция времен англ. языка</param>
        /// <returns></returns>
        Sentence GetRandomSentence(List<string> englishTences);
    }
}
