namespace Desktop_Bartender.DAL.Repositories
{
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    using Entity;
    class RepositoryDrinktool
    {
        //Klasa tworząca repozytorium encji z bazy danych

        #region QUERIES
        private const string ALL_DRINKTOOLS = "SELECT * FROM drinktools";
        #endregion
        public static List<Drinktool> GetAllDrinkTools()
        {
            List<Drinktool> own = new List<Drinktool>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_DRINKTOOLS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    own.Add(new Drinktool(reader));
                connection.Close();
            }
            return own;
        }
    }
}
