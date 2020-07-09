namespace Desktop_Bartender.DAL.Entity
{
    using MySql.Data.MySqlClient;
    class Tool
    {
        //Klasa tworząca obiekt encji z bazy danych

        #region Properties
        public short? Id { get; set; }
        public string Name { get; set; }
        #endregion

        public Tool(MySqlDataReader reader)
        {
            Id = short.Parse(reader["id_Tools"].ToString()); ;
            Name = reader["name"].ToString();
        }

        public Tool(Tool tool)
        {
            Id = tool.Id;
            Name = tool.Name;
        }

        public Tool(string name)
        {
            Id = null;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public string ToInsert()
        {
            return $"('{Name}')";
        }

        public override bool Equals(object obj)
        {
            Tool tool = obj as Tool;
            if (tool is null) return false;
            if (Name != tool.Name) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
