using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace crud_application
{
    public static class DataWriter
    {
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

        private static int AddInvoice(int idclient, SqlCommand addInvoiceSqlCommand)
        {
            addInvoiceSqlCommand.CommandType = CommandType.StoredProcedure;
            addInvoiceSqlCommand.Parameters.Add(new SqlParameter("@IDClient", idclient));
            addInvoiceSqlCommand.Parameters.Add(new SqlParameter("@OrderDatetime", DateTime.UtcNow));
            SqlParameter idinvoice = new SqlParameter("@IDInvoice", SqlDbType.Int);
            idinvoice.Direction = ParameterDirection.ReturnValue;
            addInvoiceSqlCommand.Parameters.Add(idinvoice);
            addInvoiceSqlCommand.ExecuteNonQuery();
            var idinvoiceResult = addInvoiceSqlCommand.Parameters["@IDInvoice"].Value;
            return Convert.ToInt32(idinvoiceResult);
        }

        private static void AddOrderElement(int idinvoice, int idproduct, int quantity, SqlCommand addOrderElementSqlCommand)
        {
            addOrderElementSqlCommand.CommandType = CommandType.StoredProcedure;
            addOrderElementSqlCommand.Parameters.Add(new SqlParameter("@IDInvoice", idinvoice));
            addOrderElementSqlCommand.Parameters.Add(new SqlParameter("@IDProduct", idproduct));
            addOrderElementSqlCommand.Parameters.Add(new SqlParameter("@Quantity", quantity));
            addOrderElementSqlCommand.ExecuteNonQuery();
        }

        public static bool AddOrder(int idclient)
        {
            bool result = false;
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionDBHelper.connectionStringValue("WarehouseManagerDB")))
            {   
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    SqlCommand addInvoiceSqlCommand = new SqlCommand("AddInvoice", connection, transaction);
                    int idinvoice = AddInvoice(idclient, addInvoiceSqlCommand);
                    foreach (OrderElement orderElement in OrderElement.orderElements)
                    {
                        SqlCommand addOrderElementSqlCommand = new SqlCommand("AddOrder", connection, transaction);
                        DataWriter.AddOrderElement(idinvoice, orderElement.IDProduct, orderElement.Quantity, addOrderElementSqlCommand);
                    }
                    transaction.Commit();
                    result = true;
                }
                catch(Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
                return result;
            }
        }
    }
}
