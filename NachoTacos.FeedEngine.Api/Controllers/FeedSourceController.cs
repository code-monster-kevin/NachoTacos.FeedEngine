using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        private FeedEngineContext _feedEngineContext;

        public FeedSourceController(FeedEngineContext feedEngineContext)
        {
            _feedEngineContext = feedEngineContext;
        }

        #endregion

        #region "Controllers"
        [HttpGet]
        [Route("feedsource")]
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
                return Problem(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("feedsource")]
        public async Task<IActionResult> AddFeedSources(string feedUrl, string feedTypeCode)
        {
            try
            {
                FeedType feedType = GetFeedType(feedTypeCode);
                if (feedType == null)
                {
                    return NotFound(feedTypeCode);
                }

                FeedSource feedSource = CreateFeedSource(feedUrl, feedType);
                _feedEngineContext.FeedSources.Add(feedSource);
                await _feedEngineContext.SaveChangesAsync();

                return Ok(feedSource);
            }
            catch(SqlException sqlex)
            {
                switch(sqlex.ErrorCode)
                {
                    case 2627:
                        return Problem("Duplicate key");
                    case 208:
                        return Problem("Bad Object");
                    default:
                        return Problem(sqlex.Message);
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("feedsource")]
        public async Task<IActionResult> DeleteFeedSources(string feedUrl, string feedTypeCode)
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