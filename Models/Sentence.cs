using System.ComponentModel.DataAnnotations;

namespace MyDictionary.Models
{
    public class Sentence
    {
        /// <summary>
        /// Идентификатор предложения
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Предложение на русском языке
        /// </summary>
        [Required(ErrorMessage = "Введите предложение на русском языке")]
        [Display(Name = "Предложение на русском языке")]
        [StringLength(200, ErrorMessage = "Предложение не должно содержать более 200 символов")]
        public string RusValue { get; set; } = null!;

        /// <summary>
        /// Предложение на анлийском языке
        /// </summary>
        [Required(ErrorMessage = "Введите предложение на английском языке")]
        [Display(Name = "Предложение на анлийском языке")]
        [StringLength(200, ErrorMessage = "Предложение не должно содержать более 200 символов")]
        public string EngValue { get; set; } = null!;

        /// <summary>
        /// Вид времени английского языка
        /// </summary>
        [Required(ErrorMessage = "Введите вид времени английского языка")]
        [Display(Name = "Вид времени английского языка")]
        public Tenses Tense {  get; set; } 

        public Sentence() { }
    }
}
