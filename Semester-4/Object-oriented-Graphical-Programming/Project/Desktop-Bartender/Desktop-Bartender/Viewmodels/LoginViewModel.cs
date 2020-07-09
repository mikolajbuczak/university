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
        private IFrameNavigationService _navigationService;
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

        public LoginViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            model = Model.Instance;
        }
    }
}
