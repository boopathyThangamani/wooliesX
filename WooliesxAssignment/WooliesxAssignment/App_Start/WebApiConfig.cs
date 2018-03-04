using Autofac.Integration.WebApi;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using WooliesxAssignment.App_Start;

namespace WooliesxAssignment
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            SerilogRegitration.RegisterSerilog();
            var continer = RegisterComponents.Register();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(continer.Build());
        }
    }
}
