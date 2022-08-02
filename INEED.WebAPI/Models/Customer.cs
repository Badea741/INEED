using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace INEED.WebAPI.Models
{
    [Table("customers")]
    [Index(nameof(Email), Name = "email", IsUnique = true)]
    public partial class Customer
    {
        public Customer()
        {
            Messages = new HashSet<Message>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("phoneNumber")]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = null!;
        [Column("name")]
        [StringLength(80)]
        public string Name { get; set; } = null!;
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; } = null!;
        [Column("latitude")]
        [Precision(7, 5)]
        public decimal? Latitude { get; set; }
        [Column("longitude")]
        [Precision(8, 5)]
        public decimal? Longitude { get; set; }

        public virtual Unique EmailNavigation { get; set; } = null!;
        [ForeignKey(nameof(PhoneNumber))]
        [InverseProperty(nameof(Unique.CustomerPhoneNumberNavigation))]
        public virtual Unique PhoneNumberNavigation { get; set; } = null!;
        [InverseProperty(nameof(Message.SenderPhoneNavigation))]
        public virtual ICollection<Message> Messages { get; set; }
        [InverseProperty(nameof(Order.CustomerPhoneNavigation))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
