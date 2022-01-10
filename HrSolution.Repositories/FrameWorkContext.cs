using HrSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace HrSolution.Repositories
{
    public class FrameWorkContext:DbContext
    {
        private string _connectionStringName;
        private string _migrationAssemblyName;
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationQueue> NotificationQueues { get; set; }
        public DbSet<User> Users { get; set; }
        
        public FrameWorkContext(string connectionStringName, string migrationAssemblyName)
        {
            _connectionStringName = connectionStringName;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Manager)
                .WithMany(x => x.Superintendent)
                .HasForeignKey(x => x.ManagerId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(_connectionStringName,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}