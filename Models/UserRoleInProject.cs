using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Portofolio.Models
{
    [Table("userrolesinproject")]
    public partial class UserRoleInProject
    {
        public UserRoleInProject()
        {
            UsersInProjects = new HashSet<UsersInProject>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Role { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        [InverseProperty(nameof(UsersInProject.Role))]
        public virtual ICollection<UsersInProject> UsersInProjects { get; set; }
    }
}
