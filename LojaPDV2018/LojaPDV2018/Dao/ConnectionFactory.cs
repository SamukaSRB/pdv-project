using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaPDV2018Cliente.Dao
{
    public class ConnectionFactory
    {
        private String connectionString;
        public ConnectionFactory()
        {
            connectionString = "Server = localhost;Database=lojapdv;Uid=root;Pwd=samuka201232;";
        }
        public MySqlConnection getConnection()
        { 
            MySqlConnection conn = new MySqlConnection(connectionString);
          
            return conn;

        }
    }
}
