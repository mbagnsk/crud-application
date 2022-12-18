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
            if (DataWriter.AddProduct(
                ProductNameTextBox.Text,
                ProductDescriptionTextBox.Text,
                Convert.ToDouble(NetPriceTextBox.Text),
                Convert.ToDouble(GrossPriceTextBox.Text),
                Convert.ToDateTime(PriceActiveFromDatePicker.Text),
                Convert.ToDateTime(PriceActiveToDatePicker.Text)))
                MessageBox.Show("Dodano produkt!");
            else
                MessageBox.Show("Błąd podczas dodawania produktu!");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
