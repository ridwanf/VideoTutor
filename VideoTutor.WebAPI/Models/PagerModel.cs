using System.Collections.Generic;
using System.Linq;

namespace VideoTutor.WebAPI.Models
{
    public class PagerModel<T> where T : class
    {
        public IQueryable<T> Data { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int Total { get; set; }
    }
}