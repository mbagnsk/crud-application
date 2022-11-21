using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace crud_application
{
    public class DataAccess
    {
        public List<Order> GetOrders()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("testowaNazwa")))
            {
                List<Order> output = connection.Query<Order>("Select * from dbo.tabelaTestowa2;").ToList();
                return output;
            }
        }
    }
}
