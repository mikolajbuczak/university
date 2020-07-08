using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Desktop_Bartender.Helpers;

namespace Desktop_Bartender.Viewmodels
{
    class LoginViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private RelayCommand _registerCommand;

        public RelayCommand ChangeViewToRegister
        {
            get
            {
                return _registerCommand
                       ?? (_registerCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Register");
                           }));
            }
        }

        private RelayCommand _forgotPassword;

        public RelayCommand ChangeViewToForgotPassword
        {
            get
            {
                return _forgotPassword
                       ?? (_forgotPassword = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("ForgotPassword");
                           }));
            }
        }

        private RelayCommand _ingredientsCommand;
        public RelayCommand ChangeViewToIngredients
        {
            get
            {
                return _ingredientsCommand
                       ?? (_ingredientsCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Ingredients");
                           }));
            }
        }

        public LoginViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
   
}
