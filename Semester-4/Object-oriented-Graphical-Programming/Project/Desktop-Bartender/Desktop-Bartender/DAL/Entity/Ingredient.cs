namespace Desktop_Bartender.DAL.Entity
{
    using MySql.Data.MySqlClient;
    class Ingredient
    {
        //Klasa tworząca obiekt encji z bazy danych

        #region Properties
        public short? Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Taste { get; set; }
        public string Unit { get; set; }
        #endregion

        public Ingredient(MySqlDataReader reader)
        {
            Id = short.Parse(reader["id_Ingredient"].ToString());
            Name = reader["name"].ToString();
            Category = reader["typeof"].ToString();
            Taste = reader["taste"].ToString();
            Unit = reader["unit"].ToString();
        }

        public override string ToString()
        {
            return $"{Unit} {Name}";
        }

        public string ToInsert()
        {
            return $"('{Name}')";
        }

        public override bool Equals(object obj)
        {
            Ingredient ing = obj as Ingredient;
            if (ing is null) return false;
            if (Category != ing.Category) return false;
            if (Taste != ing.Taste) return false;
            if (Unit != ing.Unit) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
