using Portofolio.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Portofolio.ViewModels
{
    public class UserProfileViewModel : DashboardViewModel
    {
        public ICollection<LinkType> LinkTypes { get; set; }

        [Required(ErrorMessage = "Links are required")]
        public ICollection<string> Links { get; set; }
        [Required(ErrorMessage = "Links are required")]
        public ICollection<int> LinksIds { get; set; }

        public ICollection<int> LinkTypeIds { get; set; }

    }
}