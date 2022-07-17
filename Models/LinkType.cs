using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Portofolio.Models
{
    [Table("linktypes")]
    [Index(nameof(Type), Name = "LinkType", IsUnique = true)]
    public partial class LinkType
    {
        public LinkType()
        {
            ProjectLinks = new HashSet<ProjectLink>();
            UserLinks = new HashSet<UserLink>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("LinkType")]
        [StringLength(50)]
        public string Type { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        [InverseProperty(nameof(ProjectLink.Type))]
        public virtual ICollection<ProjectLink> ProjectLinks { get; set; }
        [InverseProperty(nameof(UserLink.Type))]
        public virtual ICollection<UserLink> UserLinks { get; set; }
    }
}
