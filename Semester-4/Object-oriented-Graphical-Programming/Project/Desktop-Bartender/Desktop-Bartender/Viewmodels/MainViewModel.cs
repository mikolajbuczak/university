using Desktop_Bartender.Viewmodels.Base;

namespace Desktop_Bartender.Viewmodels
{
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;

        public MainViewModel()
        {
            currentViewModel = new LoginViewModel();
        }

        public LoginViewModel MainScreenViewModel { get; set; }

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
    }
}
