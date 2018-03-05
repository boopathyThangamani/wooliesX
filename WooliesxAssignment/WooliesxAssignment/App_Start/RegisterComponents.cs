using Autofac;
using Autofac.Integration.WebApi;
using AutofacSerilogIntegration;
using System.Net.Http;
using System.Reflection;
using WooliesxAssignment.Controllers;
using WooliesxAssignment.Filters;
using WooliesxAssignment.Helpers;
using WooliesxAssignment.Repositories;
using WooliesxAssignment.Services;

namespace WooliesxAssignment.App_Start
{
    public static class RegisterComponents
    {
        public static ContainerBuilder Register()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterLogger();
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterType<UserDetails>().As<IUserDetails>();
            containerBuilder.RegisterType<ReadConfig>().As<IReadConfig>();
            containerBuilder.RegisterType<ShopperHistoryRepository>().As<IShopperHistoryRepository>();
            containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>();
            containerBuilder.RegisterType<SortData>().As<ISortData>();
            containerBuilder.Register(httpClient => new HttpClient()).As<HttpClient>();
            return containerBuilder;
        }
    }
}