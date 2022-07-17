using Portofolio.Models;


namespace Portofolio.ViewModels
{
    public class ProjectsDashboardViewModel : DashboardViewModel
    {
        public PaginationViewModel<Project> PaginationModel { get; set; }
    }
}