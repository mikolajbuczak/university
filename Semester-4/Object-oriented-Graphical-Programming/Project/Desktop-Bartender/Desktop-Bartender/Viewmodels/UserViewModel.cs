using Desktop_Bartender.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Desktop_Bartender.Viewmodels
{
    class UserViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

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

        private RelayCommand _cocktailCommand;

        public RelayCommand ChangeViewToCocktail
        {
            get
            {
                return _cocktailCommand
                       ?? (_cocktailCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Cocktail");
                           }));
            }
        }
        private RelayCommand _loginCommand;
        public RelayCommand Logout
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
        public UserViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
