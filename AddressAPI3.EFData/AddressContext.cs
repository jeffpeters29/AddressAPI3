using AddressAPI3.EFData.Entities;
using Microsoft.EntityFrameworkCore;

namespace AddressAPI3.EFData
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
    }
}
