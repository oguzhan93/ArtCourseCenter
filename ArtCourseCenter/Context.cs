global using Microsoft.EntityFrameworkCore;
using ArtCourseCenter.Models;

namespace ArtCourseCenter
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-8OMSEHE;Database=ArtCourseCenter;Trusted_Connection = true;TrustServerCertificate=true");
        }
        public Microsoft.EntityFrameworkCore.DbSet<Trainee> Trainees { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Instructor> Instructors { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Course> Courses { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<CoursesAndTrainees> CoursesAndTrainees { get;set; }

    }
}
