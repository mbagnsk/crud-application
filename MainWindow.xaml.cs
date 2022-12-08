﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
            var invoices = DataAccess.GetInvoices();
            InvoicesDataGrid.ItemsSource = invoices;
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
    }
}
