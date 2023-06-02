using Microsoft.EntityFrameworkCore;
using StudentMS.Data.Configurations;
using StudentMS.Data.Entities;
using StudentMS.Data.Extensions;

namespace StudentMS.Data.EF
{
    public class StudentMSDbContext : DbContext
    {
        public StudentMSDbContext(DbContextOptions options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());

            //Data seeding
            modelBuilder.Seed();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }


    }
}
