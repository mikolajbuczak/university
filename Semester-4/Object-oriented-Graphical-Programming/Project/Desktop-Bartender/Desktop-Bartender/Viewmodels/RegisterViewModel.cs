namespace Desktop_Bartender.Viewmodels
{
    using Desktop_Bartender.Helpers;
    using Desktop_Bartender.Models;
    using System.Windows.Input;
    using BaseViewModel;
    class RegisterViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private string error = null;
        public string Error
        {
            get => error;
            set
            {
                error = value;
                OnPropertyChanged(nameof(Error));
            }
        }

        private string login = string.Empty;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(Login);
            }
        }

        private string password = string.Empty;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(Password);
            }
        }

        private string confirmPassword = string.Empty;
        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                confirmPassword = value;
                OnPropertyChanged(ConfirmPassword);
            }
        }

        private ICommand _register;
        public ICommand Register
        {
            get
            {
                if(_register == null)
                {
                    _register = new RelayCommand(
                        arg =>
                        {
                            if (model.FindUser(Login) == null)
                            {
                                if (model.AddUser(Login, Password))
                                {
                                    model.Update();
                                    Error = Properties.Resources.Success;
                                    Login = Properties.Resources.Empty;
                                    Password = Properties.Resources.Empty;
                                    ConfirmPassword = Properties.Resources.Empty;
                                }
                                else
                                {
                                    Error = Properties.Resources.Failure;
                                    Login = Properties.Resources.Empty;
                                    Password = Properties.Resources.Empty;
                                    ConfirmPassword = Properties.Resources.Empty;
                                }
                                    
                            }
                            else
                            {
                                Error = Properties.Resources.AlreadyRegistered;
                                Login = Properties.Resources.Empty;
                                Password = Properties.Resources.Empty;
                                ConfirmPassword = Properties.Resources.Empty;
                            }
                        },
                        arg => !((string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))) && Password.Length > 5 && Password == ConfirmPassword);
                }
                return _register;
            }
        }

        private ICommand _goBack;
        public ICommand GoBack
        {
            get
            {
                if (_goBack == null)
                {
                    _goBack = new RelayCommand(
                        arg =>
                        {
                            _navigationService.NavigateTo("Login");
                            Error = Properties.Resources.Empty;
                            Login = Properties.Resources.Empty;
                            Password = Properties.Resources.Empty;
                            ConfirmPassword = Properties.Resources.Empty;
                        },
                        arg => true);
                }
                return _goBack;
            }
        }

        private Model model = null;

        public RegisterViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            model = Model.Instance;
        }
    }
}
