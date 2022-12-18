using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace crud_application
{
    public partial class MainWindow : Window
    {
        List<Invoice> allInvoices;
        public MainWindow()
        {
            InitializeComponent();
            allInvoices= DataAccess.GetInvoices();
            InvoicesDataGrid.ItemsSource = allInvoices;
        }
        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow();
            addOrderWindow.Show();
        }
        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string clientSearch = GetClientFromClientSearchTextBox();
            int invoiceSearch = GetInvoiceFromSearchTextBox();
            List<Invoice> searchResult = new List<Invoice>();
            if (clientSearch != string.Empty && invoiceSearch != 0)
                searchResult = allInvoices.Where(a => a.idInvoice == invoiceSearch && a.companyName == clientSearch).ToList();
            else if (clientSearch != string.Empty)
                searchResult = allInvoices.Where(a => a.companyName == clientSearch).ToList();
            else if (invoiceSearch != 0)
                searchResult = allInvoices.Where(a => a.idInvoice == invoiceSearch).ToList();
            else
                searchResult = allInvoices;
            InvoicesDataGrid.ItemsSource = searchResult;
        }

        private string GetClientFromClientSearchTextBox()
        {
            string clientSearch;
            try
            {
                clientSearch = ClientSearchTextBox.Text;
            }
            catch
            {
                clientSearch = string.Empty;
            }
            return clientSearch;
        }

        private int GetInvoiceFromSearchTextBox()
        {
            int invoiceSearch;
            try
            {
                invoiceSearch = Convert.ToInt32(InvoiceSearchTextBox.Text);
            }
            catch
            {
                invoiceSearch = 0;
            }
            return invoiceSearch; 
        }

        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            ClientSearchTextBox.Text = String.Empty;
            InvoiceSearchTextBox.Text = String.Empty;
            InvoicesDataGrid.ItemsSource = allInvoices;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            allInvoices = DataAccess.GetInvoices();
            InvoicesDataGrid.ItemsSource = allInvoices;
        }

        private void InvoicesDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Invoice invoice = InvoicesDataGrid.SelectedItem as Invoice;
            if (invoice != null)
            {
                InvoiceDetailsWindow invoiceDetailsWindow = new InvoiceDetailsWindow(invoice);
                invoiceDetailsWindow.Show();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataWriter.AddProduct("detal5", "Opis detalu 5", 321, 333, DateTime.UtcNow, DateTime.UtcNow)) 
                MessageBox.Show("Dodano produkt!");
            else
                MessageBox.Show("Błąd podczas dodawania produktu!");
        }
    }
}
