using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_application
{
    public class ComboBoxModel
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
}
