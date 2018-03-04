using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WooliesxAssignment.Models;

namespace WooliesxAssignment.Services
{
    public class ShopperHistoryData : IShopperHistoryData
    {
        private readonly ILogger _logger;
        private readonly IShopperHistoryRepository _shopperHistoryRepository;
        public ShopperHistoryData( IShopperHistoryRepository shopperHistoryRepository, ILogger logger)
        {
            _logger = logger;
            _shopperHistoryRepository = shopperHistoryRepository;
        }
        public async Task<List<ShopperHistory>> GetShopperHistory()
        {
            return await _shopperHistoryRepository.GetShopperHistory();
        }
    }
}