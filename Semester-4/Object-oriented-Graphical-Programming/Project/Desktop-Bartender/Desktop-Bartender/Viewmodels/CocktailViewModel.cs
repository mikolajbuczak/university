namespace Desktop_Bartender.Viewmodels
{
    using Desktop_Bartender.Helpers;
    using System.Windows.Input;
    using BaseViewModel;
    class CocktailViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

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
                            if (IngredientsViewModel.FromIngredients == true)
                            {
                                _navigationService.NavigateTo("Ingredients");
                            }
                            else
                                _navigationService.NavigateTo("User");
                        },
                        arg => true);
                }
                return _goBack;
            }
        }

        public CocktailViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
