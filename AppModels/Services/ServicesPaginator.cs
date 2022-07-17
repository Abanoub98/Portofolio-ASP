using Portofolio.Models;
namespace Portofolio.AppModels.Services
{
    public class ServicesPaginator : BasePaginator<Service>
    {
        protected override int NumItemsInPage { get; set; }
        protected override int NumPageLinksDisplay { get; set; }

        public ServicesPaginator()
        {
            NumItemsInPage = 4;
            NumPageLinksDisplay = 4;
        }
        
    }
}