using MyDictionary.Interfaces;
using MyDictionary.Models;

namespace MyDictionary.Repository
{
    public class WordsRepository : IWordsInterface
    {
        public List<Word> words = new()
        {
            new Word{Id = 0, RusValue="стол", EngValue="table", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 1, RusValue="стул", EngValue="chair", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 2, RusValue="ручка", EngValue="pen", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 3, RusValue="карандаш", EngValue="pencil", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 4, RusValue="книга", EngValue="book", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 5, RusValue="тетрадь", EngValue="copybook", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 6, RusValue="диван", EngValue="sofa", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 7, RusValue="шкаф", EngValue="rubber", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 8, RusValue="блокнот", EngValue="notebook", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
            new Word{Id = 9, RusValue="резинка", EngValue="rubber", Transcription="", PartOfSpeech=PartsOfSpeech.Noun},
        };

        public (int, int) Get2Numbers(int middleNumber, int interval)
        {
            var numberOfAllWords = words.Count;

            (int start, int end) startAndEnd = (0, 0);
            
            if (middleNumber - interval / 2 < 0)
            {
                startAndEnd.start = 0;
                startAndEnd.end = startAndEnd.start + interval - 1;
            }
            else if(middleNumber + interval / 2 > numberOfAllWords-1)
            {
                startAndEnd.end = numberOfAllWords - 1;
                startAndEnd.start = startAndEnd.end - interval + 1;
            }
            else if ((middleNumber - interval / 2 >= 0) && (middleNumber + interval / 2 <= numberOfAllWords-1))
            { 
                startAndEnd.start = middleNumber - interval /2;
                startAndEnd.end = middleNumber + interval /2;
            }

            return startAndEnd;
        }

        public List<Word> GetAllWords()
        {
            return words;
        }

        public Word GetWord()
        {
            var rand = new Random();
            var numberOfAllWords = words.Count;
            var randomNumber = rand.Next(numberOfAllWords);
            var middleNumberWord = words.FirstOrDefault(x => x.Id == randomNumber);

            return middleNumberWord;
        }

        public Word GetWord(int id)
        {
            return words.FirstOrDefault(x => x.Id == id);
        }

        public List<Word> GetAllWordsByType(int parthOfSpeach)
        {
            throw new NotImplementedException();
        }

        public List<Word> GetWordsByType(int middleNumber, int interval, int parthOfSpeach)
        {
            var startAndEnd = Get2Numbers(middleNumber, interval);

            var words = new List<Word>();
            
            for(int i = startAndEnd.Item1; i < startAndEnd.Item2+1; i++)
            {
                words.Add(GetWord(i));
            }

            return words;
        }
    }
}
