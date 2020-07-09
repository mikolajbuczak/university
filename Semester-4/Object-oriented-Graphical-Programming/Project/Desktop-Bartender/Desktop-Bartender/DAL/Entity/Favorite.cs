namespace Desktop_Bartender.DAL.Entity
{using MySql.Data.MySqlClient;
    class Favorite
    {
        //Klasa tworząca obiekt encji z bazy danych

        #region Properties
        public short? Id_Users{ get; set; }
        public short? Id_Drink { get; set; }
        #endregion

        public Favorite(MySqlDataReader reader)
        {
            Id_Users = short.Parse(reader["id_Users"].ToString());
            Id_Drink = short.Parse(reader["id_Drink"].ToString());
        }

        public Favorite(short? id_u, short? id_d)
        {
            Id_Users = id_u;
            Id_Drink = id_d;
        }

        public string ToInsert()
        {
            return $"('{Id_Users}', '{Id_Drink}')";
        }

        public string ToDelete(short? id_D)
        {
            return $"(id_Drink = {id_D})";
        }
    }
}
