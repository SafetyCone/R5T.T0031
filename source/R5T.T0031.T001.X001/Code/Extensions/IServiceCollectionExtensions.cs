using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Gepidia;
using R5T.Lombardy;


namespace R5T.T0031.T001.X001
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDirectoryPathContextExtensions(this IServiceCollection services,
            IServiceAction<IFileSystemOperator> fileSystemOperatorAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .Run(fileSystemOperatorAction)
                .Run(stringlyTypedPathOperatorAction)
                ;

            return services;
        }
    }
}
