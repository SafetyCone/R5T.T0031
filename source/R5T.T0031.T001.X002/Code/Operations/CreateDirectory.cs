using System;
using System.Threading.Tasks;

using R5T.Gepidia;

using R5T.T0020;


namespace R5T.T0031.T001.X002
{
    public class CreateDirectory : IActionOperation<string>
    {
        private IFileSystemOperator FileSystemOperator { get; }


        public CreateDirectory(
            IFileSystemOperator fileSystemOperator)
        {
            this.FileSystemOperator = fileSystemOperator;
        }

        public Task Run(string directoryPath)
        {
            this.FileSystemOperator.CreateDirectory(directoryPath);

            return Task.CompletedTask;
        }
    }
}
