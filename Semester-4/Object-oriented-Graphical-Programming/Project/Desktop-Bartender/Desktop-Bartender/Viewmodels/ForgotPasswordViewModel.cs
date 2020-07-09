namespace Desktop_Bartender.Viewmodels
{
    using Desktop_Bartender.DAL.Entity;
    using Desktop_Bartender.Helpers;
    using Desktop_Bartender.Models;
    using System.Windows.Input;
    using BaseViewModel;
    class ForgotPasswordViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        //String zawierający przypomniane hasło:
        private string forgottenPassword = null;
        public string ForgottenPassword
        {
            get => forgottenPassword;
            set
            {
                forgottenPassword = value;
                OnPropertyChanged(nameof(ForgottenPassword));
            }
        }

        //Zmienna zawierająca informację o błędzie użytkownika:
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

        //String zawierający wpisane dane w polu Login:
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

        //Przypomnienie hasła:
        private ICommand _remindPassword;

        public ICommand RemindPassword
        {
            get
            {
                if (_remindPassword == null)
                {
                    _remindPassword = new RelayCommand(
                        arg =>
                        {
                            User user = model.FindUser(Login);
                            if (user != null)
                            {
                                ForgottenPassword = $"{Desktop_Bartender.Properties.Resources.ReturnedPassword} {user.Password}";
                                Error = Properties.Resources.Empty;
                            }
                            else
                            {
                                Error = Properties.Resources.NoMatch;
                                ForgottenPassword = Properties.Resources.Empty;
                            }
                        },
                        arg => !(string.IsNullOrEmpty(Login)));
                }
                return _remindPassword;
            }
        }

        //Komenda powrótu do LoginView:
        private ICommand _returnCOmmand;

        public ICommand ChangeViewToLogin
        {
            get
            {
                if (_returnCOmmand == null)
                {
                    _returnCOmmand = new RelayCommand(
                        arg =>
                        {
                            _navigationService.NavigateTo("Login");
                            ForgottenPassword = Desktop_Bartender.Properties.Resources.Empty;
                            Error = Properties.Resources.Empty;
                            Login = Properties.Resources.Empty; 
                        },
                        arg => true);
                }
                return _returnCOmmand;
            }
        }

        private Model model = null;

        //Konstruktor:
        public ForgotPasswordViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            model = Model.Instance;
        }
    }
}
