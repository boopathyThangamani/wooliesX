﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
        private readonly HttpClient _client;
        private readonly IReadConfig _readConfig;
        public ProductRepository(HttpClient httpClient, ILogger logger, IReadConfig readConfig)
        {
            _client = httpClient;
            _logger = logger;
            _readConfig = readConfig;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            Uri endpointUri = new Uri(_readConfig.ReadBaseUrl());
            endpointUri = endpointUri.AddQuery("Token", _readConfig.UserId());
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, endpointUri);
            _logger.Information("Sending request to {uri}", endpointUri);
            //var response = await _client.SendAsync(requestMessage);
            //if (response.StatusCode != HttpStatusCode.OK)
            //{
            //    //_logger.Error("");
            //}
            //var contents = await response.Content.ReadAsStringAsync();
            using (StreamReader file = File.OpenText(@"Products.json"))
            {
                var deserialised = new JavaScriptSerializer();
                //return deserialised.Deserialize<List<ShopperHistory>>(contents);
                return deserialised.Deserialize<List<Product>>(file.ReadToEnd());
            }
        }
    }
}