using System;
using System.Collections.Generic;
using System.Text;

namespace NachoTacos.FeedEngine.Domain
{
    public interface IUpdateable
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
