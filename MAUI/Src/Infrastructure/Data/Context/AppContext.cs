using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.Context
{
    public partial class AppContext : DbContext
    {
        public string DbPath { get; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            DbPath = GetDatabasePath();
        }

        #region Entities

        public DbSet<User> Users { get; set; }

        #endregion



        #region Configuration Context
        private static string GetDatabasePath()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(folder, "db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
