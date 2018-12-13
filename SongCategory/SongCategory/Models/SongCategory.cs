using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongCategory.Models
{
    public class SongCategory
    {
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
