using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_StoreRestApi.Database;
using E_StoreRestApi.Models.Customer;
using E_StoreRestApi.Repositories.Interfaces;

namespace E_StoreRestApi.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private EStoreDbContext db;

        public CustomerRepository(EStoreDbContext context_)
        {
            db = context_;
        }

        public Customer FindCustomerById(long id)
        {
            var customer = db.Customers.Find(id);
            return customer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = db.Customers;
            return customers;
        }

        public void SaveCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            db.Customers.Update(customer);
            db.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            db.Customers.Remove(customer);
            db.SaveChanges();
        }   
    }
}
