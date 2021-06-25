using System;


namespace R5T.T0031
{
    public static class ContextBaseExtensions
    {
        /// <summary>
        /// Copies over the <see cref="IContext.ServiceProvider"/> instance.
        /// Note: extension must extend <see cref="ContextBase"/> and not <see cref="IContext"/> since <see cref="IContext.ServiceProvider"/> is read-only, but <see cref="ContextBase.ServiceProvider"/> is not.
        /// </summary>
        public static TContext InitializeFrom<TContext, TParentContext>(this TContext context,
            TParentContext parentContext)
            where TContext : ContextBase
            where TParentContext : IContext
        {
            context.ServiceProvider = parentContext.ServiceProvider;

            return context;
        }
    }
}
