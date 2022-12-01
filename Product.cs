using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_application
{
    public  class Product
    {
        public int IDProduct { get; set; }
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public double NetPrice { get; set; }

        public double GrossPrice { get; set; }

    }
}
