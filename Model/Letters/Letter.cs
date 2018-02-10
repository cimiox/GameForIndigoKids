using System.ComponentModel;

namespace Model.Letters
{
    public class Letter : INotifyPropertyChanged
    {
        public char Character { get; set; }

        public Letter(char character)
        {
            Character = character;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
