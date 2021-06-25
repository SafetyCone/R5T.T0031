using System;


namespace R5T.T0031
{
    public abstract class ContextBase : IContext
    {
        public IServiceProvider ServiceProvider { get; set; }
    }
}
