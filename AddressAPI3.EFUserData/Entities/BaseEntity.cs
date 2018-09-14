using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressAPI3.EFData.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
