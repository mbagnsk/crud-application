using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_application
{
    public class OrderElement : Product
    {
        public int Quantity { get; set; }
        public OrderElement(int idProduct, string productName, string productDescription, double netPrice, double grossPrice, int quantity)
        {
            IDProduct = idProduct;
            ProductName = productName;
            ProductDescription = productDescription;
            NetPrice = netPrice;
            GrossPrice = grossPrice;
            Quantity = quantity;
            orderElements.Add(this);
        }

        static public List<OrderElement> orderElements = new List<OrderElement>();
    }
}
