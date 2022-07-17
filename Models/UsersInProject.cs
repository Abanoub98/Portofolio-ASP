using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Portofolio.Models
{
    [Table("usersinprojects")]
    [Index(nameof(ProjectId), Name = "ProjectId")]
    [Index(nameof(RoleId), Name = "RoleId")]
    [Index(nameof(UserId), Name = "UserId")]
    public partial class UsersInProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("UsersInProjects")]
        public virtual Project Project { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(UserRoleInProject.UsersInProjects))]
        public virtual UserRoleInProject Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UsersInProjects")]
        public virtual User User { get; set; }
    }
}
