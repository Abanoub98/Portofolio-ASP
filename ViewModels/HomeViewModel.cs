using Portofolio.Models;
using System.Collections.Generic;
namespace Portofolio.ViewModels
{
    public class HomeViewModel : ParentHomeViewModel
    {
        public ICollection<User> Founders {get; set;}
    }
}