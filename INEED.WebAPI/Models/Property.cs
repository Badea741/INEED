using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace INEED.WebAPI.Models
{
    [Table("properties")]
    [Index(nameof(CategoryId), Name = "categoryId")]
    public partial class Property
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("categoryId")]
        public Guid CategoryId { get; set; }
        [Column("details", TypeName = "text")]
        public string? Details { get; set; }
        [Column("price")]
        [Precision(9, 2)]
        public decimal Price { get; set; }
        [Column("rate")]
        [Precision(3, 1)]
        public decimal? Rate { get; set; }
        [Column("image")]
        public byte[] Image { get; set; } = null!;

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(PropertyCategory.Properties))]
        public virtual PropertyCategory Category { get; set; } = null!;
    }
}
