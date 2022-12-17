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
    /// Interaction logic for InvoiceDetailsWindow.xaml
    /// </summary>
    public partial class InvoiceDetailsWindow : Window
    {
        public InvoiceDetailsWindow(Invoice invoice)
        {
            InitializeComponent();
            FillWindow(invoice);
        }

        private void FillWindow(Invoice invoice)
        {
            InvoiceTextBlock.Text = invoice.idInvoice.ToString();
            ClientTextBlock.Text = invoice.companyName;
            IsOrderActiveCheckBox.IsChecked = invoice.isOrderActive;
            OrderDatetimeTextBlock.Text = invoice.orderDatetime.ToString();
            DueDateTextBlock.Text = invoice.dueDate.ToString();
            PaymentAmountTextBlock.Text = invoice.paymentAmount.ToString();
            NetPriceTextBlock.Text = DataAccess.GetInvoiceNetPrice(invoice.idInvoice).ToString();
        }
    }
}
