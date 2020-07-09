namespace Desktop_Bartender.DAL.Entity
{
    using MySql.Data.MySqlClient;
    class Drink
    {
        #region Properties
        public short? ID { get; set; }
        public string Name { get; set; }
        public string Glass_type { get; set; }

        public double Prepare_time { get; set; }
        public string Instruction { get; set; }
        public string Temperature { get; set; }
        public string Taste { get; set; }
        public string Strength { get; set; }
        #endregion

        #region ctors
        public Drink(MySqlDataReader reader)
        {
            ID = short.Parse(reader["id"].ToString()); ;
            Name = reader["name"].ToString();
            Glass_type = reader["glass_type"].ToString();
            Prepare_time = double.Parse(reader["prepare_time"].ToString());
            Instruction = reader["instruction"].ToString();
            Temperature = reader["temperature"].ToString();
            Taste = reader["taste"].ToString();
            Strength = reader["strength"].ToString();
        }

        public Drink(string name, double preparationTime, string instruction, string temperature, string taste, string strength)
        {
            ID = null;
            Name = name;
            Prepare_time = preparationTime;
            Instruction = instruction;
            Temperature = temperature;
            Taste = taste;
            Strength = strength;
        }

        public Drink(Drink drink)
        {
            ID = drink.ID;
            Name = drink.Name;
            Prepare_time = drink.Prepare_time;
            Instruction = drink.Instruction;
            Temperature = drink.Temperature;
            Taste = drink.Taste;
            Strength = drink.Strength;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Name} \n Glass: {Glass_type} \n Time: {Prepare_time} \n Temperauture: {Temperature} \n " +
                $"Taste: {Taste} \n Strength: {Strength} \n {Instruction}";
        }

        public string ToInsert()
        {
            return $"('{Name}', '{Glass_type}', '{Prepare_time}', '{Instruction}', '{Temperature}', '{Taste}', '{Strength}')";
        }

        public override bool Equals(object obj)
        {
            var drink = obj as Drink;
            if (drink is null) return false;
            if (Name.ToLower() != drink.Name.ToLower()) return false;
            if (Glass_type.ToLower() != drink.Glass_type.ToLower()) return false;
            if (Prepare_time != drink.Prepare_time) return false;
            if (Instruction.ToLower() != drink.Instruction.ToLower()) return false;
            if (Taste.ToLower() != drink.Taste.ToLower()) return false;
            if (Strength.ToLower() != drink.Strength.ToLower()) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}