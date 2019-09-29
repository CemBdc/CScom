using CScom.Core.Base;
using CScom.Data.Context;
using CScom.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace CScom.Api.Helper.Extensions
{
    public static class ConfigureExtensions
    {
        public static void ConfigureServiceWrapper(this IServiceCollection services)
        {
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMongoContext, MongoContext>();
        }
    }
}
