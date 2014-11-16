using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TOTD.Utility.Misc
{
    public static class UnitTestHelper
    {
        public static IEnumerable<MethodInfo> GetAsyncVoidMethods(Assembly assembly)
        {
            return
                from t in assembly.GetTypes()
                from m in t.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
                where Attribute.GetCustomAttribute(m, typeof(AsyncStateMachineAttribute)) != null && m.ReturnType == typeof(void)
                select m;
        }
    }
}
