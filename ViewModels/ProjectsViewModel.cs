using Portofolio.Models;
namespace Portofolio.ViewModels
{
    public class ProjectsViewModel : ParentHomeViewModel
    {
        public PaginationViewModel<Project> PaginationModel {get; set;}
    }
}