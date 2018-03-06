using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WooliesxAssignment.Helpers
{
    internal sealed class HttpClientDecorator: IHttpClientDecorator
    {
        private readonly HttpClient _httpClient;

        public HttpClientDecorator()
        {
            _httpClient = new HttpClient();
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
            => _httpClient.SendAsync(request);
    }
}