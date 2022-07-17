using System.Collections.Generic;
using Portofolio.ViewModels;
namespace Portofolio.AppModels.Services
{
    public interface IPaginator<T> where T : class
    {
        PaginationViewModel<T> Paginate(ICollection<T> collection, int page);
    }
}