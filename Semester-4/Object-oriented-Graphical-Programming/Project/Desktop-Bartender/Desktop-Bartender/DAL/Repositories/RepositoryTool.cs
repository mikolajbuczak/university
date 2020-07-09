namespace Desktop_Bartender.DAL.Repositories
{
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    using Entity;
    class RepositoryTool
    {
        #region QUERIES
        private const string ALL_TOOLS = "SELECT * FROM tool";
        #endregion
        public static List<Tool> GetAllTools()
        {
            List<Tool> own = new List<Tool>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_TOOLS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    own.Add(new Tool(reader));
                connection.Close();
            }
            return own;
        }
    }
}
