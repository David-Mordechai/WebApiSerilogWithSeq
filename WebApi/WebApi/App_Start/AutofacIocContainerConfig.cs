using Autofac.Integration.WebApi;
using Autofac;
using System.Reflection;
using System.Web.Http;
using Tools.Logger;

namespace WebApi
{
    public static class AutofacIocContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // register application types
            builder.RegisterApplicationTypes();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterApplicationTypes(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(LoggerAdapter<>))
                .InstancePerDependency()
                .As(typeof(ILoggerAdapter<>));
        }
    }
}
