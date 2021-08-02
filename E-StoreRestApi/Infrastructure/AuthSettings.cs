using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_StoreRestApi.Infrastructure
{
    public class AuthSettings
    {
        public string Key { get; set; }
        public int ExpirationInMinutes { get; set; }
    }
}
