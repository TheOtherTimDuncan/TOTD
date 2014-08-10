using System;
using System.Collections.Generic;
using System.Linq;
 
namespace TOTD.Utility.ExceptionHelpers
{
    public static class ThrowIf
    {
        public static class Argument
        {
            public static void IsNull(object argument, string argumentName)
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(argumentName);
                }
            }

            public static void IsLessThan(int argument, string argumentName, int value)
            {
                if (argument < value)
                {
                    throw new ArgumentOutOfRangeException(argumentName, value, null);
                }
            }
        }
    }
}
