namespace Desktop_Bartender.DAL.Entity
{
    using MySql.Data.MySqlClient;
    class User
    {
        #region Properties
        public short? ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        #endregion

        #region ctors
        public User(MySqlDataReader reader)
        {
            ID = short.Parse(reader["id_users"].ToString());
            Login = reader["Login"].ToString();
            Password = reader["Password"].ToString();
        }

        public User(string login, string password)
        {
            ID = null;
            Login = login.Trim();
            Password = password.Trim();
        }

        public User(User user)
        {
            ID = user.ID;
            Login = user.Login;
            Password = user.Password;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Login} - {Password}";
        }

        public string ToInsert()
        {
            return $"('{Login}', '{Password}')";
        }

        public override bool Equals(object obj)
        {
            User user = obj as User;
            if  (user is null) return false;
            if  (Login != user.Login) return false;
            if  (Password != user.Password) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
