using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_application
{
    public class CompaniesComboBoxModel
    {
        private IList<Client> _clients;
        public IList<Client> Clients
        {
            get
            {
                if (_clients == null)
                    _clients = new List<Client>();
                return _clients;
            }
            set { _clients = value; }
        }
    }

    public class ProductsComboBoxModel
    {
        private IList<Product> _procucts;
        public IList<Product> Products
        {
            get
            {
                if (_procucts == null)
                    _procucts = new List<Product>();
                return _procucts;
            }
            set { _procucts = value; }
        }
    }
}
