using System;

namespace NachoTacos.FeedEngine.Domain
{
    public class FeedItemContributor
    {
        public Guid FeedItemContributorId { get; set; }
        public string FeedItemId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
    }
}
