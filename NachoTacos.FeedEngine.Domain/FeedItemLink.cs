using System;

namespace NachoTacos.FeedEngine.Domain
{
    public class FeedItemLink
    {
        public Guid FeedItemLinkId { get; set; }
        public string FeedItemId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string MediaType { get; set; }
        public string RelationshipType { get; set; }
    }
}
