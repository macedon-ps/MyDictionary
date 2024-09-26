using MyDictionary.Models;
using MyDictionary.ViewModels;

namespace MyDictionary.Interfaces
{
    public interface IWordsInterface
    {
        /// <summary>
        /// Метод получения всех слов
        /// </summary>
        /// <returns></returns>
        List<Word> GetAllWords();

        /// <summary>
        /// Метод получения всех слов определенной части речи
        /// </summary>
        /// <param name="partOfSpeech">часть речи</param>
        /// <returns></returns>
        List<Word> GetWordsByPartOfSpeech(PartsOfSpeech partOfSpeech);

        /// <summary>
        /// Метод рандомного создания коллекции слов одной части речи, состоящей из заданного количества слов
        /// </summary>
        /// <returns></returns>
        List<Word> GetRandomWords();

        /// <summary>
        /// Метод рандомного создания коллекции слов одной или нескольких частей речи, состоящей из заданного количества слов
        /// </summary>
        /// <param name="partSpeech">список частей речи, выбранных пользователем</param>
        /// <returns></returns>
        List<Word> GetRandomWords(List<string> partSpeech);

        /// <summary>
        /// Метод получения слова по его идентификатору
        /// </summary>
        /// <param name="id">идентификатор слова</param>
        /// <returns></returns>
        Word GetWordById(int id);

        /// <summary>
        /// Метод получения слова по его значению на русском языке
        /// </summary>
        /// <param name="rusValue">значению слова на русском языке</param>
        /// <returns></returns>
        Word GetWordByRusValue(string rusValue);

        /// <summary>
        /// Метод получения слова по его значению на английском языке
        /// </summary>
        /// <param name="engValue">значению слова на английском языке</param>
        /// <returns></returns>
        Word GetWordByEngValue(string engValue);

        /// <summary>
        /// Метод сохранения слова по его экземпляру и идентификатору
        /// </summary>
        /// <param name="word">экземпляр слова</param>
        /// <param name="id">идентификатор слова</param>
        void SaveWoord(Word word, int id);

        /// <summary>
        /// Метод удаления слова по его экземпляру и идентификатору
        /// </summary>
        /// <param name="word">экземпляр слова</param>
        /// <param name="id">идентификатор слова</param>
        void DeleteWoord(Word word, int id);

        /// <summary>
        /// Метод получения всех предложений
        /// </summary>
        /// <returns></returns>
        List<Sentence> GetAllSentences();

        /// <summary>
        /// Метод получения всех предложений определенного времени англ. языка
        /// </summary>
        /// <param name="tence">время англ. языка</param>
        /// <returns></returns>
        List<Word> GetSentencesByTence(Tenses tence);

        /// <summary>
        /// Метод получения предложения по его идентификатору
        /// </summary>
        /// <param name="id">идентификатор предложения</param>
        /// <returns></returns>
        Word GetSentenceById(int id);

        /// <summary>
        /// Метод сохранения предложения по его экземпляру и идентификатору
        /// </summary>
        /// <param name="word">экземпляр предложения</param>
        /// <param name="id">идентификатор предложения</param>
        void SaveSentence(Word word, int id);

        /// <summary>
        /// Метод удаления предложения по его экземпляру и идентификатору
        /// </summary>
        /// <param name="word">экземпляр предложения</param>
        /// <param name="id">идентификатор предложения</param>
        void DeleteSentence(Word word, int id);
    }
}
