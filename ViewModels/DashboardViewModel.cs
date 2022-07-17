using Portofolio.Models;

namespace Portofolio.ViewModels
{
    public class DashboardViewModel
    {
        public User User { get; set; }

        public int PendingContactsCount { get; set; }
    }
}