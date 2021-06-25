using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Gepidia;
using R5T.Lombardy;


namespace R5T.T0031.T001.X002
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CreateDirectory"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddCreateDirectory(this IServiceCollection services,
            IServiceAction<IFileSystemOperator> fileSystemOperatorAction)
        {
            services.AddSingleton<CreateDirectory>()
                .Run(fileSystemOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="CreateDirectory"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<CreateDirectory> AddCreateDirectoryAction(this IServiceCollection services,
            IServiceAction<IFileSystemOperator> fileSystemOperatorAction)
        {
            var serviceAction = ServiceAction.New<CreateDirectory>(() => services.AddCreateDirectory(
                fileSystemOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="GetDirectoryPath"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGetDirectoryPath(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services.AddSingleton<GetDirectoryPath>()
                .Run(stringlyTypedPathOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GetDirectoryPath"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<GetDirectoryPath> AddGetDirectoryPathAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = ServiceAction.New<GetDirectoryPath>(() => services.AddGetDirectoryPath(
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds services to a service collection.
        /// </summary>
        public static IServiceCollection AddAddDirectoryPathContextOperations(this IServiceCollection services,
            IServiceAction<IFileSystemOperator> fileSystemOperatorAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .AddCreateDirectory(
                    fileSystemOperatorAction)
                .AddGetDirectoryPathAction(
                    stringlyTypedPathOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds services to a service collection.
        /// </summary>
        public static OperationsAggregation01 AddAddDirectoryPathContextOperationsAction(this IServiceCollection services,
            IServiceAction<IFileSystemOperator> fileSystemOperatorAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var createDirectoryAction = services.AddCreateDirectoryAction(
                fileSystemOperatorAction);
            var getDirectoryPathAction = services.AddGetDirectoryPathAction(
                stringlyTypedPathOperatorAction);

            return new OperationsAggregation01
            {
                CreateDirectoryAction = createDirectoryAction,
                GetDirectoryPathAction = getDirectoryPathAction,
            };
        }
    }
}
