using System;

namespace AddressAPI3.Domain
{
    public class ActivityLog : IEntity
    {
        public int UserId { get; set; }
        public string Referer { get; set; }
        public string SearchTerm { get; set; }
        public long ElapsedTime { get; set; }

        public int Id { get; set; }
        public DateTime Inserted { get; set; }
    }
}
