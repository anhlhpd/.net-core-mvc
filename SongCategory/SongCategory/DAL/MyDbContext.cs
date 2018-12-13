using Microsoft.EntityFrameworkCore;
using SongCategory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongCategory.DAL
{
    public class MyDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SongCategory.Models.SongCategory> SongCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongCategory.Models.SongCategory>().HasKey(sc => new { sc.SongId, sc.CategoryId});
        }
    }
}
