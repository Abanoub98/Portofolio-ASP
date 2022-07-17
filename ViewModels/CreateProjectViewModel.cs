using Portofolio.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace Portofolio.ViewModels
{
    public class CreateProjectViewModel : DashboardViewModel
    {
        public ICollection<ProjectType> ProjectTypes { get; set; }
        [Required(ErrorMessage = "A project thumbnail is required")]
        public IFormFile ProjectThumbnail { get; set; }

        public IFormFileCollection ProjectImages { get; set; }

        public ICollection<User> Users { get; set; }

        [Required(ErrorMessage = "Project type is required")]
        public int ProjectTypeId { get; set; }

        public ICollection<LinkType> LinkTypes { get; set; }

        public ICollection<string> ProjectLinks { get; set; }

        public ICollection<int> LinkTypesIds { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public ICollection<UserRoleInProject> UserRolesInProject { get; set; }

        [Required(ErrorMessage = "Contributors and roles are required")]
        public ICollection<string> UsersNRolesIds { get; set; }

        [Required(ErrorMessage = "Tools used in project are required")]
        [RegularExpression("([A-Z]|[a-z]|[0-9]|-)+", ErrorMessage = "Please make sure tools follow the Tool1-Tool2 format")]
        public string ToolsUsed { get; set; }

    }
}