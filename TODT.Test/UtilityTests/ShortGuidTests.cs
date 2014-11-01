using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Utility.Misc;

namespace TODT.Test.UtilityTests
{
    [TestClass]
    public class ShortGuidTests
    {
        [TestMethod]
        public void GuideValueEqualsShortValue()
        {
            Guid guid = Guid.NewGuid();
            ShortGuid shortguid = guid;
            Assert.AreEqual(guid, shortguid.Guid);
        }
    }
}
