using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace Portofolio.Models
{
    [Table("users")]
    public class User : IdentityUser<int>
    {
        public User()
        {
            UserLinks = new HashSet<UserLink>();
            UsersInProjects = new HashSet<UsersInProject>();
            PhoneNumber = "N/A";
            Specialization = "N/A";
            ImagePath = "img/avatar.png";
        }

        [Required(ErrorMessage = "Username is required")]
        public override string UserName { get; set; }
        [Required]
        [EmailAddress]
        public override string Email { get; set; }

        [Phone(ErrorMessage = "Phone number format is invalid, correct format +xx xxxxxxxxxx")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number format is invalid, correct format +xx xxxxxxxxxx")]
        public override string PhoneNumber { get; set; }

        [StringLength(maximumLength: 255)]
        public string Specialization { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [InverseProperty(nameof(UserLink.User))]
        public virtual ICollection<UserLink> UserLinks { get; set; }
        [InverseProperty(nameof(UsersInProject.User))]
        public virtual ICollection<UsersInProject> UsersInProjects { get; set; }

        [InverseProperty(nameof(ProjectLog.User))]
        public virtual ICollection<ProjectLog> ProjectLogs { get; set; }

        [InverseProperty(nameof(Project.Creator))]

        public virtual ICollection<Project> CreatedProjects { get; set; }

        [InverseProperty(nameof(UserCertificates.Owner))]
        public virtual ICollection<UserCertificates> Certificates { get; set; }

    }
}