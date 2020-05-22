namespace MiniTC.ViewModels
{
    using BaseClass;
    using System.Windows.Input;
    internal partial class MainVM : ViewModelBase
    {
        ICommand listClick = null;

        public ICommand ListClick
        {
            get
            {
                if (listClick == null)
                {
                    listClick = new RelayCommand(
                        arg => {
                            
                            Players.Add(new PlayerViewModel(new Player(CurrentFirstName.Trim(), CurrentLastName.Trim(), CurrentAge, CurrentWeight)));
                            CurrentFirstName = defaultFirstName;
                            CurrentLastName = defaultLastName;
                            CurrentAge = defaultAge;
                            CurrentWeight = defaultWeight;
                            CurrentIndex = defaultIndex;
                            OnPropertyChanged(nameof(CurrentFirstName), nameof(CurrentLastName), nameof(CurrentAge), nameof(CurrentWeight), nameof(CurrentIndex));
                        },
                        arg => !(string.IsNullOrEmpty(CurrentFirstName) ||
                                CurrentFirstName == defaultFirstName ||
                                string.IsNullOrEmpty(CurrentLastName) ||
                                CurrentLastName == defaultLastName ||
                                CheckIfExisits(CurrentFirstName, CurrentLastName, CurrentAge, CurrentWeight)));
                }
                return listClick;
            }
        }
    }
}
