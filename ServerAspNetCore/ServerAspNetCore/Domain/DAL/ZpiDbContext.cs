using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ServerAspNetCore.Domain.Entities;

namespace ServerAspNetCore.Domain.DAL
{
    public class ZpiDbContext : DbContext
    {
        public ZpiDbContext(DbContextOptions<ZpiDbContext> options)
            : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
          base.OnModelCreating(builder);

          // Define composite key.
          builder.Entity<CourseTag>()
          .HasKey(ct => new { ct.IdCourse, ct.IdTag });

          builder.Entity<Access>()
            .HasKey(a => new { a.IdUser, a.IdCourse });
        
          builder.Entity<Raiting>()
            .HasKey(r => new { r.IdUser, r.IdCourse });
    }

        public DbSet<Access> Accesses { get; set; }
        public DbSet<AccessCode> AccessCodes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTag> CourseTags { get; set; }
        public DbSet<Raiting> Ratings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }

    }
}
