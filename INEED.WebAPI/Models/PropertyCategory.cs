using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace INEED.WebAPI.Models
{
    [Table("propertyCategories")]
    [Index(nameof(ParentId), Name = "parentId")]
    public partial class PropertyCategory
    {
        public PropertyCategory()
        {
            InverseParent = new HashSet<PropertyCategory>();
            Properties = new HashSet<Property>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("title")]
        [StringLength(100)]
        public string Title { get; set; } = null!;
        [Column("parentId")]
        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        [InverseProperty(nameof(PropertyCategory.InverseParent))]
        public virtual PropertyCategory? Parent { get; set; }
        [InverseProperty(nameof(PropertyCategory.Parent))]
        public virtual ICollection<PropertyCategory> InverseParent { get; set; }
        [InverseProperty(nameof(Property.Category))]
        public virtual ICollection<Property> Properties { get; set; }
    }
}
