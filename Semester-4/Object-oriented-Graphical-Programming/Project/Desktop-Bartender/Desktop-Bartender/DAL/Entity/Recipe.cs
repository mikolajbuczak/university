namespace Desktop_Bartender.DAL.Entity
{
    using MySql.Data.MySqlClient;
    class Recipe
    {
        #region Properties
        public short? Id_Drink { get; set; }
        public short? Id_Ingredient { get; set; }
        public string Amount { get; set; }

        public Recipe(MySqlDataReader reader)
        {
            Id_Drink = short.Parse(reader["id_Drink"].ToString()); ;
            Id_Ingredient = short.Parse(reader["id_Ingredient"].ToString()); ;
            Amount = reader["amount"].ToString();
        }

        #endregion

        public override string ToString()
        {
            return $"{Amount}";
        }
    }
}
