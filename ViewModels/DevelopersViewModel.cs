using Portofolio.Models;
namespace Portofolio.ViewModels
{
    public class DevelopersViewModel : ParentHomeViewModel
    {
        public PaginationViewModel<User> PaginationModel {get; set;}
    }
}