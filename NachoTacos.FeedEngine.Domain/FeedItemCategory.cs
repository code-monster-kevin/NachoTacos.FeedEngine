using System;

namespace NachoTacos.FeedEngine.Domain
{
    public class FeedItemCategory
    {
        public Guid FeedItemCategoryId { get; set; }
        public string FeedItemId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Scheme { get; set; }
    }
}
