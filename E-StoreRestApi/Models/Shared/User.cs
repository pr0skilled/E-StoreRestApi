using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace E_StoreRestApi.Models.Shared
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
