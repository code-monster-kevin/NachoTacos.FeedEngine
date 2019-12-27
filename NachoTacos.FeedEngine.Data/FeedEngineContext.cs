using Microsoft.EntityFrameworkCore;
using NachoTacos.FeedEngine.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NachoTacos.FeedEngine.Data
{
    public class FeedEngineContext : DbContext
    {
        public FeedEngineContext(DbContextOptions<FeedEngineContext> options) : base(options)
        {

        }

        public DbSet<FeedSource> FeedSources { get; set; }
        public DbSet<FeedType> FeedTypes { get; set; }

        #region "Seed Data"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeedType>()
                .HasData(
                    new FeedType { Code = "RSS091", Description = "RSS 0.91" },
                    new FeedType { Code = "RSS092", Description = "RSS 0.92" },
                    new FeedType { Code = "RSS100", Description = "RSS 1.0" },
                    new FeedType { Code = "RSS200", Description="RSS 2.0" },
                    new FeedType { Code = "ATOM", Description = "ATOM" }
                );

        }
        #endregion

        #region "Save UTC DateTime To IUpdatable entities"
        public override int SaveChanges()
        {
            UpdateEntityDates();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateEntityDates();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateEntityDates()
        {
            var now = DateTime.UtcNow;
            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IUpdateable entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.UpdatedDate = now;
                            break;

                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            entity.UpdatedDate = now;
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
