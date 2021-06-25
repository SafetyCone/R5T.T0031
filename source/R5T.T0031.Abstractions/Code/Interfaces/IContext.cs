using System;


namespace R5T.T0031
{
    /// <summary>
    /// When something is a "context", all that means that it has services.
    /// The data of a context is context-specific, and will be properties of the descendent type.
    /// </summary>
    public interface IContext
    {
        IServiceProvider ServiceProvider { get; }
    }
}
