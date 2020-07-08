using Desktop_Bartender.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Desktop_Bartender.Viewmodels
{
    class RegisterViewModel : ViewModelBase
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
                    {
                        _navigationService.NavigateTo("Login");
                    }));
            }
        }

        public RegisterViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
