using System;
using System.Threading.Tasks;


namespace R5T.T0031
{
    /// <summary>
    /// Constructors are synchronous by default.
    /// The idea of a constructor can be at least two things:
    /// 1) Do the bare-minimum construction of an object in memory. This is the C# constructor idea, and it is assumed to be synchronous.
    /// 2) Provide a usable instance of a type. This involves construction, plus what is identified as "initialization". This initialization is extra work and can be asynchronous.
    /// If these two concepts are combined, because initialization can be asynchronous, the combined "construction" concept is asynchronous.
    /// However, construction is assumed be by synchronous.
    /// </summary>
    public delegate TContext ContextConstructor<TContext>(IServiceProvider serviceProvider)
        where TContext : IContext;

    /// <summary>
    /// Constructors are synchronous by default.
    /// </summary>
    public delegate Task<TContext> ContextConstructorAsynchronous<TContext>(IServiceProvider serviceProvider)
        where TContext : IContext;

    /// <summary>
    /// Initialization is asynchronous by default.
    /// </summary>
    public delegate void ContextInitializerSynchronous<TContext, TParentContext>(TContext context, TParentContext parentContext)
        where TContext : IContext
        where TParentContext : IContext;

    /// <summary>
    /// Initialization is asynchronous by default.
    /// </summary>
    public delegate Task ContextInitializer<TContext, TParentContext>(TContext context, TParentContext parentContext)
        where TContext : IContext
        where TParentContext : IContext;

    /// <summary>
    /// Constructor-initializers are asynchronous by default because initialization is asynchronous by default.
    /// </summary>
    public delegate TContext ContextConstructorInitializerSynchronous<TContext, TParentContext>(TParentContext parentContext)
        where TContext : IContext
        where TParentContext : IContext;

    /// <summary>
    /// Constructor-initializers are asynchronous by default because initialization is asynchronous by default.
    /// </summary>
    public delegate Task<TContext> ContextConstructorInitializer<TContext, TParentContext>(TParentContext parentContext)
        where TContext : IContext
        where TParentContext : IContext;
}
