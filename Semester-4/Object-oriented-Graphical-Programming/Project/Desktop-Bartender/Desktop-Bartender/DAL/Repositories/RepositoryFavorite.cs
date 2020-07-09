namespace Desktop_Bartender.DAL.Repositories
{
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    using Entity;
    class RepositoryFavorite
    {
        #region QUERIES
        private const string ALL_FAVORITES = "SELECT * FROM favorite";
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
    }
}
