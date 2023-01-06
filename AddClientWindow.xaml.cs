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
            long nip;
            int buildingNumber, localNumber, phoneNumber;
            string companyName, street, city, zipCode, email;

            try
            {
                nip = Int64.Parse(NipTextBox.Text) > 999999999 ? Int64.Parse(NipTextBox.Text) : 1;
                buildingNumber = Int16.Parse(BuildingNumberTextBox.Text) > 0 ? Int16.Parse(BuildingNumberTextBox.Text) : -1;
                localNumber = Int16.Parse(LocalNumberTextBox.Text) > -1 ? Int16.Parse(LocalNumberTextBox.Text) : 0;
                phoneNumber = Int64.Parse(PhoneTextBox.Text) > 99999999 ? Int32.Parse(PhoneTextBox.Text) : -1;
                companyName = String.IsNullOrWhiteSpace(CompanyNameTextBox.Text) ? String.Empty : CompanyNameTextBox.Text;
                street = String.IsNullOrWhiteSpace(StreetTextBox.Text) ? String.Empty : StreetTextBox.Text;
                city = String.IsNullOrWhiteSpace(CityTextBox.Text) ? String.Empty : CityTextBox.Text;
                zipCode = String.IsNullOrWhiteSpace(ZIPCodeTextBox.Text) ? String.Empty : ZIPCodeTextBox.Text;
                email = String.IsNullOrWhiteSpace(EmailTextBox.Text) ? String.Empty : EmailTextBox.Text;
            }
            catch
            {
                MessageBox.Show("Błędne dane!");
                return;
            }
            if (nip == 1 || buildingNumber == -1 || phoneNumber == -1 || companyName == String.Empty || street == String.Empty || city == String.Empty || zipCode == String.Empty || email == String.Empty)
            {
                MessageBox.Show("Błędne dane!");
                return;
            }
            if (DataWriter.AddClient(companyName, nip, street, buildingNumber, localNumber, city, zipCode, email, phoneNumber))
            {
                MessageBox.Show("Dodano klienta.");
                this.Close();
            }
            else 
                MessageBox.Show("Błąd podczas dodawania klienta!");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
