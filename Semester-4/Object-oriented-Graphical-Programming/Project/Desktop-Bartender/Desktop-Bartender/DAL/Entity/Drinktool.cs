namespace Desktop_Bartender.DAL.Entity
{
    using MySql.Data.MySqlClient;
    class Drinktool
    {
        //Klasa tworząca obiekt encji z bazy danych

        #region Properties
        public short? Id_Drink { get; set; }
        public short? Id_Tool { get; set; }
        #endregion

        public Drinktool(MySqlDataReader reader)
        {
            Id_Drink = short.Parse(reader["id_Drink"].ToString());
            Id_Tool = short.Parse(reader["id_Tool"].ToString());
        }
    }
}
