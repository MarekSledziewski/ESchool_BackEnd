using DataStore.MySQLConnector;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace ESchool.Repository
{
    public class ESchoolRepository
    {

        private readonly MySQLConnector mySQLConnector;

        public ESchoolRepository()
        {
            mySQLConnector = new MySQLConnector();
        }

        // Constructor to inject MySQLConnector
        public ESchoolRepository(MySQLConnector mySQLConnector)
        {
            this.mySQLConnector = mySQLConnector;
        }
        public JToken GetUser()
        {
            using (MySqlCommand myCommand = new MySqlCommand("select * from `escho`.`test_table`;"))
            {
                return  mySQLConnector.ExecuteQueryCommand(myCommand);
            }
        }
    }
}
