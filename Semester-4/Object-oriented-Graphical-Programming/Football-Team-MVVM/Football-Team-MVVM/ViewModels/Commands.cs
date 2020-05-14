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
        private ICommand setDefaultFirstName = null;
        private ICommand setDefaultLastName = null;
        private ICommand loadPlayer = null;

        public ICommand AddPlayer
        {
            get
            {
                if (addPlayer == null)
                {
                    addPlayer = new RelayCommand(
                        arg => { 
                            Players.Add(new PlayerViewModel(new Player(CurrentFirstName.Trim(), CurrentLastName.Trim(), CurrentAge, CurrentWeight)));
                            CurrentFirstName = defaultFirstName;
                            CurrentLastName = defaultLastName;
                            CurrentAge = defaultAge;
                            CurrentWeight = defaultWeight;
                            CurrentIndex = defaultIndex;
                            OnPropertyChanged(nameof(CurrentFirstName), nameof(CurrentLastName), nameof(CurrentAge), nameof(CurrentWeight), nameof(CurrentIndex));
                            },
                        arg => !(string.IsNullOrEmpty(CurrentFirstName) ||
                                CurrentFirstName == defaultFirstName || 
                                string.IsNullOrEmpty(CurrentLastName) || 
                                CurrentLastName == defaultLastName || 
                                CheckIfExisits(CurrentFirstName, CurrentLastName, CurrentAge, CurrentWeight)));
                }
                return addPlayer;
            }
        }

        public ICommand ModifyPlayer
        {
            get
            {
                if (modifyPlayer == null)
                {
                    modifyPlayer = new RelayCommand(
                        arg =>
                        {
                            PlayerViewModel player = players[CurrentIndex];
                            player.FirstName = CurrentFirstName;
                            player.LastName = CurrentLastName;
                            player.Age = CurrentAge;
                            player.Weight = CurrentWeight;

                            CurrentFirstName = defaultFirstName;
                            CurrentLastName = defaultLastName;
                            CurrentAge = defaultAge;
                            CurrentWeight = defaultWeight;
                            CurrentIndex = defaultIndex;
                            OnPropertyChanged(nameof(CurrentFirstName), nameof(CurrentLastName), nameof(CurrentAge), nameof(CurrentWeight), nameof(CurrentIndex));
                        },
                        arg => CurrentIndex != -1);
                }
                return modifyPlayer;
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
                            players.RemoveAt(CurrentIndex);
                            CurrentFirstName = defaultFirstName;
                            CurrentLastName = defaultLastName;
                            CurrentAge = defaultAge;
                            CurrentWeight = defaultWeight;
                            CurrentIndex = defaultIndex;
                            OnPropertyChanged(nameof(players), nameof(CurrentFirstName), nameof(CurrentLastName), nameof(CurrentAge), nameof(CurrentWeight), nameof(CurrentIndex));
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
                        arg => CurrentFirstName == defaultFirstName);
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
                        arg => CurrentLastName == defaultLastName);
                }
                return clearLastName;
            }
        }

        public ICommand SetDefaultFirstName
        {
            get
            {
                if (setDefaultFirstName == null)
                {
                    setDefaultFirstName = new RelayCommand(
                        arg =>
                        {
                            CurrentFirstName = defaultFirstName;
                            OnPropertyChanged(nameof(CurrentFirstName));
                        },
                        arg => string.IsNullOrEmpty(CurrentFirstName));
                }
                return setDefaultFirstName;
            }
        }

        public ICommand SetDefaultLastName
        {
            get
            {
                if (setDefaultLastName == null)
                {
                    setDefaultLastName = new RelayCommand(
                        arg =>
                        {
                            CurrentLastName = defaultLastName;
                            OnPropertyChanged(nameof(CurrentLastName));
                        },
                        arg => string.IsNullOrEmpty(CurrentLastName));
                }
                return setDefaultLastName;
            }
        }

        public ICommand LoadPlayer 
        {
            get
            {
                if (loadPlayer == null)
                {
                    loadPlayer = new RelayCommand
                    (
                        arg =>
                        {
                            PlayerViewModel player = players[CurrentIndex];
                            CurrentFirstName = player.FirstName;
                            CurrentLastName = player.LastName;
                            CurrentAge = player.Age;
                            CurrentWeight = player.Weight;
                            OnPropertyChanged(nameof(CurrentFirstName), nameof(CurrentLastName), nameof(CurrentAge), nameof(CurrentWeight));
                        },
                        arg => CurrentIndex != -1);
                }
                return loadPlayer;
            }
        }

        public ICommand SaveTeam
        {
            get 
            { 
                return new RelayCommand(
                    arg => SavePlayers(),
                    arg => true); 
            }
        }
    }
}