namespace BlazorStateManagement.Core
{
    public class AppStateContainer
    {
        public event Action? OnShowAuthorChanged;
        public event Action? OnUserDataChanged;

        private bool _showAuthorName = false;
        public bool ShowAuthorName 
        {
            get => _showAuthorName;
            set 
            { 
                _showAuthorName = value;
                OnShowAuthorChanged?.Invoke();
            } 
        }

        private Person _user = new();
        public Person User
        {
            get => _user;
            set
            {
                _user = value;
                OnUserDataChanged?.Invoke();
            }
        }

        #region Hidden Data
        public readonly string[] NameOptions = new string[] 
        {
            "Jack",
            "John",
            "Mark",
            "Lewis",
            "James",
            "Brian",
            "Daniel",
            "Carlton",
            "Thomas",
            "Christopher",
            "Alexander",
            "Nigel",
            "George",
            "Lukas",
            "Oskar",
        };
        #endregion
    }
}
