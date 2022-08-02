using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace INEED.WebAPI.Models
{
    [Table("serviceProviders")]
    [Index(nameof(Email), Name = "email", IsUnique = true)]
    [Index(nameof(ServiceId), Name = "serviceId", IsUnique = false)]
    public partial class ServiceProvider
    {
        public ServiceProvider()
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
        [Column("nationalId")]
        [StringLength(14)]
        public string NationalId { get; set; } = null!;
        [Column("rate")]
        [Precision(3, 1)]
        public decimal? Rate { get; set; }
        [Column("serviceId")]
        public Guid ServiceId { get; set; }
        [Column("latitude")]
        [Precision(7, 5)]
        public decimal Latitude { get; set; }
        [Column("longitude")]
        [Precision(8, 5)]
        public decimal Longitude { get; set; }
        [Column("profilePicture")]
        public byte[]? ProfilePicture { get; set; }

        public virtual Unique EmailNavigation { get; set; } = null!;
        [ForeignKey(nameof(PhoneNumber))]
        [InverseProperty(nameof(Unique.ServiceProviderPhoneNumberNavigation))]
        public virtual Unique PhoneNumberNavigation { get; set; } = null!;
        [ForeignKey(nameof(ServiceId))]
        [InverseProperty(nameof(ServiceCategory.ServiceProvider))]
        public virtual ServiceCategory Service { get; set; } = null!;
        [InverseProperty(nameof(Message.ReceiverPhoneNavigation))]
        public virtual ICollection<Message> Messages { get; set; }
        [InverseProperty(nameof(Order.WorkerPhoneNavigation))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
