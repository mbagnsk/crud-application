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

        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity;
            Product product;
            try
            {
                product = ProductsComboBox.SelectedItem as Product;
                quantity = Convert.ToInt32(QuantityTextBox.Text) > 0 ? Convert.ToInt32(QuantityTextBox.Text) : -1;
            }
            catch
            {
                MessageBox.Show("Błędne dane!");
                return;
            }
            if (product == null || quantity == -1)
            {
                MessageBox.Show("Błędne dane!");
                return;
            }

            try
            {
                OrderElement orderElement = new OrderElement(product.IDProduct, product.ProductName, product.ProductDescription, product.NetPrice, product.GrossPrice, quantity);
                orderElements.Add(orderElement);
                OrderElementsDataGrid.ItemsSource = orderElements;
                ProductsComboBox.SelectedIndex = -1;
                QuantityTextBox.Clear();
                OrderElementsDataGrid.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Błąd podczas dodawania produktu do zamówienia!");
                return;
            }
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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
