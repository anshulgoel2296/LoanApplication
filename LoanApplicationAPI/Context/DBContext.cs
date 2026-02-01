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
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<LoanType>()
                .HasIndex(u => u.LoanId)
                .IsUnique();
            modelBuilder.Entity<LoanApplication>()
                .HasIndex(u => u.Id)
                .IsUnique();
            modelBuilder.Entity<ApplicationStatus>()
                .HasIndex(u => u.StatusId)
                .IsUnique();
        }

        public DbSet<User> UsersList => Set<User>();
        public DbSet<LoanType> LoanTypeList => Set<LoanType>();
        public DbSet<LoanApplication> LoanApplicationList => Set<LoanApplication>();
        public DbSet<ApplicationStatus> ApplicationStatusList => Set<ApplicationStatus>();
    }
}
