namespace Desktop_Bartender.Viewmodels
{
    using Desktop_Bartender.Helpers;
    using System.Collections.ObjectModel;
    using Desktop_Bartender.Models;
    using System.Windows.Input;
    using BaseViewModel;
    using GalaSoft.MvvmLight.Messaging;

    class CocktailViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        //Komenda powrotu do wcześniejszego widoku:
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
                            {
                                _navigationService.NavigateTo("User");
                            }

                        },
                        arg => true);
                }
                return _goBack;
            }
        }

        //Nazwa zaznaczonego z listy drinka:
        private string name = IngredientsViewModel.DrinkToCoctail;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        //Lista składników:
        private ObservableCollection<string> ingredients = new ObservableCollection<string>();
        public ObservableCollection<string> Ingredients
        {
            get => ingredients;
            set
            {
                ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        //Lista narzędzi:
        private ObservableCollection<string> tools = new ObservableCollection<string>();
        public ObservableCollection<string> Tools
        {
            get => tools;
            set
            {
                tools = value;
                OnPropertyChanged(nameof(Tools));
            }
        }

        //Zmienna zawierająca instrukcję drinka:
        private string instruction = null;
        public string Instruction
        {
            get => instruction;
            set
            {
                instruction = value;
                OnPropertyChanged(nameof(Instruction));
            }
        }

        private Model model = null;
        //Konstruktor:
        public CocktailViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            model = Model.Instance;
            Messenger.Default.Register<string>(this, this.GetString);
            Ingredients = model.GetDrinkIngredients(Name);
            Tools = model.FindTools(Name);
            Instruction = model.FindInstruction(Name);
        }

        //Komenda dodanie ulubionego drinka:
        public ICommand _addFavorite;

        public ICommand AddFavorite
        {
            get
            {
                if (_addFavorite == null)
                {
                    _addFavorite = new RelayCommand(
                        arg =>
                        {
                            model.AddFavorite(model.FindUserID(LoginViewModel.username), model.FindDrinkID(Name));
                            model.Update();
                            Messenger.Default.Send(Name);
                        },
                        arg => !model.GetFavorite(LoginViewModel.username).Contains(Name));
                }
                return _addFavorite;
            }
        }

        private void GetString(string _name)
        {
            Name = _name;
            Ingredients = model.GetDrinkIngredients(Name);
            Tools = model.FindTools(Name);
            Instruction = model.FindInstruction(Name);
        }
    }
}
