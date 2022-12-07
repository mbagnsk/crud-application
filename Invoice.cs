using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_application
{
    public class Invoice
    {
        public int idInvoice { get; set; }
        public int idClient { get; set; }
        public DateTime orderDatetime { get; set; }
        public DateOnly? dueDate { get; set; }
        public DateOnly? paymentDate { get; set; }
        public double paymentAmount { get; set; }
        public bool orderActive { get; set; }

        public Invoice(int idinvoice, int idclient, DateTime orderdatetime, DateOnly duedate, DateOnly paymentdate, double paymentamount, bool orderactive)
        {
            idInvoice = idinvoice;
            idClient = idclient;
            orderDatetime = orderdatetime;
            dueDate = duedate;
            paymentDate = paymentdate;
            paymentAmount = paymentamount;
            orderActive = orderactive;
        }
    }
}
