using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressAPI3.EFData.Entities
{
    public class Postcode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [MaxLength(10)]
        public string Id { get; set; }

        [MaxLength(80)]
        public string Description { get; set; }

        [Required]
        [MaxLength(30)]
        public string Town { get; set; }
    }
}
