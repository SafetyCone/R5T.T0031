using System;
using System.Threading.Tasks;

using R5T.Gepidia;


namespace R5T.T0031.T001.X001
{
    public static class IContextExtensions
    {
        public static void MoveFile<TContext>(this TContext context,
            string sourceFilePath,
            string destinationFilePath)
            where TContext : IContext
        {
            context.WithServiceSynchronous<IFileSystemOperator>(fileSystemOperator =>
            {
                fileSystemOperator.MoveFile(sourceFilePath, destinationFilePath);
            });
        }
    }
}
