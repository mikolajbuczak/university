namespace Desktop_Bartender.DAL.Repositories
{
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    using Entity;
    using System.Diagnostics;

    class RepositoryRecipe
    {
        //Klasa tworząca repozytorium encji z bazy danych

        #region QUERIES
        private const string ALL_RECIPES = "SELECT * FROM recipe";
        #endregion
        public static List<Recipe> GetAllRecipes()
        {
            List<Recipe> own = new List<Recipe>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_RECIPES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    own.Add(new Recipe(reader));
                connection.Close();
            }
            return own;
        }
    }
}
