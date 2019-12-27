using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using NachoTacos.FeedEngine.Data;
using NachoTacos.FeedEngine.Domain;
using System.Xml;
using Microsoft.Extensions.Logging;

namespace NachoTacos.FeedEngine.Api.Services
{
    public class SaveFeedsToData
    {
        private readonly IFeedEngineContext _feedEngineContext;
        private readonly ILogger<SaveFeedsToData> _logger;

        public SaveFeedsToData(IFeedEngineContext feedEngineContext, ILogger<SaveFeedsToData> logger)
        {
            _feedEngineContext = feedEngineContext;
            _logger = logger;
        }

        public async Task SaveFeeds(Guid id)
        {
            try
            {
                FeedSource feedSource = _feedEngineContext.FeedSources.FirstOrDefault(x => x.FeedSourceId == id);
                if (feedSource == null)
                {
                    _logger.LogWarning("FeedSourceId {0} not found, job ended without activity", id);
                    return;
                }

                SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(feedSource.FeedUrl));
                List<FeedItem> feedItems = new List<FeedItem>();

                foreach (SyndicationItem item in feed.Items)
                {
                    feedItems.Add(GetFeedItem(id, item));
                }
                _logger.LogInformation("Captured from {0}: Feed items count={1}", feedSource.FeedUrl, feedItems.Count);

                feedItems.ForEach(item => _feedEngineContext.FeedItems.Add(item));
                await _feedEngineContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }



        #region "Helper Functions"
        private FeedItem GetFeedItem(Guid feedSourceId, SyndicationItem item)
        {
            return new FeedItem
            {
                FeedSourceId = feedSourceId,
                FeedItemId = item.Id,
                Title = item.Title.Text,
                Summary = item.Summary?.Text ?? String.Empty,
                BaseUri = item.BaseUri?.ToString(),
                Content = item.Content?.ToString(),
                Copyright = item.Copyright?.ToString(),
                PublishDate = item.PublishDate.UtcDateTime,
                LastUpdatedTime = item.LastUpdatedTime.UtcDateTime,
                Contributors = GetContributors(item.Contributors?.ToList()),
                Authors = GetAuthors(item.Authors?.ToList()),
                Links = GetLinks(item.Links?.ToList()),
                Categories = GetCategories(item.Categories?.ToList())
            };
        }

        private List<FeedItemCategory> GetCategories(List<SyndicationCategory> categories)
        {
            List<FeedItemCategory> feedItemCategories = new List<FeedItemCategory>();
            foreach (SyndicationCategory category in categories)
            {
                feedItemCategories.Add(new FeedItemCategory
                {
                    Label = category.Label,
                    Name = category.Name,
                    Scheme = category.Scheme
                });
            }
            return feedItemCategories;
        }

        private List<FeedItemLink> GetLinks(List<SyndicationLink> links)
        {
            List<FeedItemLink> feedItemLinks = new List<FeedItemLink>();
            foreach (SyndicationLink link in links)
            {
                feedItemLinks.Add(new FeedItemLink
                {
                    MediaType = link.MediaType,
                    RelationshipType = link.RelationshipType,
                    Title = link.Title,
                    Url = link.Uri.ToString()
                });
            }
            return feedItemLinks;
        }
        private List<FeedItemContributor> GetContributors(List<SyndicationPerson> contributors)
        {
            List<FeedItemContributor> feedItemContributors = new List<FeedItemContributor>();
            foreach (SyndicationPerson person in contributors)
            {
                feedItemContributors.Add(new FeedItemContributor
                {
                    Name = person.Name,
                    Email = person.Email,
                    Uri = person.Uri
                });
            }

            return feedItemContributors;
        }

        private List<FeedItemAuthor> GetAuthors(List<SyndicationPerson> authors)
        {
            List<FeedItemAuthor> feedItemAuthors = new List<FeedItemAuthor>();
            foreach (SyndicationPerson person in authors)
            {
                feedItemAuthors.Add(new FeedItemAuthor
                {
                    Name = person.Name,
                    Email = person.Email,
                    Uri = person.Uri
                });
            }

            return feedItemAuthors;
        }
        #endregion
    }
}
