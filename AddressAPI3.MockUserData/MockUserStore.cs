using System;
using System.Collections.Generic;
using AddressAPI3.Domain;

namespace AddressAPI3.MockUserData
{
    public class MockUserStore
    {
        public static MockUserStore Current { get; } = new MockUserStore();

        public List<User> Users { get; set; }

        public MockUserStore()
        {
            Users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Ant",
                    Password = "aaa",
                    Username = "AA"
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Billy",
                    LastName = "Bragg",
                    Password = "bbb",
                    Username = "BB"
                },
                new User()
                {
                    Id = 3,
                    FirstName = "Chris",
                    LastName = "Columbus",
                    Password = "ccc",
                    Username = "CC"
                },
                new User()
                {
                    Id = 4,
                    FirstName = "Diana",
                    LastName = "Dors",
                    Password = "ddd",
                    Username = "DD"
                }
            };
        }
    }
}
