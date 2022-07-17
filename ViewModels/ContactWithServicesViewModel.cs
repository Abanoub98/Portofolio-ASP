using Portofolio.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Portofolio.ViewModels
{
    public class ContactWithServicesViewModel : ParentHomeViewModel
    {
        public ICollection<Service> Services { get; set; }

        public Contact Contact { get; set; }

        [Required(ErrorMessage = "Please select service(s) you require")]
        public ICollection<int> RequestedServicesIds { get; set; }

    }
}