using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0020;
using R5T.T0031;


namespace System
{
    public static class IContextExtensions
    {
        public static Task Run<TOperation>(this IContext context)
            where TOperation : IActionOperation
        {
            var operation = context.ServiceProvider.GetRequiredService<TOperation>();

            return operation.Run();
        }
    }
}
