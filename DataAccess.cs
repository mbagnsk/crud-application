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
            CompaniesComboBoxModel model = new CompaniesComboBoxModel();
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

        public static IList<Product> GetProducts()
        {
            ProductsComboBoxModel model = new ProductsComboBoxModel();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("WarehouseManagerDB")))
            {
                connection.Open();
                SqlDataReader dr = new SqlCommand("SELECT IDProduct, ProductName, ProductDescription, NetPrice, GrossPrice  from dbo.PRODUCTS", connection).ExecuteReader();
                while(dr.Read())
                    model.Products.Add(new Product { IDProduct = Convert.ToInt32(dr.GetDecimal(0)), ProductName = dr.GetString(1), ProductDescription = dr.GetString(2) , NetPrice = Convert.ToDouble(dr.GetDecimal(3)), GrossPrice = Convert.ToDouble(dr.GetDecimal(4)) });
                connection.Close();
            }
            return model.Products;
        }
    }
}
