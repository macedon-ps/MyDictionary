using MyDictionary.Interfaces;
using MyDictionary.Models;
using MyDictionary.ViewModels;

namespace MyDictionary.Repository
{
    public class WordsRepository : IWordsInterface
    {
        /// <summary>
        /// Коллекция слов в мокковом словаре
        /// </summary>
        public List<Word> words = new()
        {
            new Word{Id = 0, RusValue="стол", EngValue="table", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 1, RusValue="стул", EngValue="chair", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 2, RusValue="ручка", EngValue="pen", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 3, RusValue="карандаш", EngValue="pencil", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 4, RusValue="книга", EngValue="book", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 5, RusValue="тетрадь", EngValue="copybook", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 6, RusValue="диван", EngValue="sofa", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 7, RusValue="шкаф", EngValue="wardrobe", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 8, RusValue="блокнот", EngValue="notebook", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 9, RusValue="резинка", EngValue="rubber", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 10, RusValue="бежать", EngValue="run", Transcription="", PartOfSpeech=PartsOfSpeech.Verb},
            new Word{Id = 11, RusValue="сверлить", EngValue="drill", Transcription="", PartOfSpeech=PartsOfSpeech.Verb},
            new Word{Id = 12, RusValue="кидать", EngValue="throw", Transcription="", PartOfSpeech=PartsOfSpeech.Verb},
            new Word{Id = 13, RusValue="плакать", EngValue="cry", Transcription="", PartOfSpeech=PartsOfSpeech.Verb},
            new Word{Id = 14, RusValue="кричать", EngValue="scream", Transcription="", PartOfSpeech=PartsOfSpeech.Verb},
            new Word{Id = 15, RusValue="приехать", EngValue="arrive", Transcription="", PartOfSpeech=PartsOfSpeech.Verb},
            new Word{Id = 16, RusValue="уехать", EngValue="leave", Transcription="", PartOfSpeech=PartsOfSpeech.Verb},
            new Word{Id = 17, RusValue="переехать", EngValue="move", Transcription="", PartOfSpeech=PartsOfSpeech.Verb},
            new Word{Id = 18, RusValue="подъехать", EngValue="drive up", Transcription="", PartOfSpeech=PartsOfSpeech.Verb},
            new Word{Id = 19, RusValue="заехать", EngValue="drop in", Transcription="", PartOfSpeech=PartsOfSpeech.Verb},
            new Word{Id = 20, RusValue="зависеть", EngValue="addicted to", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 21, RusValue="злиться", EngValue="angry with", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 22, RusValue="известный", EngValue="famous for", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 23, RusValue="бояться", EngValue="afraid of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 24, RusValue="гордиться", EngValue="proud of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 25, RusValue="сожалеть", EngValue="sorry about", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 26, RusValue="интересоваться", EngValue="interested in", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 27, RusValue="полон", EngValue="full of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 28, RusValue="обожать", EngValue="fond of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 29, RusValue="готов", EngValue="ready for", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},

        };

        /// <summary>
        /// Метод рандомного создания коллекции слов одной части речи в определенном количестве
        /// </summary>
        /// <param name="number">количество выводимых слов как вариантов перевода</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Word> GetRandomWords(int number)
        {
            var selectedWords = new List<Word>();

            //1. Рандомный выбор части речи

            var numberOfPartOfSpeech = RandomChooseOfPartOfSpeach();

            // 2. Создание коллекции слов List<Word> в количестве number слов

            for(int i = 0; i < number; i++)
            {
                var isAddedNewWord = false;

                while (!isAddedNewWord)
                {
                    var rand = new Random();
                    var wordNumber = rand.Next(words.Count);
                    var word = words.FirstOrDefault(x => x.Id == wordNumber);

                    if ((int)word.PartOfSpeech == numberOfPartOfSpeech && !selectedWords.Contains(word))
                    {
                        selectedWords.Add(word);
                        isAddedNewWord = true;
                    }
                }
            }
            return selectedWords;
        }

        /// <summary>
        /// Метод рандомного поиска номера части речи
        /// </summary>
        /// <returns></returns>
        public int RandomChooseOfPartOfSpeach()
        {
            // Количество частей речи в перечислении PartsOfSpeech
            var numberPartOfSpeach = Enum.GetNames(typeof(PartsOfSpeech)).Length;

            // Рандомное определение части речи
            var rand = new Random();
            var currentRandomPartOfSpeech = rand.Next(numberPartOfSpeach);

            // TODO: сделать проверку существуют ли в словаре слова данной части речи (для полной версии PartsOfSpeech)

            return currentRandomPartOfSpeech;
        }

        /// <summary>
        /// Метод определения индекса проверяемого слова
        /// </summary>
        /// <param name="randomWords">коллекция рандомно выбранных слов из БД</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetIndexCheckedWord(List<Word> randomWords)
        {
            var rand = new Random();
            var index = rand.Next(randomWords.Count);
            var indexOfWord = randomWords[index].Id;

            return indexOfWord;
        }

        /// <summary>
        /// Метод создания вью-модели CheckWordsViewModel с 2-мя параметрами
        /// </summary>
        /// <param name="indexOfCheckedWord">индекс рандомно выбранного слова</param>
        /// <param name="randomWords">коллекция рандомно выбранных слов из БД</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public CheckWordsViewModel GetCheckWordsViewModel(int indexOfCheckedWord, List<Word> randomWords)
        {
            var viewModel = new CheckWordsViewModel();

            viewModel.IndexOfCheckedWord = indexOfCheckedWord;
            viewModel.SelectedWords = randomWords;
                        
            return viewModel;
        }

        /// <summary>
        /// Метод создания вью-модели CheckWordsViewModel с многими параметрами
        /// </summary>
        /// <param name="idWord">индекс слова, кот. будет проверяться на правильный перевод</param>
        /// <param name="allQuestion">количество переведенных слов</param>
        /// <param name="goodAnswers">количество правильных ответов</param>
        /// <param name="badAnswers">количество неправильных ответов</param>
        /// <param name="grades">описание оценки</param>
        /// <param name="idSelectedAnswer">индекс слова - одного из многих вариантов перевода</param>
        /// <param name="newRandomWords">новый сгенерированный список слов</param>
        /// <param name="newIndexOfCheckedWord">новый сгенерированный индекс проверяемого слова</param>
        /// <returns></returns>
        public CheckWordsViewModel GetCheckWordsViewModel(int idWord, int allQuestion, int goodAnswers, int badAnswers, string grades, int idSelectedAnswer, List<Word> newRandomWords, int newIndexOfCheckedWord)
        {
            var viewModel = new CheckWordsViewModel();

            viewModel.IndexOfCheckedWord = idWord;
            viewModel.AllQuestionsNumber = allQuestion;
            viewModel.GoodAnswersNumber = goodAnswers;
            viewModel.BadAnswersNumber = badAnswers;
            viewModel.Grades = grades;

            viewModel.AllQuestionsNumber++;

            if (idSelectedAnswer == viewModel.IndexOfCheckedWord)
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
            viewModel.SelectedWords = newRandomWords;

            return viewModel;

        }
    }
}
