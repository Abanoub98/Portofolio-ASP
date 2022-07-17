using Portofolio.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace Portofolio.ViewModels
{
    public class ProjectDetailsDashboardViewModel : DashboardViewModel
    {

        public ICollection<User> Users { get; set; }
        public Project ChosenProject { get; set; }

        public ICollection<ProjectType> ProjectTypes { get; set; }

        public IFormFile ProjectThumbnail { get; set; }

        public IFormFileCollection ProjectImages { get; set; }

        public int ProjectTypeId { get; set; }

        public ICollection<string> ProjectLinks { get; set; }

        public ICollection<int> LinksIds { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Contributors and roles are required")]
        public ICollection<string> UsersNRolesIds { get; set; }

        public ICollection<string> AddUsersNRolesIds { get; set; }

        public ICollection<UserRoleInProject> UserRolesInProject { get; set; }

        [Required(ErrorMessage = "Tools used in project are required")]
        [RegularExpression("([A-Z]|[a-z]|[0-9]|-)+", ErrorMessage = "Please make sure tools follow the Tool1-Tool2 format")]
        public string ToolsUsed { get; set; }

        [Required(ErrorMessage = "Project id is required")]
        public int ProjectId {get; set;}
    }
}