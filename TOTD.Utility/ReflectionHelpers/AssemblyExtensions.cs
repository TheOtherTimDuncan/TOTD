using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TOTD.Utility.ExceptionHelpers;

namespace TOTD.Utility.ReflectionHelpers
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            ThrowIf.Argument.IsNull(assembly, "assembly");

            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}
