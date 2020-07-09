namespace Desktop_Bartender.DAL.Repositories
{
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    using Entity;
    class RepositoryUser
    {
        #region QUERIES
        private const string ALL_USERS = "SELECT * FROM users";
        private const string ADD_USER = "INSERT INTO `users`(`Login`, `Password`) VALUES ";
        #endregion
        public static List<User> GetAllUsers()
        {
            List<User> own = new List<User>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_USERS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    own.Add(new User(reader));
                connection.Close();
            }
            return own;
        }
        public static bool AddUser(User user)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_USER} {user.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                user.ID = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }
    }
}
