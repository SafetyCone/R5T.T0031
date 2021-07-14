using System;
using System.Threading.Tasks;

using R5T.T0031;
using R5T.T0031.T001;


namespace System
{
    public static class IContextExtensions
    {
        public static Task<TContext> InDirectoryPathContext<TContext>(this TContext context,
            string directoryPath,
            Func<DirectoryPathContext, Task> directoryPathContextAction = default)
            where TContext : IContext
        {
            return context.InContext(
                DirectoryPathContext.GetConstructorInitializer<TContext>(directoryPath),
                directoryPathContextAction);
        }

        public static Task<TContext> InDirectoryPathContext<TContext>(this Task<TContext> gettingContext,
            string directoryPath,
            Func<DirectoryPathContext, Task> directoryPathContextAction = default)
            where TContext : IContext
        {
            return gettingContext.InContext(
                DirectoryPathContext.GetConstructorInitializer<TContext>(directoryPath),
                directoryPathContextAction);
        }
    }
}
