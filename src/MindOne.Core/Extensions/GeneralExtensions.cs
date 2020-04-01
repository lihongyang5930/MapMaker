using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindOne.Core.Extensions
{
    public static class Extensions
    {
        public static bool IsDefault<T>(this T value) where T : struct
        {
            bool isDefault = value.Equals(default(T));

            return isDefault;
        }

        public static double toDouble(this object value)
        {
            if (value == null)
                return 0;

            double OutVal;
            var flag = double.TryParse(value.ToString(), out OutVal);
            if (!flag)
                return 0;

            if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
                return 0;
            return OutVal;
        }

        public static double toInt(this object value)
        {
            if (value == null)
                return 0;

            int OutVal;
            var flag = int.TryParse(value.ToString(), out OutVal);
            if (!flag)
                return 0;

            return OutVal;
        }
    }
}
