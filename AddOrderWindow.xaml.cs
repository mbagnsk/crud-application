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
        public AddOrderWindow()
        {
            
            InitializeComponent();
            IList<Client> Companies = DataAccess.GetClients();
            CompaniesComboBox.ItemsSource = Companies;
        }


        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            int selected = (int)CompaniesComboBox.SelectedValue;
        }
    }
}
