namespace Programowanie
{
    class Baza
    {
        public static System.Collections.Generic.List<string> ReadOrderData(string fileName)
        {
            System.Collections.Generic.List<string> names = new System.Collections.Generic.List<string>();

            string connStr = @"Data Source=(LocalDB)\v11.0;Integrated Security=True;AttachDbFilename=" + fileName;

            string queryString = "SELECT Names_name FROM Names";

            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\v11.0;Integrated Security=True;AttachDbFilename=" + fileName))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(queryString, con))
                {
                    con.Open();
                    using (System.Data.SqlClient.SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                            names.Add(ReadSingleRow((System.Data.IDataRecord)rd));
                    }
                    con.Close();
                }
            }
            return names;
        }
        private static string ReadSingleRow(System.Data.IDataRecord record)
        {
            return System.String.Format("{0}, {1}", record[0], record[1]);
        }
    }
}