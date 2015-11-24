using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TODT.Test.Fakes
{
    public class TestController : Controller
    {
        public ActionResult TestAction(int actionID)
        {
            return null;
        }

        public ActionResult TestAction2(int actionID, string value)
        {
            return null;
        }

        public ActionResult FormAction(string returnUrl)
        {
            return null;
        }

        public ActionResult DifferentAction(string test)
        {
            return null;
        }

        public ActionResult OtherAction()
        {
            return null;
        }

        public Task<ActionResult> TestActionAsync(int actionID)
        {
            return null;
        }

        public ActionResult ModelAction(TestModel model)
        {
            return null;
        }
    }
}
