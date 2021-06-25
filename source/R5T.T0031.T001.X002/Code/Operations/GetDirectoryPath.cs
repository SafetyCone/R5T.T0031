using System;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.T0020;


namespace R5T.T0031.T001.X002
{
    public class GetDirectoryPath : IFunctionOperation<string, string, string>
    {
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public GetDirectoryPath(
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public Task<string> Run(string parentDirectoryPath, string directoryName)
        {
            var directoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(parentDirectoryPath, directoryName);
            
            return Task.FromResult(directoryPath);
        }
    }
}
