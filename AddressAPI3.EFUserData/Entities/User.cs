using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AddressAPI3.EFData.Entities;

namespace AddressAPI3.EFUserData.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
