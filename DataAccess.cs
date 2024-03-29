﻿using System;
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
                        Convert.ToString(dataReader.GetString(2)),
                        Convert.ToDateTime(dataReader.GetDateTime(3)),
                        DateOnly.FromDateTime(Convert.ToDateTime(dataReader.GetDateTime(4))),
                        DateOnly.FromDateTime(Convert.ToDateTime(dataReader.GetDateTime(5))),
                        Convert.ToInt32(dataReader.GetDecimal(6)),
                        Convert.ToBoolean(dataReader.GetBoolean(7))
                    );
                    invoices.Add(invoice);
                }
            }
            return invoices;
        }

        public static double GetInvoiceNetPrice(int idInvoice)
        {
            double netPrice = 0;
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("WarehouseManagerDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetInvoiceNetPrice", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@IDInvoice", idInvoice));
                SqlDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                    netPrice = Convert.ToDouble(dataReader.GetDecimal(0));
            }
            return netPrice;
        }
        public static double GetInvoiceGrossPrice(int idInvoice)
        {
            double grossPrice = 0;
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("WarehouseManagerDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetInvoiceGrossPrice", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@IDInvoice", idInvoice));
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    grossPrice = Convert.ToDouble(dataReader.GetDecimal(0));
            }
            return grossPrice;
        }

        public static List<OrderElement> GetOrderElements(int idInvoice)
        {
            List<OrderElement> orderElements = new List<OrderElement> ();
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("WarehouseManagerDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetOrderElements", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@IDInvoice", idInvoice));
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    orderElements.Add(new OrderElement(
                        Convert.ToInt32(dataReader.GetDecimal(0)),
                        Convert.ToString(dataReader.GetString(1)),
                        Convert.ToString(dataReader.GetString(2)),
                        Convert.ToDouble(dataReader.GetDecimal(3)),
                        Convert.ToDouble(dataReader.GetDecimal(4)),
                        Convert.ToInt32(dataReader.GetDecimal(5))));
                }
            }
            return orderElements;
        }
    }
}