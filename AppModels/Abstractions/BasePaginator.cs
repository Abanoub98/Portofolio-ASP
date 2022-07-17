using System.Collections.Generic;
using Portofolio.ViewModels;
using System.Linq;
using System;
namespace Portofolio.AppModels.Services
{
    public abstract class BasePaginator<T> : IPaginator<T> where T : class
    {
        protected abstract int NumItemsInPage { get; set; }

        protected abstract int NumPageLinksDisplay { get; set; }

        public virtual PaginationViewModel<T> Paginate(ICollection<T> collection, int page)
        {
            double maxCount = (double)collection.Count / (double)NumItemsInPage;
            int maxPageCount = Convert.ToInt32(Math.Ceiling(maxCount));
            if(page > maxPageCount)
            {
                page = maxPageCount;
            }
            return new PaginationViewModel<T>
            {
                Collection = collection.Skip((page - 1) * NumItemsInPage).Take(NumItemsInPage).ToHashSet(),
                CurrentPage = page,
                DisplayCount = NumPageLinksDisplay,
                MaxPageCount = maxPageCount
            };
        }
    }
}