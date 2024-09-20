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

        /// <summary>
        /// Метод получения количества слов в коллекции - для количества вариантов ответа 
        /// </summary>
        /// <returns></returns>
        int GetNumberOfWords();

        /// <summary>
        /// Метод рандомного создания коллекции слов одной части речи, состоящей из заданного количества слов
        /// </summary>
        /// <param name="numberWords">заданное количество слов в коллекции</param>
        /// <returns></returns>
        List<Word> GetRandomWords(int numberWords);

        /// <summary>
        /// Метод рандомного определения части речи
        /// </summary>
        /// <returns></returns>
        int RandomChooseOfPartOfSpeach();

        /// <summary>
        /// Метод рандомного определения индекса выбранного слова из коллекции слов
        /// </summary>
        /// <param name="randomWords">рандомно созданная коллекция слов</param>
        /// <returns></returns>
        int GetIndexCheckedWord(List<Word> randomWords);

        /// <summary>
        /// Метод получения вью-модели по 2-м параметрам
        /// </summary>
        /// <param name="indexOfCheckedWord">индекс выбранного слова из коллекции слов</param>
        /// <param name="randomWords">рандомно созданная коллекция слов</param>
        /// <returns></returns>
        CheckWordsViewModel GetCheckWordsViewModel(
            int indexOfCheckedWord, 
            List<Word> randomWords);

        /// <summary>
        /// Метод получения вью-модели по 8-м параметрам
        /// </summary>
        /// <param name="idWord">идентификатор слова, которое проверяется</param>
        /// <param name="allQuestion">количество всех ответов</param>
        /// <param name="goodAnswers">количество правильных ответов</param>
        /// <param name="badAnswers">количество неправильных ответов</param>
        /// <param name="grades">словесная оценка пользователя за его ответ</param>
        /// <param name="idSelectedAnswer">идентификатор слова, выбранного пользователем при ответе</param>
        /// <param name="newRandomWords">новая рандомно созданная коллекция слов</param>
        /// <param name="newIndexOfCheckedWord">новый индекс выбранного слова из коллекции слов</param>
        /// <returns></returns>
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
