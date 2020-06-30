using Keezag.Common.Data;
using Keezag.HHSurge.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Keezag.Common.Log;

namespace Keezag.HHSurge.Repository
{
    public class HHSurgeDbContext : DbContext, IUnitOfWork
    {
        public HHSurgeDbContext(DbContextOptions<HHSurgeDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }

        public async Task<bool> Commit()
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Timestamp") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("Timestamp").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("Timestamp").IsModified = false;
                    }
                }

                return await base.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                Logger.Logar.Error(e, $"Commit");
                return false;
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HHSurgeDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
