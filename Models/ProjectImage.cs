using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Portofolio.Models
{
    [Table("projectimages")]
    [Index(nameof(ProjectId), Name = "ProjectId")]
    public partial class ProjectImage
    {
        public ProjectImage()
        {
            ImagePath = "img/committee/mm.jpg";
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string ImagePath { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("ProjectImages")]
        public virtual Project Project { get; set; }
    }
}
