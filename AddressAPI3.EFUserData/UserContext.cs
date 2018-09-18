using System;
using Microsoft.EntityFrameworkCore;
using AddressAPI3.EFUserData.Entities;

namespace AddressAPI3.EFUserData
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Eddie",
                    LastName = "Eagle",
                    //Password = "eee",
                    PasswordHash = "Da21ROPBNsSb3f3CzxgoxWX2YkMmLh8QmqeBiIZ4fXs=",
                    Username = "EE",
                    Inserted = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    FirstName = "Freddie",
                    LastName = "Flintoff",
                    //Password = "fff",
                    PasswordHash = "B9tplMn7jIAnRdZseqRCvzGko0ZHFj7+B1IDQ4u1k/8=",
                    Username = "FF",
                    Inserted = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                },
                new User
                {
                    Id = 3,
                    FirstName = "Graham",
                    LastName = "Gooch",
                    //Password = "fff",
                    PasswordHash = "/21TLJ9cxwyebxIAz2R92sxLU3beXJ4Jyihjdxsxu0E=",
                    Username = "GG",
                    Inserted = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );
        }
    }
}
