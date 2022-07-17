using Portofolio.Models;
using System.ComponentModel.DataAnnotations;
namespace Portofolio.ViewModels
{
    public class ProjectDetailsViewModel : ParentHomeViewModel
    {
        public Project Project {get; set;}

        [Required(ErrorMessage = "Feedback message is required")]
        public string Feedback {get; set;}

        public int ProjectId {get; set;}
    }
}