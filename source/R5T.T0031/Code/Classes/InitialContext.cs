using System;
using System.Threading.Tasks;


namespace R5T.T0031
{
    /// <summary>
    /// The initial (root) context.
    /// </summary>
    public class InitialContext : ContextBase
    {
        #region Static

        public static InitialContext FromSynchronous(IServiceProvider serviceProvider)
        {
            var initialContext = new InitialContext
            {
                ServiceProvider = serviceProvider
            };

            return initialContext;
        }

        /// <summary>
        /// Can serve as a root for asynchronous flent code.
        /// </summary>
        public static Task<InitialContext> From(IServiceProvider serviceProvider)
        {
            var initialContext = InitialContext.FromSynchronous(serviceProvider);

            return Task.FromResult(initialContext);
        }

        #endregion
    }
}
