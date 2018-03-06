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

        public TrolleyCalculatorRepository(IHttpClientDecorator httpClient, ILogger logger, IReadConfig readConfig)
        {
            _client = httpClient;
            _logger = logger;
            _readConfig = readConfig;
        }
        public async Task<double> TrolleyCalculator(TrolleyItems items)
        {
            Uri endpointUri = new Uri(_readConfig.ReadBaseUrl() + _readConfig.ReadTrollyCaclulator());
            endpointUri = endpointUri.AddQuery("Token", _readConfig.UserId());
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, endpointUri)
            {
                Content = new StringContent(SerialiseTrolleyItems(items), Encoding.UTF8, "application/json")
            };
            _logger.Information("Sending request to {uri}", endpointUri);
            var response = await _client.SendAsync(requestMessage);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.Error("");
                throw new HttpResponseException(response);
            }
            var contents = await response.Content.ReadAsStringAsync();
            double total;
            double.TryParse(contents, out total);
            return total;
        }

        private string SerialiseTrolleyItems(TrolleyItems items)
        {
            var serialize = new JavaScriptSerializer();
            return serialize.Serialize(items);
        }
    }
}