using Portofolio.Models;
using System.Collections.Generic;
namespace Portofolio.ViewModels
{
    public class ContactsDashboardViewModel : DashboardViewModel
    {
        public ICollection<Contact> Contacts { get; set; }
    }
}