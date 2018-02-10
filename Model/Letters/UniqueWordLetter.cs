namespace Model.Letters
{
    public class UniqueWordLetter : Letter
    {
        private bool isOpen;
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                OnPropertyChanged("IsOpen");
            }
        }

        public UniqueWordLetter(char character)
            : base(character)
        {
        }
    }
}
