namespace Desktop_Bartender.DAL.Repositories
{
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    using Entity;
    class RepositoryDrink
    {
        //Klasa tworząca repozytorium encji z bazy danych

        #region QUERIES
        private const string ALL_DRINKS = "SELECT * FROM drink";
        #endregion
        public static List<Drink> GetAllDrinks()
        {
            List<Drink> own = new List<Drink>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_DRINKS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    own.Add(new Drink(reader));
                connection.Close();
            }
            return own;
        }
    }
}
