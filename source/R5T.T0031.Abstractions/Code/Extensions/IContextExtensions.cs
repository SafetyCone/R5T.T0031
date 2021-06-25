using System;
using System.Threading.Tasks;


namespace R5T.T0031
{
    public static class IContextExtensions
    {
        public static TContext GetContext<TContext, TParentContext>(this TParentContext parentContext,
            ContextConstructor<TContext> contextConstructor)
            where TContext : IContext
            where TParentContext : IContext
        {
            var context = contextConstructor(parentContext.ServiceProvider);
            return context;
        }

        public static TSubContext GetSubContext<TSubContext, TContext>(this TContext context,
            ContextConstructor<TSubContext> subContextConstructor,
            ContextInitializerSynchronous<TSubContext, TContext> subContextInitializer)
            where TContext : IContext
            where TSubContext : IContext
        {
            TSubContext subContext = subContextConstructor(context.ServiceProvider);

            subContextInitializer(subContext, context);

            return subContext;
        }

        public static async Task<TSubContext> GetSubContext<TSubContext, TContext>(this TContext context,
            ContextConstructor<TSubContext> subContextConstructor,
            ContextInitializer<TSubContext, TContext> subContextInitializer)
            where TContext : IContext
            where TSubContext : IContext
        {
            TSubContext subContext = subContextConstructor(context.ServiceProvider);

            await subContextInitializer(subContext, context);

            return subContext;
        }

        public static async Task<TContext> InContext<TContext>(this TContext context,
            Func<TContext, Task> action)
            where TContext : IContext
        {
            await action(context);

            return context;
        }

        public static async Task<TContext> InContext<TContext>(this Task<TContext> gettingContext,
            Func<TContext, Task> action)
            where TContext : IContext
        {
            var context = await gettingContext;

            return await context.InContext(action);
        }

        public static async Task<TParentContext> InContext<TContext, TParentContext>(this TParentContext parentContext,
            ContextConstructorInitializer<TContext, TParentContext> contextConstructorInitializer,
            Func<TContext, Task> action)
            where TContext : IContext
            where TParentContext : IContext
        {
            var context = await contextConstructorInitializer(parentContext);

            await action(context);

            return parentContext;
        }

        public static async Task<TParentContext> InContext<TContext, TParentContext>(this Task<TParentContext> gettingParentContext,
            ContextConstructorInitializer<TContext, TParentContext> contextConstructorInitializer,
            Func<TContext, Task> action)
            where TContext : IContext
            where TParentContext : IContext
        {
            var parentContext = await gettingParentContext;

            return await parentContext.InContext(
                contextConstructorInitializer,
                action);
        }

        public static Task<TOut> FromContext<TContext, TOut>(this TContext context,
            Func<TContext, Task<TOut>> function)
            where TContext : IContext
        {
            return function(context);
        }

        public static async Task<TOut> FromContext<TContext, TOut>(this Task<TContext> gettingContext,
            Func<TContext, Task<TOut>> function)
            where TContext : IContext
        {
            var context = await gettingContext;

            return await context.FromContext(function);
        }

        public static async Task<TOut> FromContext<TOut, TContext, TParentContext>(this TParentContext parentContext,
            ContextConstructorInitializer<TContext, TParentContext> contextConstructorInitializer,
            Func<TContext, Task<TOut>> function)
            where TContext : IContext
            where TParentContext : IContext
        {
            var context = await contextConstructorInitializer(parentContext);

            var output = await function(context);
            return output;  
        }

        public static async Task<TOut> FromContext<TOut, TContext, TParentContext>(this Task<TParentContext> gettingParentContext,
            ContextConstructorInitializer<TContext, TParentContext> contextConstructorInitializer,
            Func<TContext, Task<TOut>> function)
            where TContext : IContext
            where TParentContext : IContext
        {
            var parentContext = await gettingParentContext;

            return await parentContext.FromContext(
                contextConstructorInitializer,
                function);
        }
    }
}
