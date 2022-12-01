﻿using System;
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

            ProductsDataGrid.Items.Add(product);
            ProductsDataGrid.Items.Refresh();
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            int selected = (int)CompaniesComboBox.SelectedValue;
        }
    }
}
