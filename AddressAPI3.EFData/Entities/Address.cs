using System.ComponentModel.DataAnnotations;

namespace AddressAPI3.EFData.Entities
{
    public class Address : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string Postcode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Town { get; set; }

        [MaxLength(100)]
        public string Street { get; set; }

        public int? Number { get; set; }

        [MaxLength(100)]
        public string Organisation { get; set; }

        [Required]
        [StringLength(8)]
        public string UDPRN { get; set; }
    }
}
