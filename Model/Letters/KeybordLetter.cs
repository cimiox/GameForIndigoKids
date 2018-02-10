namespace Model.Letters
{
    public class KeybordLetter : Letter
    {
        private bool isClicked;
        public bool IsClicked
        {
            get { return isClicked; }
            set
            {
                isClicked = value;
                OnPropertyChanged("IsClicked");
            }
        }

        public KeybordLetter(char character)
            : base(character)
        {
        }
    }
}
