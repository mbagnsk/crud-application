using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace crud_application
{
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            int nip = Int32.Parse(NipTextBox.Text);
            int buildingNumber = Int16.Parse(BuildingNumberTextBox.Text);
            int localNumber = Int16.Parse(LocalNumberTextBox.Text);
            int phoneNumber = Int32.Parse(PhoneTextBox.Text);

            DataWriter.AddClient(CompanyNameTextBox.Text, nip, StreetTextBox.Text, buildingNumber, localNumber, CityTextBox.Text, ZIPCodeTextBox.Text, EmailTextBox.Text, phoneNumber);
            this.Close();
        }
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
