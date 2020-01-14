using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NachoTacos.FeedEngine.Domain
{
    public class FeedItem : Updateable
    {
        [Required]
        public Guid FeedSourceId { get; set; }
        [Required]
        public string FeedItemId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string BaseUri { get; set; }
        public string Content { get; set; }
        public string Copyright { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime LastUpdatedTime { get; set; }

        public ICollection<FeedItemAuthor> Authors { get; set; }
        public ICollection<FeedItemContributor> Contributors { get; set; }
        public ICollection<FeedItemLink> Links { get; set; }
        public ICollection<FeedItemCategory> Categories { get; set; }
    }
}
