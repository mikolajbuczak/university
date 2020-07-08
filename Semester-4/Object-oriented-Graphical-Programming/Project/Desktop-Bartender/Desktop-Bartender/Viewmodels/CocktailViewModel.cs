using Desktop_Bartender.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Desktop_Bartender.Viewmodels
{
    class CocktailViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private RelayCommand _goBack;

        public RelayCommand GoBack
        {
            get
            {
                return _goBack
                       ?? (_goBack = new RelayCommand(
                           () =>
                           { if (IngredientsViewModel.FromIngredients == true)
                               {
                                   _navigationService.NavigateTo("Ingredients");
                               }
                             else
                               _navigationService.NavigateTo("User");
                           }));
            }
        }

        public CocktailViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
