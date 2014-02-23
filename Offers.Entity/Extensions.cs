using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Offers.Entities;

namespace Offers.Entity
{
    public static class HelperExtensions
    {
        public static string GetFullName(this Customer customer)
        {
            return string.Format("{0} {1}", customer.Name, customer.SurName);
        }

        public static string GetFullName(this Manager manager)
        {
            return string.Format("{0} {1}", manager.Name, manager.SurName);
        }
    }
}
