using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace INEED.WebAPI.Models
{
    [Table("uniques")]
    [Index(nameof(Email), Name = "email", IsUnique = true)]
    [Index(nameof(PhoneNumber), Name = "phoneNumber", IsUnique = true)]
    public partial class Unique
    {
        [Key]
        [Column("phoneNumber")]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = null!;
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        public virtual Customer CustomerEmailNavigation { get; set; } = null!;
        [InverseProperty(nameof(Customer.PhoneNumberNavigation))]
        public virtual Customer CustomerPhoneNumberNavigation { get; set; } = null!;
        public virtual ServiceProvider ServiceProviderEmailNavigation { get; set; } = null!;
        [InverseProperty(nameof(ServiceProvider.PhoneNumberNavigation))]
        public virtual ServiceProvider ServiceProviderPhoneNumberNavigation { get; set; } = null!;
    }
}
