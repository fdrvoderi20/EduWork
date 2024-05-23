using EduWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduWork
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_WorkDay> Users_WorkDays { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<WorkOnProject> WorkOnProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkOnProject>()
                .HasOne(w => w.Project)
                .WithMany(p => p.WorkOnProjects)
                .HasForeignKey(w => w.ProjectId);

            modelBuilder.Entity<Overtime>()
                .HasOne(o => o.User)
                .WithMany(u => u.Overtimes)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<User_WorkDay>()
                .HasOne(uw => uw.User)
                .WithMany(u => u.User_WorkDays)
                .HasForeignKey(uw => uw.UserId);

            modelBuilder.Entity<User_WorkDay>()
                .HasOne(uw => uw.WorkDay)
                .WithMany(w => w.User_WorkDays)
                .HasForeignKey(uw => uw.WorkDayId);
        }
    }
}
