using System;
using System.Threading.Tasks;


namespace R5T.T0031.T001
{
    public class DirectoryPathContext : ContextBase,
        IDirectoryPathContext
    {
        #region Static

        public static Task<DirectoryPathContext> Constructor<TContext>(TContext context, string directoryPath)
            where TContext : IContext
        {
            var directoryPathContext = new DirectoryPathContext
            {
                DirectoryPath = directoryPath,
            }
            .InitializeFrom(context);

            return Task.FromResult(directoryPathContext);
        }

        #endregion


        public string DirectoryPath { get; set; }
    }
}
