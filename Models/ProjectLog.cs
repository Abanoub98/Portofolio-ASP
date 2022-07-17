using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Portofolio.Models
{
    [Table("ProjectLogs")]
    public class ProjectLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> UserId { get; set; }

        public Nullable<int> CreatorId { get; set; }

        [Required(ErrorMessage = "Action made is required")]
        public string Action { get; set; }

        [Required(ErrorMessage = "Project title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Creator name is required")]
        public string CreatorName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("ProjectLogs")]
        public virtual User User { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("Logs")]
        public virtual Project Project { get; set; }

    }
}