using Portofolio.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Portofolio.ViewModels
{
    public class ContactDetailsViewModel : DashboardViewModel
    {
        public Contact Contact { get; set; }

        public ICollection<ContactStatus> ContactStatuses { get; set; }

        [Required]
        public int StatusId {get; set;}
    }
}