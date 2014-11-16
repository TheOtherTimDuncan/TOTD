using System;
using FluentAssertions;
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
            shortguid.Guid.Should().Be(guid);
        }
    }
}
