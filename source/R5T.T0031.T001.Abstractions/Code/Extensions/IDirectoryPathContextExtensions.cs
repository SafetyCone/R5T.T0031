using System;
using System.Threading.Tasks;


namespace R5T.T0031.T001
{
    public static class IDirectoryPathContextExtensions
    {
        public static Task<TDirectoryPathContext> GetDirectoryPath<TDirectoryPathContext, TContext>(this TContext context,
            string directoryPath,
            Func<TContext, string, Task<TDirectoryPathContext>> directoryPathContextConstructor)
            where TContext : IContext
            where TDirectoryPathContext : IDirectoryPathContext
        {
            return directoryPathContextConstructor(context, directoryPath);
        }

        public static async Task<TDirectoryPathContext> GetDirectoryPath<TDirectoryPathContext, TContext>(this Task<TContext> gettingContext,
            string directoryPath,
            Func<TContext, string, Task<TDirectoryPathContext>> directoryPathContextConstructor)
            where TContext : IContext
            where TDirectoryPathContext : IDirectoryPathContext
        {
            var context = await gettingContext;

            var directoryPathContext = await context.GetDirectoryPath(directoryPath,
                directoryPathContextConstructor);

            return directoryPathContext;
        }

        public static async Task<TContext> InDirectory<TDirectoryPathContext, TContext>(this TContext context,
            string directoryPath,
            Func<TContext, string, Task<TDirectoryPathContext>> directoryPathContextConstructor,
            Func<TDirectoryPathContext, Task> action)
            where TContext : IContext
            where TDirectoryPathContext : IDirectoryPathContext
        {
            var directoryPathContext = await context.GetDirectoryPath(directoryPath,
                directoryPathContextConstructor);

            await action(directoryPathContext);

            return context;
        }
    }
}
