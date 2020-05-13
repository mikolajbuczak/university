namespace Football_Team_MVVM.ViewModels
{
    using BaseClass;
    using Models;
    using System.Windows.Input;
    internal partial class DisplayViewModel : ViewModelBase
    {
        private ICommand addPlayer = null;
        private ICommand modifyPlayer = null;
        private ICommand deletePlayer = null;

        private ICommand clearFirstName = null;
        private ICommand clearLastName = null;
        private ICommand loadPlayer = null;

        public ICommand AddPlayer
        {
            get
            {
                if (addPlayer == null)
                {
                    addPlayer = new RelayCommand(
                        arg => { Players.Add(new PlayerViewModel(new Player(CurrentFirstName, CurrentLastName, CurrentAge, CurrentWeight))); },
                        arg => !(string.IsNullOrEmpty(CurrentFirstName) || CurrentFirstName == "Enter the first name"
                                 || string.IsNullOrEmpty(CurrentLastName) || CurrentLastName == "Enter the last name"));
                }
                return addPlayer;
            }
        }

        public ICommand DeletePlayer
        {
            get
            {
                if (deletePlayer == null)
                {
                    deletePlayer = new RelayCommand(
                        arg =>
                        {
                            players.RemoveAt(currentIndex);
                            OnPropertyChanged(nameof(players));
                        },
                        arg => CurrentIndex != -1);
                }
                return deletePlayer;
            }
        }

        public ICommand ClearFirstName
        {
            get
            {
                if (clearFirstName == null)
                {
                    clearFirstName = new RelayCommand(
                        arg =>
                        {
                            CurrentFirstName = null;
                            OnPropertyChanged(nameof(CurrentFirstName));
                        },
                        arg => CurrentFirstName == "Enter the first name");
                }
                return clearFirstName;
            }
        }

        public ICommand ClearLastName
        {
            get
            {
                if (clearLastName == null)
                {
                    clearLastName = new RelayCommand(
                        arg =>
                        {
                            CurrentLastName = null;
                            OnPropertyChanged(nameof(CurrentLastName));
                        },
                        arg => CurrentLastName == "Enter the last name");
                }
                return clearLastName;
            }
        }
    }
}
