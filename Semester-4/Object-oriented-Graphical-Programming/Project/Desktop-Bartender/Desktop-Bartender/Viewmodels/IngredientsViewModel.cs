namespace Desktop_Bartender.Viewmodels
{
    using Desktop_Bartender.Helpers;
    using Desktop_Bartender.Models;
    using System.Windows.Input;
    using BaseViewModel;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Renci.SshNet.Messages;
    using System.Windows;

    class IngredientsViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        public static bool FromIngredients;

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

        private ICommand _userCommand = null;

        public ICommand ChangeViewToUser
        {
            get
            {
                if (_userCommand == null)
                {
                    _userCommand = new RelayCommand(
                        arg =>
                        {
                            _navigationService.NavigateTo("User");
                        },
                        arg => true);
                }
                return _userCommand;
            }
        }

        private ICommand _loginCommand = null;

        public ICommand ChangeViewToLogin
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(
                        arg =>
                        {
                            _navigationService.NavigateTo("Login");
                        },
                        arg => true);
                }
                return _loginCommand;
            }
        }

        private ICommand _cocktailCommand = null;

        public ICommand ChangeViewToCocktailList
        {
            get
            {
                if (_cocktailCommand == null)
                {
                    _cocktailCommand = new RelayCommand(
                        arg =>
                        {
                            _navigationService.NavigateTo("CocktailList");
                        },
                        arg => Items.Count > 0);
                }
                return _cocktailCommand;
            }
        }

        private ICommand _deleteIngredient = null;
        public ICommand DeleteIngredient
        {
            get
            {
                if (_deleteIngredient == null)
                {
                    _deleteIngredient = new RelayCommand(
                        arg =>
                        {
                            Items.RemoveAt(Index);
                            Index = -1;
                        },
                        arg => Index != -1);
                }
                return _deleteIngredient;
            }
        }

        private string category = null;
        public string Category
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        public ICommand _clickCategories = null;

        public ICommand ClickCategories
        {
            get
            {
                if (_clickCategories == null)
                {
                    _clickCategories = new RelayCommand(
                        arg =>
                        {
                            MessageBox.Show("tak");
                            Ingredients = model.FindIngredients(Category);
                        },
                        arg => true);
                }
                return _clickCategories;
            }
        }


        public List<string> Categories { get; set; } = new List<string>();
        public List<string> Ingredients { get; set; } = new List<string>();

        private Model model = null;

        public IngredientsViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            model = Model.Instance;
            model.FindCategories(Categories);
            FromIngredients = false;
            Items.Add("MuJ sKu4Dn1K");
        }
    }
}
