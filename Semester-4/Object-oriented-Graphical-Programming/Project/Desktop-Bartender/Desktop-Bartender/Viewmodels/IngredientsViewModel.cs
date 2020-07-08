using Desktop_Bartender.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Desktop_Bartender.Viewmodels
{
    class IngredientsViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private RelayCommand _userCommand;

        public RelayCommand ChangeViewToUser
        {
            get
            {
                return _userCommand
                       ?? (_userCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("User");
                           }));
            }
        }

        private RelayCommand _loginCommand;

        public RelayCommand ChangeViewToLogin
        {
            get
            {
                return _loginCommand
                       ?? (_loginCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Login");
                           }));
            }
        }

        private RelayCommand _cocktailCommand;

        public RelayCommand ChangeViewToCocktailList
        {
            get
            {
                return _cocktailCommand
                       ?? (_cocktailCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("CocktailList");
                           }));
            }
        }

        public IngredientsViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
