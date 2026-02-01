using LoanApplicationAPI.DBModels;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationAPI.Context
{

    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<LoanType>()
                .HasKey(u => u.LoanId);
            modelBuilder.Entity<LoanApplication>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<ApplicationStatus>()
                .HasKey(u => u.StatusId);
        }

        public DbSet<User> UsersList => Set<User>();
        public DbSet<LoanType> LoanTypeList => Set<LoanType>();
        public DbSet<LoanApplication> LoanApplicationList => Set<LoanApplication>();
        public DbSet<ApplicationStatus> ApplicationStatusList => Set<ApplicationStatus>();
    }
}
