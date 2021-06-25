using System;

using R5T.Lombardy;


namespace R5T.T0031.T001.X001
{
    public static partial class IDirectoryPathContextExtensions
    {
        public static string GetFilePath<TDirectoryPathContext>(this TDirectoryPathContext directoryPathContext,
            string fileName)
            where TDirectoryPathContext : IDirectoryPathContext
        {
            return directoryPathContext.WithServiceSynchronous<IStringlyTypedPathOperator, string>(stringlyTypedPathOperator =>
            {
                var filePath = stringlyTypedPathOperator.GetFilePath(directoryPathContext.DirectoryPath, fileName);
                return filePath;
            });
        }

        public static string GetSubDirectoryPath<TDirectoryPathContext>(this TDirectoryPathContext directoryPathContext,
            string subDirectoryName)
            where TDirectoryPathContext : IDirectoryPathContext
        {
            return directoryPathContext.WithServiceSynchronous<IStringlyTypedPathOperator, string>(stringlyTypedPathOperator =>
            {
                var subDirectoryPath = stringlyTypedPathOperator.GetDirectoryPath(directoryPathContext.DirectoryPath, subDirectoryName);
                return subDirectoryPath;
            });
        }
    }
}
