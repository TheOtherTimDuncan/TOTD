using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TOTD.Mvc
{
    public static class UnitTestHelper
    {
        public static IEnumerable<MethodInfo> GetControllerActionsMissingValidateAntiForgeryTokenAttribute<ControllerType>() where ControllerType : Controller
        {
            return
                from c in typeof(ControllerType).Assembly.GetTypes()
                where typeof(Controller).IsAssignableFrom(c)
                from a in c.GetMethods()
                where Attribute.GetCustomAttribute(a, typeof(HttpPostAttribute)) != null && Attribute.GetCustomAttribute(a, typeof(ValidateAntiForgeryTokenAttribute)) == null
                select a;
        }
    }
}
