using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
    public class TrolleyCalculatorRepository : ITrolleyCalculatorRepository
    {
        private readonly ILogger _logger;
        private readonly IHttpClientDecorator _client;
        private readonly IReadConfig _readConfig;
        private readonly ISerializer _serializer;

        public TrolleyCalculatorRepository(IHttpClientDecorator httpClient, ILogger logger, IReadConfig readConfig, ISerializer serializer)
        {
            _client = httpClient;
            _logger = logger;
            _readConfig = readConfig;
            _serializer = serializer;
        }
        public async Task<double> TrolleyCalculator(TrolleyItems items)
        {
            Uri endpointUri = new Uri(_readConfig.ReadBaseUrl() + _readConfig.ReadTrollyCaclulator());
            endpointUri = endpointUri.AddQuery("Token", _readConfig.UserId());
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, endpointUri)
            {
                Content = new StringContent(_serializer.Serialise(items), Encoding.UTF8, "application/json")
            };
            _logger.Information("Sending request to {uri}", endpointUri);
            var response = await _client.SendAsync(requestMessage);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.Error("Error while sending request to {uri}",endpointUri);
                throw new HttpResponseException(response);
            }
            var contents = await response.Content.ReadAsStringAsync();
            double total;
            double.TryParse(contents, out total);
            return total;
        }
    }
}