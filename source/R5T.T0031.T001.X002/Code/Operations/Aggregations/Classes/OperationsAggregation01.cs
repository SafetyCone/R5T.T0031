using System;

using R5T.Dacia;


namespace R5T.T0031.T001.X002
{
    public class OperationsAggregation01 : IOperationsAggregation01
    {
        public IServiceAction<CreateDirectory> CreateDirectoryAction { get; set; }
        public IServiceAction<GetDirectoryPath> GetDirectoryPathAction { get; set; }
    }
}
