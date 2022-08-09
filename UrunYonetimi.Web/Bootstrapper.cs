using Autofac;
using Autofac.Integration.Mvc;
using UrunYonetimi.Core.Repository;
using UrunYonetimi.Core.Infrastructure;
using System.Web.Mvc;


namespace UrunYonetimi.Web
{
    public static class Bootstrapper
    {
        public static void RunConfig()
        {
            BuilAutofac();
        }

        private static void BuilAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductFeatureRepository>().As<IProductFeatureRepository>();
            builder.RegisterType<ProductImageRepository>().As<IProductImageRepository>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}