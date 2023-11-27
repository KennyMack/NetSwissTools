using System;
using System.Collections.Generic;
using System.Text;

namespace NetSwissTools.Models
{
    public class InfiniteResult<T>: BasePagedResult where T : class
    {
        public IList<T> Results { get; set; }

        public InfiniteResult()
        {
            Results = new List<T>();
            HasNext = false;
        }

        public InfiniteResult(List<T> pItems)
        {
            Results = pItems;
            HasNext = false;
        }
    }
}
