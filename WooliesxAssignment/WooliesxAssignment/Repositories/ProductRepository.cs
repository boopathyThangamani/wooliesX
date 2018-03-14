using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using Serilog;
using WooliesxAssignment.Extensions;
using WooliesxAssignment.Helpers;
using WooliesxAssignment.Models;

namespace WooliesxAssignment.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger _logger;
        private readonly IHttpClientDecorator _client;
        private readonly IReadConfig _readConfig;
        private readonly IDeserializer _deserializer;
        public ProductRepository(IHttpClientDecorator httpClient, ILogger logger, IReadConfig readConfig, IDeserializer deserializer)
        {
            _client = httpClient;
            _logger = logger;
            _readConfig = readConfig;
            _deserializer = deserializer;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            Uri endpointUri = new Uri(_readConfig.ReadBaseUrl()+ _readConfig.ReadProduct());
            endpointUri = endpointUri.AddQuery("Token", _readConfig.UserId());
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, endpointUri);
            _logger.Information("Sending request to {uri}", endpointUri);
            var response = await _client.SendAsync(requestMessage);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.Error("Product repository exception");
                throw new HttpResponseException(response);

            }
            var contents = await response.Content.ReadAsStringAsync();
            return _deserializer.Deserialize<List<Product>>(contents);
        }
    }
}