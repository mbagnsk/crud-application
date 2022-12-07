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
                while (dr.Read())
                    model.Products.Add(new Product { IDProduct = Convert.ToInt32(dr.GetDecimal(0)), ProductName = dr.GetString(1), ProductDescription = dr.GetString(2), NetPrice = Convert.ToDouble(dr.GetDecimal(3)), GrossPrice = Convert.ToDouble(dr.GetDecimal(4)) });
                connection.Close();
            }
            return model.Products;
        }

        public static List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("WarehouseManagerDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetInvoices", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = command.ExecuteReader();
                
                while (dataReader.Read())
                {
                    Invoice invoice = new Invoice(
                        Convert.ToInt32(dataReader.GetDecimal(0)),
                        Convert.ToInt32(dataReader.GetDecimal(1)),
                        Convert.ToDateTime(dataReader.GetDateTime(2)),
                        DateOnly.FromDateTime(Convert.ToDateTime(dataReader.GetDateTime(3))),
                        DateOnly.FromDateTime(Convert.ToDateTime(dataReader.GetDateTime(4))),
                        Convert.ToInt32(dataReader.GetDecimal(5)),
                        Convert.ToBoolean(dataReader.GetBoolean(6))
                    );
                    invoices.Add(invoice);
                }
            }
            return invoices;
        }
    }
}