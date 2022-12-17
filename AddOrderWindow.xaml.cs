using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace crud_application
{
    /// <summary>
    /// Interaction logic for NewOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        List<OrderElement> orderElements = new List<OrderElement>();
        public AddOrderWindow()
        {
            InitializeComponent();
            IList<Client> Companies = DataAccess.GetClients();
            IList<Product> Products = DataAccess.GetProducts();
            CompaniesComboBox.ItemsSource = Companies;
            ProductsComboBox.ItemsSource = Products;
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Product product = ProductsComboBox.SelectedItem as Product;
            OrderElement orderElement = new OrderElement(product.IDProduct, product.ProductName, product.ProductDescription, product.NetPrice, product.GrossPrice, Convert.ToInt32(QuantityTextBox.Text));
            orderElements.Add(orderElement);
            OrderElementDataGrid.ItemsSource = orderElements;
            ProductsComboBox.SelectedIndex = -1;
            QuantityTextBox.Clear();
            OrderElementDataGrid.Items.Refresh();
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Client client = CompaniesComboBox.SelectedItem as Client;
            if (DataWriter.AddOrder(client.IDClient, orderElements))
            {
                this.Close();
                MessageBox.Show("Dodano zamówienie.");
            }
            else MessageBox.Show("Błąd podczas dodawania zamówienia!");
        }
    }
}
