using System;
using System.Threading.Tasks;

using R5T.Gepidia;
using R5T.Lombardy;


namespace System
{
    using R5T.T0031.T001;


    public static partial class IDirectoryPathContextExtensions
    {
        public static Task<TDirectoryPathContext> CreateDirectory<TDirectoryPathContext>(this TDirectoryPathContext directoryPathContext)
            where TDirectoryPathContext : IDirectoryPathContext
        {
            directoryPathContext.Run<TDirectoryPathContext, IFileSystemOperator>(fileSystemOperator =>
            {
                fileSystemOperator.CreateDirectory(directoryPathContext.DirectoryPath);
            });

            return Task.FromResult(directoryPathContext);
        }

        public static Task<DirectoryPathContext> InSubDirectoryPathContext(this DirectoryPathContext directoryPathContext,
            string subDirectoryRelativePath,
            Func<DirectoryPathContext, Task> subDirectoryPathContextAction)
        {
            var subDirectoryPath = directoryPathContext.ServiceProvider.RunFunc<IStringlyTypedPathOperator, string>(stringlyTypedPathOpertor =>
            {
                var output = stringlyTypedPathOpertor.GetDirectoryPath(directoryPathContext.DirectoryPath, subDirectoryRelativePath);
                return output;
            });

            return directoryPathContext.InDirectoryPathContext(subDirectoryPath, subDirectoryPathContextAction);
        }
    }
}

namespace R5T.T0031.T001.X001
{
    public static partial class IDirectoryPathContextExtensions
    {
        public static Task<TDirectoryPathContext> CreateDirectoryOkIfExists<TDirectoryPathContext>(this TDirectoryPathContext directoryPathContext)
            where TDirectoryPathContext : IDirectoryPathContext
        {
            directoryPathContext.WithServiceSynchronous<IFileSystemOperator>(fileSystemOperator =>
            {
                fileSystemOperator.CreateDirectory(directoryPathContext.DirectoryPath);
            });

            return Task.FromResult(directoryPathContext);
        }

        public static async Task<TDirectoryPathContext> CreateDirectoryOkIfExists<TDirectoryPathContext>(this Task<TDirectoryPathContext> gettingDirectoryPathContext)
            where TDirectoryPathContext : IDirectoryPathContext
        {
            var directoryPathContext = await gettingDirectoryPathContext;

            await directoryPathContext.CreateDirectoryOkIfExists();

            return directoryPathContext;
        }

        public static Task<TDirectoryPathContext> CreateDirectoryOkIfExists<TDirectoryPathContext, TContext>(this TContext context,
            string directoryPath,
            Func<TContext, string, Task<TDirectoryPathContext>> directoryPathContextConstructor)
            where TContext : IContext
            where TDirectoryPathContext : IDirectoryPathContext
        {
            return context.GetDirectoryPath(directoryPath,
                directoryPathContextConstructor)
                .CreateDirectoryOkIfExists()
                ;
        }

        public static async Task<TDirectoryPathContext> CreateDirectoryOkIfExists<TDirectoryPathContext, TContext>(this Task<TContext> gettingContext,
            string directoryPath,
            Func<TContext, string, Task<TDirectoryPathContext>> directoryPathContextConstructor)
            where TContext : IContext
            where TDirectoryPathContext : IDirectoryPathContext
        {
            var context = await gettingContext;

            var directoryPathContext = await context.CreateDirectoryOkIfExists(directoryPath,
                directoryPathContextConstructor);

            return directoryPathContext;
        }

        public static Task<TSubDirectoryPathContext> GetSubDirectoryPathContext<TSubDirectoryPathContext, TDirectoryPathContext>(this TDirectoryPathContext directoryPathContext,
            string directoryName,
            Func<TDirectoryPathContext, string, Task<TSubDirectoryPathContext>> subDirectoryPathContextConstructor)
            where TDirectoryPathContext : IDirectoryPathContext
            where TSubDirectoryPathContext : IDirectoryPathContext
        {
            var subDirectoryPath = directoryPathContext.WithServiceSynchronous<IStringlyTypedPathOperator, string>(stringlyTypedPathOperator =>
            {
                var output = stringlyTypedPathOperator.GetDirectoryPath(directoryPathContext.DirectoryPath, directoryName);
                return output;
            });

            var subDirectoryPathContext = subDirectoryPathContextConstructor(directoryPathContext, subDirectoryPath);
            return subDirectoryPathContext;
        }

        public static async Task<TSubDirectoryPathContext> GetSubDirectoryPathContext<TSubDirectoryPathContext, TDirectoryPathContext>(this Task<TDirectoryPathContext> gettingDirectoryPathContext,
            string directoryName,
            Func<TDirectoryPathContext, string, Task<TSubDirectoryPathContext>> subDirectoryPathContextConstructor)
            where TDirectoryPathContext : IDirectoryPathContext
            where TSubDirectoryPathContext : IDirectoryPathContext
        {
            var directoryPathContext = await gettingDirectoryPathContext;

            var subDirectoryPathContext = await directoryPathContext.GetSubDirectoryPathContext(directoryName,
                subDirectoryPathContextConstructor);

            return subDirectoryPathContext;
        }

        public static async Task<TDirectoryPathContext> InSubDirectory<TSubDirectoryPathContext, TDirectoryPathContext>(this TDirectoryPathContext directoryPathContext,
            string directoryName,
            Func<TDirectoryPathContext, string, Task<TSubDirectoryPathContext>> subDirectoryPathContextConstructor,
            Func<TSubDirectoryPathContext, Task> action)
            where TDirectoryPathContext : IDirectoryPathContext
            where TSubDirectoryPathContext : IDirectoryPathContext
        {
            var subDirectoryPathContext = await directoryPathContext.GetSubDirectoryPathContext(directoryName,
                subDirectoryPathContextConstructor);

            await action(subDirectoryPathContext);

            return directoryPathContext;
        }

        public static Task<TSubDirectoryPathContext> CreateSubDirectoryOkIfExists<TSubDirectoryPathContext, TDirectoryPathContext>(this TDirectoryPathContext directoryPathContext,
            string directoryName,
            Func<TDirectoryPathContext, string, Task<TSubDirectoryPathContext>> subDirectoryPathContextConstructor)
            where TDirectoryPathContext : IDirectoryPathContext
            where TSubDirectoryPathContext : IDirectoryPathContext
        {
            return directoryPathContext
                .GetSubDirectoryPathContext(
                    directoryName,
                    subDirectoryPathContextConstructor)
                .CreateDirectoryOkIfExists();
        }

        public static async Task<TSubDirectoryPathContext> CreateSubDirectoryOkIfExists<TSubDirectoryPathContext, TDirectoryPathContext>(this Task<TDirectoryPathContext> gettingDirectoryPathContext,
            string directoryName,
            Func<TDirectoryPathContext, string, Task<TSubDirectoryPathContext>> subDirectoryPathContextConstructor)
            where TDirectoryPathContext : IDirectoryPathContext
            where TSubDirectoryPathContext : IDirectoryPathContext
        {
            var directoryPathContext = await gettingDirectoryPathContext;

            return await directoryPathContext.CreateSubDirectoryOkIfExists(
                directoryName,
                subDirectoryPathContextConstructor);
        }
    }
}
