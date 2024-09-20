using MyDictionary.Interfaces;
using MyDictionary.Models;
using MyDictionary.ViewModels;

namespace MyDictionary.Repository
{
    public class WordsRepository : IWordsInterface
    {
        /// <summary>
        /// количество вариантов для перевода слова
        /// </summary>
        private int numberOfWords { get; set; } = 5;

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
            new Word{Id = 20, RusValue="зависеть от", EngValue="addicted to", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 21, RusValue="злиться на", EngValue="angry with", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 22, RusValue="злиться из-за", EngValue="angry about", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 23, RusValue="известный чем-то", EngValue="famous for", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 24, RusValue="бояться чего-то", EngValue="afraid of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 25, RusValue="гордиться чем-то", EngValue="proud of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 26, RusValue="сожалеть о", EngValue="sorry about", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 27, RusValue="интересоваться чем-то", EngValue="interested in", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 28, RusValue="полон чего то", EngValue="full of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 29, RusValue="обожать что-то", EngValue="fond of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 30, RusValue="хорош в", EngValue="good at", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 31, RusValue="плох в", EngValue="bad at", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 32, RusValue="женат на", EngValue="married to", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 33, RusValue="по-доброму с", EngValue="kind of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 34, RusValue="добр к", EngValue="kind to", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 35, RusValue="мило с", EngValue="nice of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 36, RusValue="мил к", EngValue="nice to", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 37, RusValue="увлекаться чем-то", EngValue="keen on", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 38, RusValue="сыт по горло чем-то", EngValue="fed up with", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 39, RusValue="устал от", EngValue="tired of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 40, RusValue="в восторге от", EngValue="excited about", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 41, RusValue="без ума от", EngValue="crazy about", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 42, RusValue="рад за кого-то", EngValue="happy for", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 43, RusValue="рад чему-то", EngValue="happy about", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 44, RusValue="удовлетворен чем-то", EngValue="satisfied with", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 45, RusValue="разочарован чем-то", EngValue="disappointed about", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 46, RusValue="шокирован чем-то", EngValue="shocked by", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 47, RusValue="типично для", EngValue="typical of", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 48, RusValue="удивлен чем-то", EngValue="surprised by", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 49, RusValue="отличается от", EngValue="different from", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 50, RusValue="подписан на", EngValue="subscribed to", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 51, RusValue="беспокоиться о", EngValue="worried about", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},
            new Word{Id = 52, RusValue="готов к", EngValue="ready for", Transcription="", PartOfSpeech=PartsOfSpeech.Adjective},

        };


        public int GetNumberOfWords()
        {
            return this.numberOfWords;
        }

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
            //var currentRandomPartOfSpeech = rand.Next(numberPartOfSpeach);
            // м. вручную выставить: 0 - существительные, 1 - глаголы, 2 - прилагательные
            var currentRandomPartOfSpeech = 2;

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
