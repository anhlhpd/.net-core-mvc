using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongCategory.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Singer { get; set; }
        public string Link { get; set; }
        public ICollection<SongCategory> SongCategories { get; set; }
    }
}
