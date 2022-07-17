using Portofolio.Models;

namespace Portofolio.AppModels.Services
{
    public class MembersPaginator : BasePaginator<User>
    {
        protected override int NumItemsInPage { get; set; }
        protected override int NumPageLinksDisplay { get; set; }

        public MembersPaginator()
        {
            NumItemsInPage = 8;
            NumPageLinksDisplay = 4;
        }
        
    }
}