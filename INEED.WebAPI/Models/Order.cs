using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace INEED.WebAPI.Models
{
    [Table("orders")]
    [Index(nameof(CustomerPhone), Name = "customerPhone")]
    [Index(nameof(WorkerPhone), Name = "workerPhone")]
    public partial class Order
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("customerPhone")]
        [StringLength(20)]
        public string CustomerPhone { get; set; } = null!;
        [Column("workerPhone")]
        [StringLength(20)]
        public string WorkerPhone { get; set; } = null!;
        [Column("content")]
        [StringLength(10000)]
        public string Content { get; set; } = null!;
        [Column("time", TypeName = "datetime")]
        public DateTime Time { get; set; }
        [Column("isSent")]
        public bool? IsSent { get; set; }
        [Column("image")]
        public byte[]? Image { get; set; }

        [ForeignKey(nameof(CustomerPhone))]
        [InverseProperty(nameof(Customer.Orders))]
        public virtual Customer CustomerPhoneNavigation { get; set; } = null!;
        [ForeignKey(nameof(WorkerPhone))]
        [InverseProperty(nameof(ServiceProvider.Orders))]
        public virtual ServiceProvider WorkerPhoneNavigation { get; set; } = null!;
    }
}
