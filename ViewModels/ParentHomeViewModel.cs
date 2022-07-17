using Portofolio.Models;
using System.Collections.Generic;
namespace Portofolio.ViewModels
{
    public class ParentHomeViewModel
    {
        public ICollection<Service> LatestServices { get; set; }

        public ICollection<Project> LatestProjects { get; set; }
    }
}