using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using AutofacSerilogIntegration;
using WooliesxAssignment.Helpers;
using WooliesxAssignment.Repositories;
using WooliesxAssignment.Services;

namespace WooliesxAssignment
{
    public static class RegisterComponents
    {
        public static ContainerBuilder Register()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterLogger();
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterType<UserDetails>().As<IUserDetails>().InstancePerRequest();
            containerBuilder.RegisterType<ReadConfig>().As<IReadConfig>().InstancePerRequest();
            containerBuilder.RegisterType<ShopperHistoryRepository>().As<IShopperHistoryRepository>()
                .InstancePerRequest();
            containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerRequest();
            containerBuilder.RegisterType<SortData>().As<ISortData>().InstancePerRequest();
            //containerBuilder.Register(httpClient => new HttpClient()).As<HttpClient>();
            containerBuilder.RegisterType<HttpClientDecorator>().As<IHttpClientDecorator>().InstancePerRequest();
            containerBuilder.RegisterType<TrolleyCalculator>().As<ITrolleyCalculator>().InstancePerRequest();
            containerBuilder.RegisterType<TrolleyCalculatorRepository>().As<ITrolleyCalculatorRepository>().InstancePerRequest();
            return containerBuilder;
        }
    }
}