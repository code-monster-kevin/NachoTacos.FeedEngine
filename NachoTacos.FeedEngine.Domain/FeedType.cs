using System.ComponentModel.DataAnnotations;

namespace NachoTacos.FeedEngine.Domain
{
    public class FeedType
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
