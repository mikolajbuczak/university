namespace Desktop_Bartender.Viewmodels
{
    using Desktop_Bartender.Helpers;
    using System.Windows.Input;
    using BaseViewModel;
    using System.Collections.ObjectModel;
    class UserViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private string login = null;

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string password = null;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private ObservableCollection<string> items = new ObservableCollection<string>();
        public ObservableCollection<string> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        private int index = -1;
        public int Index
        {
            get => index;
            set
            {
                index = value;
                OnPropertyChanged(nameof(Index));
            }
        }

        private ICommand _ingredientsCommand;

        public ICommand ChangeViewToIngredients
        {
            get
            {
                if (_ingredientsCommand == null)
                {
                    _ingredientsCommand = new RelayCommand(
                        arg =>
                        {
                            _navigationService.NavigateTo("Ingredients");
                        },
                        arg => true);
                }
                return _ingredientsCommand;
            }
        }

        private ICommand _deleteFavourite;

        public ICommand DeleteFavourite
        {
            get
            {
                if (_deleteFavourite == null)
                {
                    _deleteFavourite = new RelayCommand(
                        arg =>
                        {
                            Items.RemoveAt(Index);
                            Index = -1;
                        },
                        arg => Index != -1);
                }
                return _deleteFavourite;
            }
        }
        private ICommand _loginCommand;
        public ICommand Logout
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(
                        arg =>
                        {
                            _navigationService.NavigateTo("Login");
                        },
                        arg => true);
                }
                return _loginCommand;
            }
        }

        private ICommand _changeCommand;
        public ICommand ChangeData
        {
            get
            {
                if (_changeCommand == null)
                {
                    _changeCommand = new RelayCommand(
                        arg =>
                        {
                            //Function
                        },
                        arg => !string.IsNullOrEmpty(Login) || (!string.IsNullOrEmpty(Password) && Password.Length > 5));
                }
                return _changeCommand;
            }
        }
        public UserViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            Items.Add("MuJ N4jL3pży K0kt4Jl");
        }
    }
}
