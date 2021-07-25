using System;
using System.Collections.Generic;
using E_StoreRestApi.Database;
using E_StoreRestApi.Models.Address;
using E_StoreRestApi.Repositories.Interfaces;

namespace E_StoreRestApi.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private EStoreDbContext db;

        public AddressRepository(EStoreDbContext context_)
        {
            db = context_;
        }

        public void AddAddress(Address address)
        {
            db.Addresses.Add(address);
            db.SaveChanges();
        }

        public void DeleteAddress(Address address)
        {
            db.Addresses.Remove(address);
            db.SaveChanges();
        }

        public Address GetAddressById(long id)
        {
            var address = db.Addresses.Find(id);
            return address;
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            var addresses = db.Addresses;
            return addresses;
        }

        public void UpdateAddress(Address address)
        {
            db.Addresses.Update(address);
            db.SaveChanges();
        }
    }
}
