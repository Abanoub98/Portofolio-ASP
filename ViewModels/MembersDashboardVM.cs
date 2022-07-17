using Portofolio.Models;
namespace Portofolio.ViewModels
{
    public class MembersDashboardVM : DashboardViewModel
    {
        public PaginationViewModel<User> UsersPagination { get; set; }
    }
}