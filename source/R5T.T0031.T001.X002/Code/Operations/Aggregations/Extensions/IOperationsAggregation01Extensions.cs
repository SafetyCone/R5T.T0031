using System;


namespace R5T.T0031.T001.X002
{
    public static class IOperationsAggregation01Extensions
    {
        public static T FillFrom<T>(this T aggregation,
            IOperationsAggregation01 other)
            where T : IOperationsAggregation01
        {
            aggregation.CreateDirectoryAction = other.CreateDirectoryAction;
            aggregation.GetDirectoryPathAction = other.GetDirectoryPathAction;

            return aggregation;
        }
    }
}
