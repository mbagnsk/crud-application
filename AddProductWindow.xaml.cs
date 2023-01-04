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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            string productName, productDescription;
            double netPrice, grossPrice;
            DateTime priceActiveFrom, priceActiveTo;

            try
            { 
                productName = String.IsNullOrWhiteSpace(ProductNameTextBox.Text) ? String.Empty : Convert.ToString(ProductNameTextBox.Text) ;
                productDescription = String.IsNullOrWhiteSpace(ProductDescriptionTextBox.Text) ? String.Empty : ProductDescriptionTextBox.Text;
                netPrice = Convert.ToDouble(NetPriceTextBox.Text) > 0 ? Convert.ToDouble(NetPriceTextBox.Text) : -1;
                grossPrice = Convert.ToDouble(GrossPriceTextBox.Text) > 0 ? Convert.ToDouble(GrossPriceTextBox.Text) : -1;
                priceActiveFrom = DataValidator.isDateTime(PriceActiveFromDatePicker.Text) ? Convert.ToDateTime(PriceActiveFromDatePicker.Text) : DateTime.MinValue;
                priceActiveTo = DataValidator.isDateTime(PriceActiveToDatePicker.Text) ? Convert.ToDateTime(PriceActiveToDatePicker.Text) : DateTime.MinValue;
            }
            catch
            {
                MessageBox.Show("Błędne dane!");
                return;
            }

            if (productName == String.Empty || productDescription == String.Empty || netPrice == -1 || grossPrice == -1 || priceActiveFrom == DateTime.MinValue || priceActiveTo == DateTime.MinValue || priceActiveFrom >= priceActiveTo)
            {
                MessageBox.Show("Błędne dane!");
                return;
            }
            if (DataWriter.AddProduct(productName, productDescription, netPrice, grossPrice, priceActiveFrom, priceActiveTo))
            {
                MessageBox.Show("Dodano produkt!");
                this.Close();
            }
            else
                MessageBox.Show("Błąd podczas dodawania produktu!");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
