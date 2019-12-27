using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
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
    public class FeedSourceController : ControllerBase
    {
        #region "Constructors"
        private IFeedEngineContext _feedEngineContext;
        private readonly ILogger<FeedSourceController> _logger;

        public FeedSourceController(IFeedEngineContext feedEngineContext, ILogger<FeedSourceController> logger)
        {
            _feedEngineContext = feedEngineContext;
            _logger = logger;
        }

        #endregion

        #region "Controllers"
        [HttpGet]
        public IActionResult GetFeedSources()
        {
            try
            {
                List<FeedSource> feedSources = _feedEngineContext.FeedSources.ToList();
                if (feedSources.Count == 0)
                {
                    return NotFound();
                }

                return Ok(feedSources);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedSources(string feedUrl, string feedTypeCode)
        {
            try
            {
                FeedType feedType = GetFeedType(feedTypeCode);
                if (feedType == null)
                {
                    return NotFound(feedTypeCode);
                }

                FeedSource feedSource = GetFeedSource(feedUrl);
                if (feedSource == null)
                {
                    feedSource = CreateFeedSource(feedUrl, feedType);
                    _feedEngineContext.FeedSources.Add(feedSource);
                    await _feedEngineContext.SaveChangesAsync();
                }

                return Ok(feedSource);
            }
            catch(SqlException sqlex)
            {
                return sqlex.ErrorCode switch
                {
                    2627 => Problem("Duplicate key"),
                    208 => Problem("Bad Object"),
                    _ => Problem(sqlex.Message),
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeedSources(string feedUrl)
        {
            try
            {
                FeedSource feedSource = GetFeedSource(feedUrl);
                if (feedSource == null)
                {
                    return NotFound(feedUrl);
                }

                _feedEngineContext.FeedSources.Remove(feedSource);
                await _feedEngineContext.SaveChangesAsync();

                return Ok(feedSource);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }
        #endregion

        #region "Helper Functions"
        private FeedType GetFeedType(string code)
        {
            return _feedEngineContext.FeedTypes.FirstOrDefault(x => x.Code == code);
        }

        private FeedSource CreateFeedSource(string feedUrl, FeedType feedType)
        {
            return new FeedSource
            {
                FeedSourceId = Guid.NewGuid(),
                FeedUrl = feedUrl,
                FeedType = feedType
            };
        }

        private FeedSource GetFeedSource(string feedUrl)
        {
            return _feedEngineContext.FeedSources.FirstOrDefault(x => x.FeedUrl == feedUrl);
        }
        #endregion
    }
}