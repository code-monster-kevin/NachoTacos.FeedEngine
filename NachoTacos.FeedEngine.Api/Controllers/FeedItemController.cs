using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NachoTacos.FeedEngine.Api.Services;
using NachoTacos.FeedEngine.Data;
using NachoTacos.FeedEngine.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NachoTacos.FeedEngine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedItemController : ControllerBase
    {
        #region "Constructors"
        private IFeedEngineContext _feedEngineContext;
        private readonly ILogger<FeedItemController> _logger;

        public FeedItemController(IFeedEngineContext feedEngineContext, ILogger<FeedItemController> logger)
        {
            _feedEngineContext = feedEngineContext;
            _logger = logger;
        }
        #endregion

        #region "Controllers"
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFeedsBySource(Guid id)
        {
            List<FeedItem> feedItems = _feedEngineContext.FeedItems.Where(x => x.FeedSourceId == id).ToList();
            return Ok(feedItems);
        }

        [HttpGet]
        [Route("extract/{id}")]
        public IActionResult ExtractFeedFromSource(Guid id)
        {
            BackgroundJob.Schedule<SaveFeedsToData>(x => x.SaveFeeds(id), TimeSpan.FromSeconds(1));

            _logger.LogInformation("New [SaveFeedsToData] background job started {0}", id);
            return Ok();
        }

        #endregion
    }
}