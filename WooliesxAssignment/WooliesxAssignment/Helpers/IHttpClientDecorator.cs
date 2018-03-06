using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WooliesxAssignment.Helpers
{
    public interface IHttpClientDecorator
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
