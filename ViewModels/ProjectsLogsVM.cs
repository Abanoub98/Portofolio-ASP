using Portofolio.Models;
using System.Collections.Generic;
namespace Portofolio.ViewModels
{
    public class ProjectsLogsVM : DashboardViewModel
    {
        public ICollection<ProjectLog> Logs { get; set; }
    }
}