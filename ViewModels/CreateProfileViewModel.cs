using Portofolio.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Portofolio.ViewModels
{
    public class CreateProfileViewModel : DashboardViewModel
    {
        public ICollection<LinkType> LinkTypes { get; set; }

        public ICollection<string> Links { get; set; }

        public ICollection<int> LinkTypeIds { get; set; }

        public string ReturnAction { get; set; }

        public string ReturnController { get; set; }

        [Required]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

    }
}