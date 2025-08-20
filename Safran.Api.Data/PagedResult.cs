using System.Collections.Generic;

namespace Safran.Api.Data
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items {  get; }

        public int TotalCount { get; }

        public PagedResult(IEnumerable<T> items, int total) 
        { 
            Items = items; 
            TotalCount = total;
        }
    }
}
