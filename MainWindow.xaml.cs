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
using System.Linq;

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
            string clientSearch = ClientSearchTextBox.Text;
            int invoiceSearch = Convert.ToInt32(InvoiceSearchTextBox.Text);
            List<Invoice> searchResult = allInvoices.Where(a => a.companyName == clientSearch).ToList();
        }
    }
}
