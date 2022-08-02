using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace INEED.WebAPI.Models
{
    [Table("messages")]
    [Index(nameof(ReceiverPhone), Name = "receiverPhone")]
    [Index(nameof(SenderPhone), Name = "senderPhone")]
    public partial class Message
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("senderPhone")]
        [StringLength(20)]
        public string SenderPhone { get; set; } = null!;
        [Column("receiverPhone")]
        [StringLength(20)]
        public string ReceiverPhone { get; set; } = null!;
        [Column("content")]
        [StringLength(5000)]
        public string Content { get; set; } = null!;
        [Column("time", TypeName = "datetime")]
        public DateTime Time { get; set; }
        [Column("isSent")]
        public bool? IsSent { get; set; }

        [ForeignKey(nameof(ReceiverPhone))]
        [InverseProperty(nameof(ServiceProvider.Messages))]
        public virtual ServiceProvider ReceiverPhoneNavigation { get; set; } = null!;
        [ForeignKey(nameof(SenderPhone))]
        [InverseProperty(nameof(Customer.Messages))]
        public virtual Customer SenderPhoneNavigation { get; set; } = null!;
    }
}
