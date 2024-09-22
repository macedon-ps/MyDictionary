using Microsoft.EntityFrameworkCore;
using MyDictionary.DBContext;
using MyDictionary.Interfaces;
using MyDictionary.Models;
using MyDictionary.ViewModels;

namespace MyDictionary.Repository
{
    public class WordsRepository : IWordsInterface
    {
        private readonly WordsDbContext _dbWords;
        public int[] _arrayAllWordsIndex;
        public int _allWordsNumber;

        public WordsRepository(WordsDbContext dbWords)
        {
            _dbWords = dbWords;
            _allWordsNumber = GetNumberOfAllWords();
            _arrayAllWordsIndex = GetArrayOfWordsIndex();
        }
            
        /// <summary>
        /// Метод рандомного создания коллекции слов одной части речи, состоящей из заданного количества слов
        /// </summary>
        /// <param name="number">заданное количество слов в коллекции</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Word> GetRandomWords()
        {
            //1. Рандомный выбор части речи
            var numberOfPartOfSpeech = RandomChooseOfPartOfSpeach();

            // 2. Определение количества вариантов ответа
            var number = new CheckWordsViewModel().GetNumberOfWords();

            // 3. Создание коллекции слов List<Word> в количестве number слов
            var randomWordsList = new List<Word>();
            
            for (int i = 0; i < number; i++)
            {
                var isAddedNewWord = false;

                while (!isAddedNewWord)
                {
                    var randomWord = GetRandomWord();
                        
                    if ((int)randomWord.PartOfSpeech == numberOfPartOfSpeech && !randomWordsList.Contains(randomWord))
                    {
                        randomWordsList.Add(randomWord);
                        isAddedNewWord = true;
                    }
                }
            }
            return randomWordsList;
        }

        /// <summary>
        /// Метод рандомного выбора слова
        /// </summary>
        /// <returns></returns>
        public Word GetRandomWord()
        {
            var rand = new Random();
            var randomWordNumber = rand.Next(this._allWordsNumber);
            var randomWordIndex = _arrayAllWordsIndex[randomWordNumber];

            var word = _dbWords.Words.FirstOrDefault(x => x.Id == randomWordIndex);

            return word;
        }

        /// <summary>
        /// Метод рандомного определения части речи
        /// </summary>
        /// <returns></returns>
        public int RandomChooseOfPartOfSpeach()
        {
            // Количество частей речи в перечислении PartsOfSpeech
            var numberPartOfSpeach = Enum.GetNames(typeof(PartsOfSpeech)).Length;

            // Рандомное определение части речи
            var rand = new Random();
            //var currentRandomPartOfSpeech = rand.Next(numberPartOfSpeach);
            // м. вручную выставить: 0 - существительные, 1 - глаголы, 2 - прилагательные, 4 - наречмя и т.д.
            var currentRandomPartOfSpeech = 0;

            // TODO: м.б. сделать возможным выбор пользователем части  речи самостоятельно

            // TODO: сделать проверку существуют ли в словаре слова данной части речи (для полной версии PartsOfSpeech)

            return currentRandomPartOfSpeech;
        }

        /// <summary>
        /// Метод рандомного определения индекса выбранного слова из коллекции слов
        /// </summary>
        /// <param name="randomWords">рандомно созданная коллекция слов</param>
        /// <returns></returns>
        public int GetIndexCheckedWord(List<Word> randomWords)
        {
            var rand = new Random();
            var index = rand.Next(randomWords.Count);
            var indexOfWord = randomWords[index].Id;

            return indexOfWord;
        }

        /// <summary>
        /// Метод получения вью-модели по 2-м параметрам
        /// </summary>
        /// <param name="indexOfCheckedWord">индекс выбранного слова из коллекции слов</param>
        /// <param name="randomWords">рандомно созданная коллекция слов</param>
        /// <returns></returns>
        public CheckWordsViewModel GetCheckWordsViewModel(List<Word> randomWords, int indexOfCheckedWord)
        {
            var viewModel = new CheckWordsViewModel();

            viewModel.IndexOfCheckedWord = indexOfCheckedWord;
            viewModel.RandomWords = randomWords;
                        
            return viewModel;
        }

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
        public CheckWordsViewModel GetCheckWordsViewModel(List<Word> newRandomWords, int newIndexOfCheckedWord, int idWord, int allQuestion, int goodAnswers, int badAnswers, string grades, int idSelectedAnswer)
        {
            var viewModel = new CheckWordsViewModel();

            viewModel.IndexOfCheckedWord = idWord;
            viewModel.AllQuestionsNumber = allQuestion;
            viewModel.GoodAnswersNumber = goodAnswers;
            viewModel.BadAnswersNumber = badAnswers;
            viewModel.Grades = grades;

            viewModel.AllQuestionsNumber++;

            if (idSelectedAnswer == idWord)
            {
                viewModel.GoodAnswersNumber++;
                viewModel.Grades = "Good job!!!";
            }
            else
            {
                viewModel.BadAnswersNumber++;
                viewModel.Grades = "Bad, very bad!!!";
            }

            viewModel.IndexOfCheckedWord = newIndexOfCheckedWord;
            viewModel.RandomWords = newRandomWords;

            return viewModel;
        }

        public List<Word> GetAllWords()
        {
            var allWords = _dbWords.Words.ToList();

            return allWords;
        }

        public int GetNumberOfAllWords()
        {
            var numberOfWords = _dbWords.Words.Count();
            return numberOfWords;
        }

        public int[] GetArrayOfWordsIndex()
        {
            var nuberOfWodds = this._allWordsNumber;
            var arrayOfWordsIndex = new int[nuberOfWodds];
            var allWords = GetAllWords();
            var i = 0;

            foreach (var word in allWords) 
            { 
                arrayOfWordsIndex[i] = word.Id;
                i++;
            }

            return arrayOfWordsIndex;
        }

        public List<Word> GetWordsByPartOfSpeech(PartsOfSpeech partOfSpeech)
        {
            throw new NotImplementedException();
        }

        public Word GetWordById(int id)
        {
            throw new NotImplementedException();
        }

        public Word GetWordByRusValue(string rusValue)
        {
            throw new NotImplementedException();
        }

        public Word GetWordByEngValue(string engValue)
        {
            throw new NotImplementedException();
        }

        public void SaveWoord(Word word, int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteWoord(Word word, int id)
        {
            throw new NotImplementedException();
        }

        public List<Sentence> GetAllSentences()
        {
            throw new NotImplementedException();
        }

        public List<Word> GetSentencesByTence(Tenses tence)
        {
            throw new NotImplementedException();
        }

        public Word GetSentenceById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveSentence(Word word, int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSentence(Word word, int id)
        {
            throw new NotImplementedException();
        }
    }
}
