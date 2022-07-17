using System.Collections.Generic;

namespace Portofolio.ViewModels
{
    public class PaginationViewModel<T> where T : class
    {
        public ICollection<T> Collection { get; set; }
        public int CurrentPage { get; set; }

        public int DisplayCount { get; set; }

        public int MaxPageCount { get; set; }
    }
}