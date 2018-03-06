using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Serilog;
using WooliesxAssignment.Enum;
using WooliesxAssignment.Models;
using WooliesxAssignment.Services;

namespace WooliesxAssignment.Controllers
{
    [RoutePrefix("api/answers")]
    public class SortingShopperHistoryController : BaseController
    {
        private readonly ILogger _logger;
        private readonly ISortData _shopperHistoryData;

        public SortingShopperHistoryController(ISortData shopperHistoryData, ILogger logger)
        {
            _logger = logger;
            _shopperHistoryData = shopperHistoryData;
        }

        [HttpGet]
        [Route("sort")]
        public async Task<IHttpActionResult> GetShopperHistory(Sort sortOption)
        {

            return Ok(await _shopperHistoryData.SortDataAsync(sortOption));
        }
    }
}