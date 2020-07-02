using Desktop_Bartender.Viewmodels.Base;
using System.Windows;
using System.Windows.Input;

namespace Desktop_Bartender.Viewmodels
{
    class LoginViewModel : ViewModelBase
    {
        private ICommand changeViewToRegister = null;
        public ICommand ChangeViewToRegister
        {
            get
            {
                if (changeViewToRegister == null)
                {
                    changeViewToRegister = new RelayCommand(
                        arg => ((MainViewModel)Application.Current.MainWindow.DataContext).CurrentViewModel = new RegisterViewModel(),
                        arg => true);
                }
                return changeViewToRegister;
            }
        }
    }
}
