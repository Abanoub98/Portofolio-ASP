using Portofolio.Models;
namespace Portofolio.ViewModels
{
    public class ServicesViewModel : ParentHomeViewModel
    {
        public PaginationViewModel<Service> PaginationModel {get; set;}
    }
}