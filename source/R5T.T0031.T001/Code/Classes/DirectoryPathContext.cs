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

        public static Task<DirectoryPathContext> ConstructorInitializer<TParentContext>(TParentContext parentContext, string directoryPath)
            where TParentContext : IContext
        {
            var directoryPathContext = new DirectoryPathContext
            {
                DirectoryPath = directoryPath,
            }
            .InitializeFrom(parentContext);

            return Task.FromResult(directoryPathContext);
        }

        public static ContextConstructorInitializer<DirectoryPathContext, TParentContext> GetConstructorInitializer<TParentContext>(string directoryPath)
            where TParentContext : IContext
        {
            Task<DirectoryPathContext> ConstructorInitializer(TParentContext parentContext)
            {
                var directoryPathContext = new DirectoryPathContext
                {
                    DirectoryPath = directoryPath,
                }
                .InitializeFrom(parentContext);

                return Task.FromResult(directoryPathContext);
            }

            return ConstructorInitializer;
        }

        #endregion


        public string DirectoryPath { get; set; }
    }
}
