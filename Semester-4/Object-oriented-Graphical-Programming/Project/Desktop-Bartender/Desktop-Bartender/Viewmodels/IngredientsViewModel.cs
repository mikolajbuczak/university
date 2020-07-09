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
    using GalaSoft.MvvmLight.Messaging;

    class IngredientsViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        public static bool FromIngredients;
        public static string DrinkToCoctail;

        //Zmienna indeksu wybranego przedmiotu z listy:
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

        //Zmiana widoku do UserView:
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

        //Wylogowanie:
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
                            Clear(true);
                            Messenger.Default.Send(true);
                         },
                        arg => true);
                }
                return _loginCommand;
            }
        }

        //Tworzenie listy:
        private ICommand _cocktailCommand = null;

        public ICommand CreateList
        {
            get
            {
                if (_cocktailCommand == null)
                {
                    _cocktailCommand = new RelayCommand(
                        arg =>
                        {
                            if(Category == Properties.Resources.CategoryType)
                            {
                                Drinks = model.FindDrinksByTaste(Items);
                            }
                            else
                                Drinks = model.FindDrinks(Items);
                        },
                        arg => Items.Count > 0);
                }
                return _cocktailCommand;
            }
        }

        //Usunięcie składnika:
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

        //Kliknięcie w daną z listy kategorie:
        public ICommand ClickCategories
        {
            get
            {
                if (_clickCategories == null)
                {
                    _clickCategories = new RelayCommand(
                        arg =>
                        {
                            Ingredients = model.FindIngredients(Category);
                        },
                        arg => true);
                }
                return _clickCategories;
            }
        }

        private string ingredient = null;
        public string Ingredient
        {
            get => ingredient;
            set
            {
                ingredient = value;
                OnPropertyChanged(nameof(Ingredient));
            }
        }

        public ICommand _clickIngredients = null;

        public ICommand ClickIngredients
        {
            get
            {
                if (_clickIngredients == null)
                {
                    _clickIngredients = new RelayCommand(
                        arg =>
                        {
                            if(!Items.Contains(Ingredient) || Items.Count > 10)
                                Items.Add(Ingredient);
                        },
                        arg => true);
                }
                return _clickIngredients;
            }
        }

        public List<string> Categories { get; set; } = new List<string>();
        public ObservableCollection<string> ingredients = new ObservableCollection<string>();
        public ObservableCollection<string> Ingredients
        {
            get => ingredients;
            set
            {
                ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        private string drink = null;
        public string Drink
        {
            get => drink;
            set
            {
                drink = value;
                OnPropertyChanged(nameof(Drink));
            }
        }

        public ObservableCollection<string> drinks = new ObservableCollection<string>();
        public ObservableCollection<string> Drinks
        {
            get => drinks;
            set
            {
                drinks = value;
                OnPropertyChanged(nameof(Drinks));
            }
        }

        public ICommand _clickDrink = null;

        public ICommand ClickDrink
        {
            get
            {
                if (_clickDrink == null)
                {
                    _clickDrink = new RelayCommand(
                        arg =>
                        {
                            DrinkToCoctail = Drink;
                            Send();
                            FromIngredients = true;
                            _navigationService.NavigateTo("Cocktail");
                            Drink = null;
                        },
                        arg => !string.IsNullOrEmpty(Drink));
                }
                return _clickDrink;
            }
        }

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

        private Model model = null;

        //Konstruktor:
        public IngredientsViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            model = Model.Instance;
            model.FindCategories(Categories);
            Messenger.Default.Register<bool>(this, this.Clear);
            FromIngredients = true;
        }

        public static void Send()
        {
            Messenger.Default.Send(DrinkToCoctail);
        }
        public void Clear(bool flag)
        {
            Ingredients.Clear();
            Items.Clear();
            Drinks.Clear();
            Index = -1;
            Drink = null;
            Ingredient = null;
        }
    }
}
