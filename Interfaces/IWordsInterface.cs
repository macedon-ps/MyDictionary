using MyDictionary.Models;

namespace MyDictionary.Interfaces
{
    public interface IWordsInterface
    {
       
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

        Word GetRandomWord();

        /// <summary>
        /// Метод получения всех слов
        /// </summary>
        /// <returns></returns>
        List<Word> GetAllWords();

        /* не реализовано
        /// <summary>
        /// Метод получения всех слов определенной части речи
        /// </summary>
        /// <param name="partOfSpeech">часть речи</param>
        /// <returns></returns>
        List<Word> GetWordsByPartOfSpeech(int partOfSpeech);

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
        */

        /// <summary>
        /// Метод рандомного выбора предложения
        /// </summary>
        /// <returns></returns>
        Sentence GetRandomSentence();

        /// <summary>
        /// Метод рандомного выбора предложения одной части речи
        /// </summary>
        /// <returns></returns>
        Sentence GetRandomSentenceByTence(int tence);

        /// <summary>
        /// Метод получения всех предложений
        /// </summary>
        /// <returns></returns>
        List<Sentence> GetAllSentences();

        /// <summary>
        /// Метод получения предложения по его идентификатору
        /// </summary>
        /// <param name="id">идентификатор предложения</param>
        /// <returns></returns>
        Sentence GetSentenceById(int id);

        /* не реализовано
        
        /// <summary>
        /// Метод получения всех предложений определенного времени англ. языка
        /// </summary>
        /// <param name="tence">время англ. языка</param>
        /// <returns></returns>
        List<Sentence> GetSentencesByTence(Tenses tence);

        /// <summary>
        /// Метод сохранения предложения по его экземпляру и идентификатору
        /// </summary>
        /// <param name="sentence">экземпляр предложения</param>
        /// <param name="id">идентификатор предложения</param>
        void SaveSentence(Sentence sentence, int id);

        /// <summary>
        /// Метод удаления предложения по его экземпляру и идентификатору
        /// </summary>
        /// <param name="sentence">экземпляр предложения</param>
        /// <param name="id">идентификатор предложения</param>
        void DeleteSentence(Sentence sentence, int id);
        */
    }
}
