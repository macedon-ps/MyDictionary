using System.ComponentModel.DataAnnotations;

namespace MyDictionary.Models
{
    public class Word
    {
        /// <summary>
        /// Идентификатор слова
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Слово на русском языке
        /// </summary>
        [Required(ErrorMessage = "Введите слово на русском языке")]
        [Display(Name = "Слово на русском языке")]
        [StringLength(30, ErrorMessage = "Слово не должно содержать более 30 символов")]
        public string RusValue { get; set; } = null!;

        /// <summary>
        /// Слово на английском языке
        /// </summary>
        [Required(ErrorMessage = "Введите слово на английском языке")]
        [Display(Name = "Слово на английском языке")]
        [StringLength(30, ErrorMessage = "Слово не должно содержать более 30 символов")]
        public string EngValue { get; set; } = null!;

        /// <summary>
        /// Транскрипция
        /// </summary>
        [Display(Name = "Транскрипция")]
        [StringLength(20, ErrorMessage = "Транскрипция не должна содержать более 20 символов")]
        public string Transcription { get; set; } = "";

        /// <summary>
        /// Часть речи
        /// </summary>
        [Required(ErrorMessage = "Введите часть речи")]
        [Display(Name = "Часть речи")]
        public PartsOfSpeech PartOfSpeech { get; set; } 

        public Word() { }

    }
}
