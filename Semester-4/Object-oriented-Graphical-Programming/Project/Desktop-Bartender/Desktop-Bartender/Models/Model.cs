namespace Desktop_Bartender.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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

        public static Model Instance
        {
            get
            {
                if  (instance == null)
                    instance = new Model();
                return instance;
            }
        }

        //private User CheckUserData(string login, string passsword)
        //{
        //    foreach (var u in Users)
        //    {
        //        if (u.Login == login)
        //            return t;
        //    }
        //    return null;
        //}

        public bool MatchData(string login, string passsword)
        {
            foreach (var u in Users)
            {
                if ((u.Login == login) && (u.Password == passsword))
                    return true;      
            }
            return false;
        }

        public User FindUser(string login)
        {
            foreach (var u in Users)
            {
                if ((u.Login == login))
                    return u;
            }
            return null;
        }

        public bool AddUser(string login, string password)
        {
            return RepositoryUser.AddUser(new User(login, password));
        }

        public void FindCategories(List<string> categories)
        {
            foreach (var i in Ingredients)
            {
                if (!categories.Contains(i.Category))
                    categories.Add(i.Category);
                categories.Sort();
            }
        }

        public List<string> FindIngredients(string category)
        {
            List<string> ingredients = new List<string>();

            foreach (var i in Ingredients)
            {
                if (category == i.Category)
                    ingredients.Add(i.Name);
                ingredients.Sort();
            }

            return ingredients;
        }

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
