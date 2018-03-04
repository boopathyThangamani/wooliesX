using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using WooliesxAssignment.Extensions;
using WooliesxAssignment.Helpers;
using WooliesxAssignment.Models;

namespace WooliesxAssignment.Services
{
    public class ShopperHistoryRepository : IShopperHistoryRepository
    {
        private readonly ILogger _logger;
        private readonly HttpClient _client;
        private readonly IReadConfig _readConfig;
        public ShopperHistoryRepository(HttpClient httpClient, ILogger logger, IReadConfig readConfig)
        {
            _client = httpClient;
            _logger = logger;
            _readConfig = readConfig;
        }

        public async Task<List<ShopperHistory>> GetShopperHistory()

        {
            Uri endpointUri = new Uri(_readConfig.ReadBaseUrl());
            Uri finalUri = endpointUri.AddQuery("Token", _readConfig.UserId());
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, finalUri);
            _logger.Information("Sending request to {uri}", endpointUri);
                var response = await _client.SendAsync(requestMessage);
            if (response.StatusCode != HttpStatusCode.OK)
            {
            }
            var contents = await response.Content.ReadAsStringAsync();
            var deserialised = new JavaScriptSerializer();
            return deserialised.Deserialize<List<ShopperHistory>>(contents);
        }
    }
}