using System.Collections.Generic;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static double StdDev(this IEnumerable<double> values)
        {
            double result = 0;
            if (values.Count() > 0)
            {
                double mean = values.Average();
                double sum  = values.Sum(d => Math.Pow(d - mean, 2));
                result = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return result;
        }
    }
}
