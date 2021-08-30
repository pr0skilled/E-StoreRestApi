using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_StoreRestApi.Models;
using E_StoreRestApi.Models.Shared;

namespace E_StoreRestApi.Models.Customer
{
    public class Customer : BaseObject
    {
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public IEnumerable<Order.Order> Orders { get; set; }
        public IEnumerable<Address.Address> Addresses { get; set; }
    }
}
