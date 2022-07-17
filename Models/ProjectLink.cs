using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Portofolio.Models
{
    [Table("projectlinks")]
    [Index(nameof(ProjectId), Name = "ProjectId")]
    [Index(nameof(TypeId), Name = "TypeId")]
    public partial class ProjectLink
    {
        public ProjectLink()
        {
            Link = "#";
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TypeId { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Link { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("ProjectLinks")]
        public virtual Project Project { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(LinkType.ProjectLinks))]
        public virtual LinkType Type { get; set; }
    }
}
