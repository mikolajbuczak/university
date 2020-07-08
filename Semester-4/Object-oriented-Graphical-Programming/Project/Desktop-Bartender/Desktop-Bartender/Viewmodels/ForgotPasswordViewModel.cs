using Desktop_Bartender.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Desktop_Bartender.Viewmodels
{
    class ForgotPasswordViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private RelayCommand _returnCOmmand;

        public RelayCommand ChangeViewToLogin
        {
            get
            {
                return _returnCOmmand
                       ?? (_returnCOmmand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Login");
                           }));
            }
        }

        public ForgotPasswordViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
