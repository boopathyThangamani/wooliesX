using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WooliesxAssignment.Controllers;
using WooliesxAssignment.Models;
using WooliesxAssignment.Services;

namespace WooliesxAssignment.Controllers
{
    [RoutePrefix("api/answers")]
    public class SortingShopperHistoryController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IShopperHistoryData _shopperHistoryData;
        public SortingShopperHistoryController(IShopperHistoryData shopperHistoryData, ILogger logger)
        {
            _logger = logger;
            _shopperHistoryData = shopperHistoryData;
        }

        [HttpGet]
        [Route("sort")]
        public async Task<List<ShopperHistory>> GetShopperHistory()
        {
            return await _shopperHistoryData.GetShopperHistory();
        }
    }
}
