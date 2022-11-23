using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Order> orders = new List<Order>();
        public MainWindow()
        {
            InitializeComponent();
            /*OrderListbox.DataContext = orders;
            OrderListbox.DisplayMemberPath = "FullInfo";*/
        }

        private void GetOrder_Click(object sender, RoutedEventArgs e)
        {
            /*DataAccess db = new DataAccess();
            orders = db.GetOrders();
            OrderListbox.DataContext = orders;
            OrderListbox.DisplayMemberPath = "FullInfo";*/
            int order = Int16.Parse(idOrder.Text);
            int client = Int16.Parse(idClient.Text);
            int employee = Int16.Parse(idEmployee.Text);
            bool isAdded = DataWriter.NewOrder(order, client, employee);
        }
    }
}
