using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressAPI3.EFUserData.Entities
{
    public class ActivityLog : Domain.IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public string Referer { get; set; }
        [Required]
        public string SearchTerm { get; set; }
        [Required]
        public long ElapsedTime { get; set; }

        [Required]
        public DateTime Inserted { get; set; }
    }
}
