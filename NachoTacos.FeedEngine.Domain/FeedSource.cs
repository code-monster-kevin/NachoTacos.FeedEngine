using System;
using System.ComponentModel.DataAnnotations;

namespace NachoTacos.FeedEngine.Domain
{
    public class FeedSource : Updateable
    {
        [Key]
        public string FeedUrl { get; set; }
        [Required]
        public FeedType FeedType { get; set; }
    }
}
