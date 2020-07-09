namespace Desktop_Bartender.Viewmodels
{
    using Desktop_Bartender.Helpers;
    using System.Windows.Input;
    using BaseViewModel;
    using System.Collections.ObjectModel;
    using GalaSoft.MvvmLight.Messaging;
    using Desktop_Bartender.Models;
    using System.Windows.Documents;

    class UserViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        public static ObservableCollection<string> list = new ObservableCollection<string>();

        //Collection danych z listy:
        private ObservableCollection<string> items = new ObservableCollection<string>();
        public ObservableCollection<string> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        //Zmienna z indeksem zaznaczonego przedmitu z listy:
        private int index = -1;
        public int Index
        {
            get => index;
            set
            {
                index = value;
                OnPropertyChanged(nameof(Index));
            }
        }

        //Komenda powrotu:
        private ICommand _ingredientsCommand;

        public ICommand ChangeViewToIngredients
        {
            get
            {
                if (_ingredientsCommand == null)
                {
                    _ingredientsCommand = new RelayCommand(
                        arg =>
                        {
                            _navigationService.NavigateTo("Ingredients");
                        },
                        arg => true);
                }
                return _ingredientsCommand;
            }
        }

        //Komenda usunięcia zaznaczonego drinka:
        private ICommand _deleteFavourite;

        public ICommand DeleteFavourite
        {
            get
            {
                if (_deleteFavourite == null)
                {
                    _deleteFavourite = new RelayCommand(
                        arg =>
                        {
                            model.DeleteFavorite(model.FindUserID(LoginViewModel.username), model.FindDrinkID(Items[Index]));
                            model.Update();
                            Items.RemoveAt(Index);
                            Index = -1;
                        },
                        arg => Index != -1);
                }
                return _deleteFavourite;
            }
        }

        //Komenda wylogowania:
        private ICommand _loginCommand;
        public ICommand Logout
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(
                        arg =>
                        {
                            _navigationService.NavigateTo("Login");
                            Clear(true);
                            Messenger.Default.Send(true);
                        },
                        arg => true);
                }
                return _loginCommand;
            }
        }

        //Komenda kliknięcia w wybrany przedmiot z listy drinków:
        private ICommand _clickFav = null;
        public ICommand ClickFav
        {
            get
            {
                if (_clickFav == null)
                {
                    _clickFav = new RelayCommand(
                        arg =>
                        {
                            IngredientsViewModel.FromIngredients = false;
                            _navigationService.NavigateTo("Cocktail");
                            IngredientsViewModel.DrinkToCoctail = Items[Index];
                            IngredientsViewModel.Send();
                            Index = -1;
                            Items = list;
                        },
                        arg => true);
                }
                return _clickFav;
            }
        }

        private string name;

        private Model model = null;

        //Konstruktor:
        public UserViewModel(IFrameNavigationService navigationService)
        {
            model = Model.Instance;
            _navigationService = navigationService;
            Messenger.Default.Register<string>(this, this.GetFav);
            Messenger.Default.Register<bool>(this, this.Clear);
            name = LoginViewModel.username;
            Items = model.GetFavorite(name);
            list = Items;
        }

        public void GetFav(string _name)
        {
            name = _name;
            Items = model.GetFavorite(name);
        }

        public void Clear(bool flag)
        {
            Items.Clear();
            Index = -1;
        }
    }
}
