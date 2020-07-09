namespace Desktop_Bartender.DAL.Repositories
{
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    using Entity;
    class RepositoryIngredient
    {
        #region QUERIES
        private const string ALL_INGREDIENTS = "SELECT * FROM ingredient";
        #endregion
        public static List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> own = new List<Ingredient>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_INGREDIENTS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    own.Add(new Ingredient(reader));
                connection.Close();
            }
            return own;
        }
    }
}
