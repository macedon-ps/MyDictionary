using System.ComponentModel.DataAnnotations;

namespace MyDictionary.ViewModels
{
    public class ErrorViewModel
    {
        /// <summary>
        /// ��������� �� ������
        /// </summary>
        [Display(Name = "��������� �� ������")]
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// ���� � ����� ������������ ������
        /// </summary>
        [Display(Name = "���� � ����� ������")]
        public DateTime DateTimeError { get; set; }

        public ErrorViewModel(string? errorMessage)
        {
            DateTimeError = DateTime.Now;
            ErrorMessage = errorMessage;
        }
    }
}
