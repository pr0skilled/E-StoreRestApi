using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_StoreRestApi.Models.Shared;

namespace E_StoreRestApi.Messages.DataTransferObjects.Shared
{
    public class PersonDTO : BaseObject
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
        public string DateOfBirth { get; set; }
    }
}
