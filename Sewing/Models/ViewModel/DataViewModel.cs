using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewing.Models.ViewModel
{
    public class DataViewModel<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int PageCount { get; set; }

        public int CurrentPage { get; set; }
    }
}
