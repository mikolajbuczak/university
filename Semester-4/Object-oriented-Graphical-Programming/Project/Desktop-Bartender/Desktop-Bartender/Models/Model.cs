namespace Desktop_Bartender.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Documents;
    using Desktop_Bartender.DAL.Entity;
    using Desktop_Bartender.DAL.Repositories;
    class Model
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<Drinktool> Drinktools { get; set; } = new ObservableCollection<Drinktool>();
        public ObservableCollection<Favorite> Favorites { get; set; } = new ObservableCollection<Favorite>();
        public ObservableCollection<Drink> Drinks { get; set; } = new ObservableCollection<Drink>();
        public ObservableCollection<Ingredient> Ingredients { get; set; } = new ObservableCollection<Ingredient>();
        public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();
        public ObservableCollection<Tool> Tools { get; set; } = new ObservableCollection<Tool>();

        private static Model instance = null;

        //Konstruktor Modelu, dopisanie do zmiennych danych z bazy:
        public Model()
        {
            var users = RepositoryUser.GetAllUsers();
            foreach (var user in users)
                Users.Add(user);

            var drinktools = RepositoryDrinktool.GetAllDrinkTools();
            foreach (var drinktool in drinktools)
                Drinktools.Add(drinktool);

            var favorites = RepositoryFavorite.GetAllFavorites();
            foreach (var favorite in favorites)
                Favorites.Add(favorite);

            var drinks = RepositoryDrink.GetAllDrinks();
            foreach (var drink in drinks)
                Drinks.Add(drink);

            var ingredients = RepositoryIngredient.GetAllIngredients();
            foreach (var ingredient in ingredients)
                Ingredients.Add(ingredient);

            var recipes = RepositoryRecipe.GetAllRecipes();
            foreach (var recipe in recipes)
                Recipes.Add(recipe);

            var tools = RepositoryTool.GetAllTools();
            foreach (var tool in tools)
                Tools.Add(tool);
        }

        //Ustawienie Singletonu:
        public static Model Instance
        {
            get
            {
                if (instance == null)
                    instance = new Model();
                return instance;
            }
        }

        public bool MatchData(string login, string passsword)
        {
            foreach (var u in Users)
            {
                if ((u.Login == login) && (u.Password == passsword))
                    return true;      
            }
            return false;
        }

        //Odnalezenie danych użytkownika z loginu:
        public User FindUser(string login)
        {
            foreach (var u in Users)
            {
                if ((u.Login == login))
                    return u;
            }
            return null;
        }

        //Dodanie użytkownika do bazy:
        public bool AddUser(string login, string password)
        {
            return RepositoryUser.AddUser(new User(login, password));
        }

        //Znalezenie kategorii składników:
        public void FindCategories(List<string> categories)
        {
            foreach (var i in Ingredients)
            {
                if (!categories.Contains(i.Category))
                    categories.Add(i.Category);
            }
            categories.Sort();
            categories.Add(Properties.Resources.CategoryType);
        }

        //Przypisanie składników do listy z danej kategorii:
        public ObservableCollection<string> FindIngredients(string category)
        {
            ObservableCollection<string> ingredients = new ObservableCollection<string>();
            
            if(category != Properties.Resources.CategoryType)
            {
                foreach (var i in Ingredients)
                {
                    if (category == i.Category)
                        ingredients.Add(i.Name);
                }
            }
            else
            {
                foreach(var i in Drinks)
                {
                    if (!ingredients.Contains(i.Taste))
                        ingredients.Add(i.Taste);
                }
            }

            return ingredients;
        }

        //Wypisanie drinków na podstawie składników (dopasowanie >= 0.5):
        public ObservableCollection<string> FindDrinks(ObservableCollection<string> ingredients)
        {
            ObservableCollection<string> drinks = new ObservableCollection<string>();

            foreach (var d in Drinks)
            {
                ObservableCollection<short?> ing = FindDrinkIngredients(d.ID);
                double percentOfIngredients = 0;
                foreach (var i in ingredients)
                {
                    if (ing.Contains(FindIngredientID(i)))
                        percentOfIngredients += 1;
                }
                percentOfIngredients /= ing.Count;
                if  (percentOfIngredients >= 0.5) 
                    drinks.Add(d.Name);
            }

            return drinks;
        }

        //Odnalezienie składników na podstawie ID drinka:
        public ObservableCollection<short?> FindDrinkIngredients(short? drinkID)
        {
            ObservableCollection<short?> ingredients = new ObservableCollection<short?>();
            foreach(var r in Recipes)
            {
                if (r.Id_Drink == drinkID) 
                    ingredients.Add(r.Id_Ingredient);
            }
            return ingredients;
        }

        //Odnalezienie składników drinka z nazwy drinka:
        public ObservableCollection<string> GetDrinkIngredients(string name)
        {
            ObservableCollection<string> ingredients = new ObservableCollection<string>();
            short? id = FindDrinkID(name);
            foreach (var r in Recipes)
            {
                if (r.Id_Drink == id)
                {
                    Ingredient ing= FindIngredientByID(r.Id_Ingredient);
                    ingredients.Add($"{FindAmount(id, ing.Id)} {ing.Unit} - {ing.Name}");
                }      
            }
            return ingredients;
        }

        //Wypisanie ilości danego składnika w drinku z tabeli przepisy:
        public string FindAmount(short? id_D, short? id_I)
        {
            foreach(var r in Recipes)
            {
                if (r.Id_Drink ==id_D && r.Id_Ingredient == id_I)
                    return r.Amount;
            }

            return null;
        }

        //Znalezienie ID drinka po nazwie:
        public short? FindDrinkID(string name)
        {
            foreach (var d in Drinks)
                if (d.Name == name)
                    return d.ID;

            return null;
        }

        //Liczba składników w drinku:
        public int NumberOfIngredientsInDrink(short? drinkID)
        {
            int counter = 0;
            foreach (var r in Recipes)
                if (r.Id_Drink == drinkID)
                    counter++;

            return counter;
        }

        //Znalezienie drinka po ID:
        public Drink FindDrinkByID(short? id)
        {
            foreach  (var d in Drinks)
                if  (d.ID == id)
                    return d;

            return null;
        }

        //Odnalezienie składnika po ID:
        public Ingredient FindIngredientByID(short? id)
        {
            foreach (var i in Ingredients)
                if (i.Id == id)
                    return i;

            return null;
        }

        //Odnalezienie id składnika po nazwie:
        public short? FindIngredientID(string name)
        {
            foreach (var i in Ingredients)
                if (i.Name == name)
                    return i.Id;

            return null;
        }

        //Wypisanie narzędzi po ID:
        public Tool FindToolByID(short? id)
        {
            foreach (var t in Tools)
                if (t.Id == id)
                    return t;

            return null;
        }

        //Wypisanie narzędzi po ID:
        public ObservableCollection<string> FindTools(string drinkName)
        {
            ObservableCollection<string> tools = new ObservableCollection<string>();
            foreach(var d in Drinktools)
            {
                if (d.Id_Drink == FindDrinkID(drinkName))
                {
                    tools.Add(FindToolByID(d.Id_Tool).Name);
                }
            }


            return tools;
        }

        //Wypisanie instrukcji drinka po jego nazwie:
        public string FindInstruction(string name)
        {
            foreach (var drink in Drinks)
            {
                if (drink.Name == name)
                    return drink.ToString();
            }

            return null;
        }

        //Znalezienie id użytkownika po nazwie:
        public short? FindUserID(string name)
        {
            foreach (var u in Users)
            {
                if (u.Login == name)
                    return u.ID;
            }

            return null;
        }

        //Wypisanie ulubionych drinków z nazwy użytkownika:
        public ObservableCollection<string> GetFavorite(string name)
        {
            ObservableCollection<string> favorites = new ObservableCollection<string>();
            short? id = FindUserID(name);
            foreach (var f in Favorites)
            {
                if (id == f.Id_Users)
                {
                    favorites.Add(FindDrinkByID(f.Id_Drink).Name);
                }
            }

            return favorites;
        }

        //Dodanie ulubionego drinka do bazy:
        public bool AddFavorite(short? id_U, short? id_D)
        {
            return RepositoryFavorite.AddFavorite(new Favorite(id_U, id_D));
        }

        //Usunięcie ulubionego drinka z bazy:
        public bool DeleteFavorite(short? id_U, short? id_D)
        {
            return RepositoryFavorite.DeleteFavorite(new Favorite(id_U, id_D));
        }

        //Wypisanie drinków po ich smaku:
        public ObservableCollection<string> FindDrinksByTaste(ObservableCollection<string> types)
        {
            ObservableCollection<string> drinks = new ObservableCollection<string>();

            foreach (var d in Drinks)
            {
                foreach (var t in types)
                {
                    if (t == d.Taste)
                        drinks.Add(d.Name);
                }
            }
            
            return drinks;
        }

        //Aktualizacja bazy: 
        public void Update()
        {
            Instance.Users.Clear();
            var users = RepositoryUser.GetAllUsers();
            foreach (var user in users)
                Instance.Users.Add(user);

            Instance.Favorites.Clear();
            var favorites = RepositoryFavorite.GetAllFavorites();
            foreach (var favorite in favorites)
                Instance.Favorites.Add(favorite);
        }
    }
}
