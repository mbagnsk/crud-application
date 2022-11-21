using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_application
{
    public class Order
    {
        public string idzamowienia { get; set; }
        public string idklienta { get; set; }
        public string idwpeowadzajacego { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{idzamowienia} {idklienta} {idwpeowadzajacego}";
            }
        }
    }
}
