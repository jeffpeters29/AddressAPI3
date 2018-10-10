using System.ComponentModel.DataAnnotations;

namespace AddressAPI3.EFData.Entities
{
    public class Address : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string Postcode { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostcodeDisplay { get; set; }
        [Required]
        [MaxLength(30)]
        public string Town { get; set; }

        [MaxLength(30)]
        public string SubBuildingName { get; set; }
        [MaxLength(50)]
        public string BuildingName { get; set; }
        [MaxLength(4)]
        public string BuildingNumber { get; set; }
        [MaxLength(60)]
        public string Organisation { get; set; }
        [MaxLength(60)]
        public string Department { get; set; }
        [MaxLength(6)]
        public string POBox { get; set; }

        [MaxLength(80)]
        public string Thoroughfare { get; set; }
        [MaxLength(80)]
        public string ThoroughfareDependent { get; set; }

        [MaxLength(35)]
        public string Locality { get; set; }
        [MaxLength(35)]
        public string LocalityDependent { get; set; }

        //[Required]
        //[StringLength(8)]
        //public string UDPRN { get; set; }
    }
}
