using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_StoreRestApi.Models.Shared
{
    public class BaseObject
    {
        public long Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
