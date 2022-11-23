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
        public static bool NewOrder(int idOrder, int idClient, int idEmployee)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("testowaNazwa")))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    string query = "insert into dbo.tabelaTestowa (idzamowienia, idklienta, idwprowadzajcego) values (@idzamowienia, @idklienta, @idwprowadzajcego)";
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

    }
}
