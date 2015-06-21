using System;
using System.Collections.Generic;
using System.IO;
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

        public static string GetSolutionRoot()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            int pos = basePath.IndexOf("TestResults", StringComparison.OrdinalIgnoreCase);
            if (pos > 0)
            {
                string result = basePath.Substring(0, pos);
                return result;
            }
            else
            {
                pos = basePath.IndexOf("bin", StringComparison.OrdinalIgnoreCase);
                string projectPath = basePath.Substring(0, pos - 1);
                string result = Directory.GetParent(projectPath).FullName;
                return result;
            }
        }
    }
}
