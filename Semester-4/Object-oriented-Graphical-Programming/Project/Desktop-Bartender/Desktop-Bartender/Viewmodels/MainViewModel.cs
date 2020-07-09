using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Desktop_Bartender.Helpers;
using Desktop_Bartender.Models;
using GalaSoft.MvvmLight.Messaging;

namespace Desktop_Bartender.Viewmodels
{
    public class MainViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private RelayCommand _loadedCommand;
        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Login");
                    }));
            }
        }

        public MainViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
