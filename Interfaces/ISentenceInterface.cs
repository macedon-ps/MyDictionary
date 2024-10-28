using MyDictionary.Models;

namespace MyDictionary.Interfaces
{
    public interface ISentenceInterface
    {
        /// <summary>
        /// Метод рандомного предложения для заданной коллекции времен англ. языка
        /// </summary>
        /// <param name="englishTences">коллекция времен англ. языка</param>
        /// <returns></returns>
        Sentence GetRandomSentence(List<string> englishTences);
    }
}
