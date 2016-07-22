using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace VideoTutor.Data.Domain
{
    public class Video : BaseClass<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
        public string Title { get; set; }
        public string Level { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Author { get; set; }
        public int? Rating { get; set; }
        public bool? IsHaveSub { get; set; }
        public string Technology { get; set; }
        public string Source { get; set; }
        public decimal? Size { get; set; }

        [NotMapped]
        public string[] TechArray { get;set; }
        
    }
}
