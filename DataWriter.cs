using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_application
{
    public static class DataWriter
    {
        public static bool AddOrder(int idOrder, int idClient, int idEmployee)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("WarehouseManagerDB")))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    string query = "insert into dbo.Customers (idzamowienia, idklienta, idwprowadzajcego) values (@idzamowienia, @idklienta, @idwprowadzajcego)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@idzamowienia", idOrder);
                    command.Parameters.AddWithValue("@idklienta", idClient);
                    command.Parameters.AddWithValue("@idwprowadzajcego", idEmployee);
                    
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    finally
                    {
                        connection.Close();      
                    }
                }
                return true;
            }
        }

        public static bool AddClient(string company, int nip, string street, int building, int local, string city, string zipCode, string email, int phoneNumber)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("WarehouseManagerDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddClient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Company", company));
                command.Parameters.Add(new SqlParameter("@Nip", nip));
                command.Parameters.Add(new SqlParameter("@Street", street));
                command.Parameters.Add(new SqlParameter("@BuildingNumber", building));
                command.Parameters.Add(new SqlParameter("@LocalNumber", local));
                command.Parameters.Add(new SqlParameter("@City", city));
                command.Parameters.Add(new SqlParameter("@ZIPCode", zipCode));
                command.Parameters.Add(new SqlParameter("@Email", email));
                command.Parameters.Add(new SqlParameter("@PhoneNumber", phoneNumber));
                command.ExecuteNonQuery();
            }
            return true;
        }

        public static int AddInvoice(int idclient)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("WarehouseManagerDB")))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddInvoice", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@IDClient", idclient));
                command.Parameters.Add(new SqlParameter("@OrderDatetime", DateTime.UtcNow));
                SqlParameter idinvoice = new SqlParameter("@IDInvoice", SqlDbType.Int);
                idinvoice.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(idinvoice);
                command.ExecuteNonQuery();
                var idinvoiceResult = command.Parameters["@IDInvoice"].Value;
                return Convert.ToInt32(idinvoiceResult);
            }
        }
    }
}
