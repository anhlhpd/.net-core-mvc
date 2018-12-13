using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace T1708ENewWeb.Models
{
    public class T1708ENewWebContext : DbContext
    {
        public T1708ENewWebContext (DbContextOptions<T1708ENewWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student() {
                    RollNumber = "A002768",
                    FirstName = "Hung",
                    Email = "xuanhung@gmail.com"
                },
                new Student()
                {
                    RollNumber = "A002778",
                    FirstName = "Luyen",
                    Email = "luyen@gmail.com"
                },
                new Student()
                {
                    RollNumber = "A002769",
                    FirstName = "Hong",
                    Email = "hong@gmail.com"
                }
            );
            modelBuilder.Entity<Mark>().HasData(
                new Mark()
                {
                    Id = 1,
                    SubjectName = "Java",
                    StudentRollNumber = "A002768",
                    SubjectMark = 20
                },
                new Mark()
                {
                    Id = 2,
                    SubjectName = "C#",
                    StudentRollNumber = "A002768",
                    SubjectMark = 23
                },
                new Mark()
                {
                    Id = 3,
                    SubjectName = "PHP",
                    StudentRollNumber = "A002768",
                    SubjectMark = 22
                },
                new Mark()
                {
                    Id = 4,
                    SubjectName = "HTML",
                    StudentRollNumber = "A002778",
                    SubjectMark = 25
                },
                new Mark()
                {
                    Id = 5,
                    SubjectName = "Javascript",
                    StudentRollNumber = "A002778",
                    SubjectMark = 22
                }
            );
        }

        public DbSet<T1708ENewWeb.Models.Student> Student { get; set; }
        public DbSet<T1708ENewWeb.Models.Mark> Mark { get; set; }
    }
}
