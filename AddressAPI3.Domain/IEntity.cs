using System;

namespace AddressAPI3.Domain
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime Inserted { get; set; }
    }
}
