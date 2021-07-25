using System.Collections.Generic;
using E_StoreRestApi.Models.Address;

namespace E_StoreRestApi.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAllAddresses();
        Address GetAddressById(long id);
        void AddAddress(Address address);
        void DeleteAddress(Address address);
        void UpdateAddress(Address address);
    }
}
