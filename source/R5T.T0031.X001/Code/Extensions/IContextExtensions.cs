using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0031;


namespace System
{
    public static class IContextExtensions
    {
        public static TService GetRequiredService<TService>(this IContext context)
        {
            var service = context.ServiceProvider.GetRequiredService<TService>();
            return service;
        }

        public static void Run<TContext, TService>(this TContext context,
            Action<TService> serviceAction)
            where TContext : IContext
        {
            var service = context.GetRequiredService<TService>();

            serviceAction(service);
        }

        public static Task Run<TContext, TService>(this TContext context,
            Func<TService, Task> serviceAction)
            where TContext : IContext
        {
            var service = context.GetRequiredService<TService>();

            return serviceAction(service);
        }

        public static Task<TOutput> Run<TContext, TService, TOutput>(this TContext context,
            Func<TService, Task<TOutput>> serviceFunction)
            where TContext : IContext
        {
            var service = context.GetRequiredService<TService>();

            return serviceFunction(service);
        }

        public static Task WithService<TService>(this IContext context, Func<TService, Task> action)
        {
            var service = context.GetRequiredService<TService>();

            return action(service);
        }

        public static Task<TOut> WithService<TService, TOut>(this IContext context, Func<TService, Task<TOut>> function)
        {
            var service = context.GetRequiredService<TService>();

            return function(service);
        }

        public static void WithServiceSynchronous<TService>(this IContext context, Action<TService> action)
        {
            var service = context.GetRequiredService<TService>();

            action(service);
        }

        public static TOut WithServiceSynchronous<TService, TOut>(this IContext context, Func<TService, TOut> function)
        {
            var service = context.GetRequiredService<TService>();

            return function(service);
        }

        public static Task WithServices<TService1, TService2>(this IContext context, Func<TService1, TService2, Task> action)
        {
            var service1 = context.GetRequiredService<TService1>();
            var servcie2 = context.GetRequiredService<TService2>();

            return action(service1, servcie2);
        }

        public static void WithServicesSynchronous<TService1, TService2>(this IContext context, Action<TService1, TService2> action)
        {
            var service1 = context.GetRequiredService<TService1>();
            var servcie2 = context.GetRequiredService<TService2>();

            action(service1, servcie2);
        }

        //public static TService GetRequiredService<TContext, TService>(this TContext context)
        //    where TContext : IContext
        //{
        //    var service = context.ServiceProvider.GetRequiredService<TService>();
        //    return service;
        //}

        //public static Task WithService<TContext, TService>(this TContext context, Func<TService, Task> action)
        //    where TContext : IContext
        //{
        //    var service = context.GetRequiredService<TContext, TService>();

        //    return action(service);
        //}

        //public static Task<TOut> WithService<TContext, TService, TOut>(this TContext context, Func<TService, Task<TOut>> function)
        //    where TContext : IContext
        //{
        //    var service = context.GetRequiredService<TContext, TService>();

        //    return function(service);
        //}

        //public static TOut WithServiceSynchronous<TContext, TService, TOut>(this TContext context, Func<TService, TOut> function)
        //    where TContext : IContext
        //{
        //    var service = context.GetRequiredService<TContext, TService>();

        //    return function(service);
        //}
    }
}
