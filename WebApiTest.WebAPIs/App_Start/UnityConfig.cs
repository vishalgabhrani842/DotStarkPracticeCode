using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApiTest.Data;
using WebApiTest.Services;

namespace WebApiTest.WebAPIs
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductRepository, ProductRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}