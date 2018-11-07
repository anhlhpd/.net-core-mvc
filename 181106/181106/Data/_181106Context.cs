using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _181106.Models
{
    public class _181106Context : DbContext
    {
        public _181106Context (DbContextOptions<_181106Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    RollNumber = "A0001",
                    FirstName = "Hung",
                    LastName = "Dao",
                    Email = "daohung@gmail.com"
                },
                new Student()
                {
                    RollNumber = "A0002",
                    FirstName = "Luyen",
                    LastName = "Dao",
                    Email = "daoluyen@gmail.com"
                },
                new Student()
                {
                    RollNumber = "A0003",
                    FirstName = "Hong",
                    LastName = "Dao",
                    Email = "daohong@gmail.com"
                }
            );
            modelBuilder.Entity<Mark>().HasData(
                new Mark()
                {
                    Id = 1,
                    SubjectName = "Toan",
                    SubjectMark = 30,
                    StudentRollNumber = "A0001"
                },
                new Mark()
                {
                    Id = 2,
                    SubjectName = "Van",
                    SubjectMark = 40,
                    StudentRollNumber = "A0002"
                },
                new Mark()
                {
                    Id = 3,
                    SubjectName = "Hoa",
                    SubjectMark = 50,
                    StudentRollNumber = "A0003"
                }
            );
        }

        public DbSet<_181106.Models.Student> Student { get; set; }
        public DbSet<_181106.Models.Mark> Mark { get; set; }
    }
}
