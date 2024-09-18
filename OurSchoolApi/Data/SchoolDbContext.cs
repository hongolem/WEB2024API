using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OurSchoolApi.Models;

namespace OurSchoolApi.Data
{
    public class SchoolDbContext : IdentityDbContext<IdentityUser>
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options): base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
