namespace MyDictionary.ViewModels
{
    public class EditItemsViewModel
    {
        public string TypeOfItem { get; set; }
        public string RusValue { get; set; }
        public string EngValue { get; set; }

        public EditItemsViewModel() { }

        public EditItemsViewModel(string type) 
        {
            TypeOfItem = type;
        }
    }
}
