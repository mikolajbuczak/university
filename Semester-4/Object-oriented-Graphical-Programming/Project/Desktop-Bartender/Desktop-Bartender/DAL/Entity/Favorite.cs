namespace Desktop_Bartender.DAL.Entity
{using MySql.Data.MySqlClient;
    class Favorite
    {
        #region Properties
        public short? Id_Users{ get; set; }
        public short? Id_Drink { get; set; }
        #endregion

        public Favorite(MySqlDataReader reader)
        {
            Id_Users = short.Parse(reader["id_Users"].ToString());
            Id_Drink = short.Parse(reader["id_Drink"].ToString());
        }
    }
}
