using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindOne.Core.Helper
{
    public static class EnumHelper
    {
        public static string EnumToString<T>(this T value) where T : struct, IConvertible
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
