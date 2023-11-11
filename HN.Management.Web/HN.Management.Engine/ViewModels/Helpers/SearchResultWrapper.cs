using System.Collections.Generic;

namespace HN.Management.Engine.ViewModels.Helpers
{
    public class SearchResultWrapper<T>
    {
        public IEnumerable<T> Results { get; set; }

        public int TotalCount { get; set; }
    }
}
