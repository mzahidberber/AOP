﻿using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace AOP
{
    public static class ServiceExtensions
    {
        public static void AddProxyScoped<TInterface, TImplementation>(this IServiceCollection services)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            services.AddSingleton<ProxyGenerator>();
            services.AddScoped<TImplementation>();
            services.AddScoped(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<ProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                //var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
                var proxyOptions = new ProxyGenerationOptions
                {
                    Selector = new AspectSelector()
                };
                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, proxyOptions);
            });
        }

        public static void AddProxySingleton<TInterface, TImplementation>(this IServiceCollection services)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            services.AddSingleton<ProxyGenerator>();
            services.AddSingleton<TImplementation>();
            services.AddSingleton(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<ProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                //var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
                var proxyOptions = new ProxyGenerationOptions
                {
                    Selector = new AspectSelector()
                };
                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, proxyOptions);
            });
        }

        public static void AddProxyTransient<TInterface, TImplementation>(this IServiceCollection services)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            services.AddSingleton<ProxyGenerator>();
            services.AddTransient<TImplementation>();
            services.AddTransient(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<ProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                //var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
                var proxyOptions = new ProxyGenerationOptions
                {
                    Selector = new AspectSelector()
                };
                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, proxyOptions);
            });
        }
    }
}
