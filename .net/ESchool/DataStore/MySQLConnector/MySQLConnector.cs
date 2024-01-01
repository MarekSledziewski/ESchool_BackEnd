using MySql.Data.MySqlClient;
using System.Data;
using Newtonsoft.Json.Linq;

namespace DataStore.MySQLConnector
{
    public class MySQLConnector: ControllerBase
    {
        private string myConnectionString = "server=localhost;database=escho;uid=SERVICE;pwd=D#m6Fj*p9L3!z@K8o$Nq;";

        public int ExecuteNonQueryCommand(MySqlCommand myCommand)
        {

            MySqlConnection cnn = new MySqlConnection(myConnectionString);
        try
        {
            cnn.Open();
            Console.WriteLine("Connection Open!");
            myCommand.Connection = cnn;
            Console.WriteLine("Executing " + myCommand.CommandText);

            var result = myCommand.ExecuteNonQuery();
                Console.WriteLine("Rows afected: " + result);
            cnn.Close();
            return result;
            }
        catch (Exception ex)
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close(); 
            }
                Console.WriteLine(ex.ToString() + " Exception when executing non query");

                throw ex;
            }
          
        }
        public JArray ExecuteQueryCommand(MySqlCommand myCommand)
        {

            MySqlConnection cnn = new MySqlConnection(myConnectionString);
            JArray jsonArray = new JArray();

            try
            {

                cnn.Open();
                Console.WriteLine("Connection Open!");
                myCommand.Connection = cnn;
                Console.WriteLine("Executing " + myCommand.CommandText);

                using (var result = myCommand.ExecuteReader())
                {
                    while (result.Read())
                    {
                        JObject jsonObject = new JObject();

                        for (int i = 0; i < result.FieldCount; i++)
                        {
                            string columnName = result.GetName(i);
                            object value = result[i];
                            jsonObject.Add(columnName, JToken.FromObject(value));
                        }
                        jsonArray.Add(jsonObject);
                    }
                }

                cnn.Close();

                return jsonArray;
            
            }
            catch (Exception ex)
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }

                Console.WriteLine(ex.ToString() + " Exception when executing query");

                throw ex;
            }

        }
    }

}
