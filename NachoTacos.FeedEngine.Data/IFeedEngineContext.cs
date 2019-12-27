using Microsoft.EntityFrameworkCore;
using NachoTacos.FeedEngine.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace NachoTacos.FeedEngine.Data
{
    public interface IFeedEngineContext
    {
        DbSet<FeedItemAuthor> FeedItemAuthors { get; set; }
        DbSet<FeedItemCategory> FeedItemCategories { get; set; }
        DbSet<FeedItemContributor> FeedItemContributors { get; set; }
        DbSet<FeedItemLink> FeedItemLinks { get; set; }
        DbSet<FeedItem> FeedItems { get; set; }
        DbSet<FeedSource> FeedSources { get; set; }
        DbSet<FeedType> FeedTypes { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}