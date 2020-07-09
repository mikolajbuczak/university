namespace Desktop_Bartender.DAL.Repositories
{
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    using Entity;
    class RepositoryFavorite
    {
        //Klasa tworząca repozytorium encji z bazy danych

        //Zapytania do bazy:
        #region QUERIES
        private const string ALL_FAVORITES = "SELECT * FROM favorite";
        private const string ADD_FAVORITE = "INSERT INTO `favorite`(`id_Users`, `id_Drink`) VALUES";
        private const string DELETE_FAVORITE = "DELETE FROM `favorite` WHERE";
        #endregion
        public static List<Favorite> GetAllFavorites()
        {
            List<Favorite> own = new List<Favorite>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_FAVORITES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    own.Add(new Favorite(reader));
                connection.Close();
            }
            return own;
        }
        public static bool AddFavorite(Favorite favorite)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_FAVORITE} {favorite.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                connection.Close();
            }
            return state;
        }

        public static bool DeleteFavorite(Favorite favorite)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_FAVORITE} {favorite.ToDelete(favorite.Id_Drink)}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                connection.Close();
            }
            return state;
        }
    }
}
