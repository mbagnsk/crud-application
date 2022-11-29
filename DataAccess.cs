using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace crud_application
{
    public static class DataAccess
    {
        public static IList<Client> GetClients()
        {
            ComboBoxModel model = new ComboBoxModel();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("WarehouseManagerDB")))
            {
                connection.Open();
                SqlDataReader dr = new SqlCommand("SELECT IDClient, Company from dbo.CUSTOMERS", connection).ExecuteReader();
                while (dr.Read())
                    model.Clients.Add(new Client { IDClient = Convert.ToInt32(dr.GetDecimal(0)), Company = dr.GetString(1) });
                connection.Close();
            }
            return model.Clients;
        }
    }
}
