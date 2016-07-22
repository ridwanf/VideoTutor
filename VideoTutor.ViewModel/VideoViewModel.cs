using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoTutor.ViewModel
{
    public class VideoViewModel
    {
        public  int Id { get; set; }
        public string Title { get; set; }
        public string Level { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Author { get; set; }
        public int? Rating { get; set; }
        public bool? IsHaveSub { get; set; }
        public string[] Technology { get; set; }
        public string Source { get; set; }
        public decimal? Size { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
