using Portofolio.Models;

namespace Portofolio.AppModels.Services
{
    public class ProjectsPaginator : BasePaginator<Project>
    {
        protected override int NumItemsInPage { get; set; }
        protected override int NumPageLinksDisplay { get; set; }

        public ProjectsPaginator()
        {
            NumItemsInPage = 4;
            NumPageLinksDisplay = 4;
        }
    }
}