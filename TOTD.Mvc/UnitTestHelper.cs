using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TOTD.Utility.ReflectionHelpers;

namespace TOTD.Mvc
{
    public static class UnitTestHelper
    {
        public static IEnumerable<MethodInfo> GetAsyncVoidMethods(Assembly assembly)
        {
            return
                from t in assembly.GetLoadableTypes()
                from m in t.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
                where Attribute.GetCustomAttribute(m, typeof(AsyncStateMachineAttribute)) != null && m.ReturnType == typeof(void)
                select m;
        }

        public static IEnumerable<MethodInfo> GetControllerActionsMissingValidateAntiForgeryTokenAttribute<ControllerType>() where ControllerType : Controller
        {
            return
                from c in typeof(ControllerType).Assembly.GetLoadableTypes()
                where typeof(Controller).IsAssignableFrom(c)
                from a in c.GetMethods()
                where Attribute.GetCustomAttribute(a, typeof(HttpPostAttribute)) != null && Attribute.GetCustomAttribute(a, typeof(ValidateAntiForgeryTokenAttribute)) == null
                select a;
        }
    }
}
