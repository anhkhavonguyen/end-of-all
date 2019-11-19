using Microsoft.Extensions.DependencyInjection;
using System;

namespace KVSolution.PIM.Infrastructure.Services.Extension
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTransientLazy<ITService,TService>(this IServiceCollection services)
            where ITService : class
            where TService : class, ITService
        {
            return services.AddTransient<ITService, TService>()
                           .AddTransient(x => new Lazy<ITService>(() => x.GetRequiredService<ITService>()));
        }

        public static IServiceCollection AddTransientLazy<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            return services.AddTransient(implementationFactory)
                           .AddTransient(x => new Lazy<TService>(() => x.GetRequiredService<TService>()));
        }

        public static IServiceCollection AddTransientLazy<TService>(this IServiceCollection services)
            where TService : class
        {
            return services
                .AddTransient<TService>()
                .AddTransient(x => new Lazy<TService>(() => x.GetRequiredService<TService>()));
        }
    }
}
