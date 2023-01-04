using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_application
{
    public static class DataValidator
    {
        public static bool isDateTime(string datetime)
        {
            try
            {
                DateTime.Parse(datetime);
                return true;
            }
            catch { return false; }
        }
    }
}
