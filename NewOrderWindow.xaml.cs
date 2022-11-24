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
    public partial class NewOrderWindow : Window
    {
        public NewOrderWindow()
        {
            InitializeComponent();
        }


        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void AddNewOrderButton_Click_1(object sender, RoutedEventArgs e)
        {
            int order = Int16.Parse(IdOrderTextBox.Text);
            int client = Int16.Parse(IdClientTextBox.Text);
            int employee = Int16.Parse(IdEmployeeTextBox.Text);
            bool isAdded = DataWriter.NewOrder(order, client, employee);
        }
    }
}
