using E_StoreRestApi.Models.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_StoreRestApi.Database
{
    public class EStoreIdentityDbContext : IdentityDbContext<User>
    {
        public EStoreIdentityDbContext(DbContextOptions<EStoreIdentityDbContext> options) : base(options)
        {
        }
    }
}
