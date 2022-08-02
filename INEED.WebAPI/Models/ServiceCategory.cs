using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace INEED.WebAPI.Models
{
    [Table("serviceCategories")]
    [Index(nameof(ParentId), Name = "parentId")]
    public partial class ServiceCategory
    {
        public ServiceCategory()
        {
            InverseParent = new HashSet<ServiceCategory>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("title")]
        [StringLength(20)]
        public string Title { get; set; } = null!;
        [Column("parentId")]
        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        [InverseProperty(nameof(ServiceCategory.InverseParent))]
        public virtual ServiceCategory? Parent { get; set; }
        [InverseProperty("Service")]
        public virtual ServiceProvider ServiceProvider { get; set; } = null!;
        [InverseProperty(nameof(ServiceCategory.Parent))]
        public virtual ICollection<ServiceCategory> InverseParent { get; set; }
    }
}
