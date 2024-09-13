namespace MyDictionary.Models
{
    public class Word
    {
        public int Id { get; set; }

        public string RusValue { get; set; } = null!;   

        public string EngValue { get; set; } = null!;

        public string Transcription { get; set; } = "";

        public PartsOfSpeech PartOfSpeech { get; set; } 

        public Word() { }

    }
}
