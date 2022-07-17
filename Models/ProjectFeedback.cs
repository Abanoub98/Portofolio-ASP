using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Portofolio.Models
{
    [Table("projectfeedbacks")]
    [Index(nameof(ProjectId), Name = "ProjectId")]
    public partial class ProjectFeedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Feedback { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("ProjectFeedbacks")]
        public virtual Project Project { get; set; }
    }
}
