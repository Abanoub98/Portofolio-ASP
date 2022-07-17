using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Portofolio.Models
{
    [Table("projecttypes")]
    [Index(nameof(Type), Name = "ProjectType", IsUnique = true)]
    public partial class ProjectType
    {
        public ProjectType()
        {
            Projects = new HashSet<Project>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("ProjectType")]
        [StringLength(50)]
        public string Type { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        [InverseProperty(nameof(Project.Type))]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
