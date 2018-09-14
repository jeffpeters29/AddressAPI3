using System;
using System.ComponentModel.DataAnnotations;

namespace AddressAPI3.Domain
{
    public class Address : IEntity
    {
        [Required]
        public string Postcode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Town { get; set; }

        [MaxLength(100)]
        public string Street { get; set; }

        public int? Number { get; set; }

        [Required]
        [MaxLength(100)]
        public string Organisation { get; set; }

        [Required]
        [StringLength(8)]
        public string UDPRN { get; set; }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
