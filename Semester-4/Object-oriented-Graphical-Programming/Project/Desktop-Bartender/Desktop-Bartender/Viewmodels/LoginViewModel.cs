namespace Desktop_Bartender.Viewmodels
{
    using Desktop_Bartender.Helpers;
    using Desktop_Bartender.Models;
    using System.Windows.Input;
    using BaseViewModel;
    using GalaSoft.MvvmLight.Messaging;
    using System.Dynamic;

    class LoginViewModel : BaseViewModel.ViewModelBase
    {
        public static string username;
        private IFrameNavigationService _navigationService;

        //Zmienna zawierająca komunikat o błędzie w logowaniu:
        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        //Zmmienna zawierająca wpisane dane w polu login:
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

        //Zmmienna zawierająca wpisane dane w polu hasło:
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

        //Zmiana widoku do rejestracji:
        private ICommand _registerCommand;

        public ICommand ChangeViewToRegister
        {
            get
            {
                if(_registerCommand == null)
                {
                    _registerCommand = new BaseViewModel.RelayCommand(
                        arg =>
                        {
                            _navigationService.NavigateTo("Register");
                            Login = Desktop_Bartender.Properties.Resources.Empty;
                            Password = Desktop_Bartender.Properties.Resources.Empty;
                            ErrorMessage = Desktop_Bartender.Properties.Resources.Empty;
                        },
                        arg => true);
                }
                return _registerCommand;
            }
        }

        //Przejście do przypomnienia hasła:
        private ICommand _forgotPassword;

        public ICommand ChangeViewToForgotPassword
        {
            get
            {
                if (_forgotPassword == null)
                {
                    _forgotPassword = new BaseViewModel.RelayCommand(
                        arg =>
                        {
                            _navigationService.NavigateTo("ForgotPassword");
                            Login = Desktop_Bartender.Properties.Resources.Empty;
                            Password = Desktop_Bartender.Properties.Resources.Empty;
                            ErrorMessage = Desktop_Bartender.Properties.Resources.Empty;
                        },
                        arg => true);
                }
                return _forgotPassword;
            }
        }

        //Zmiana widoku do IngredientsView:
        private ICommand _ingredientsCommand;
        public ICommand ChangeViewToIngredients
        {
            get
            {
                if (_ingredientsCommand == null)
                {
                    _ingredientsCommand = new BaseViewModel.RelayCommand(
                        arg =>
                        {
                            if(model.MatchData(Login, Password))
                            {
                                _navigationService.NavigateTo("Ingredients");
                                username = Login;
                                Messenger.Default.Send(username);
                                Login = Desktop_Bartender.Properties.Resources.Empty;
                                Password = Desktop_Bartender.Properties.Resources.Empty;
                                ErrorMessage = Desktop_Bartender.Properties.Resources.Empty;
                            }
                            else
                            {
                                Login = Desktop_Bartender.Properties.Resources.Empty;
                                Password = Desktop_Bartender.Properties.Resources.Empty;
                                ErrorMessage = Desktop_Bartender.Properties.Resources.InvalidLoginPass;
                            }
                        },
                        arg => !(string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password)));
                }
                return _ingredientsCommand;
            }
        }

        private Model model = null;

        //Konstruktor:
        public LoginViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            model = Model.Instance;
        }
    }
}
