using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Utility.UnitTestHelpers;

namespace TODT.Test.UtilityTests
{
    [TestClass]
    public class UnitTestHelperTests
    {
        [TestMethod]
        public void SetEntityIDSetsSpecifiedPropertiesToUniqueValues()
        {
            TestEntity testEntity1 = new TestEntity().SetEntityID(x => x.ID);
            TestEntity testEntity2 = new TestEntity().SetEntityID(x => x.ID);
            testEntity1.ID.Should().NotBe(testEntity2.ID);
        }


        [TestMethod]
        public void FillWithTestDataFillsEntityWithUniqueValues()
        {
            TestEntity testEntity = new TestEntity().FillWithTestData();

            List<byte> numbers = new List<byte>();

            numbers.Add(testEntity.Byte1);
            numbers.Add(testEntity.Byte2);
            numbers.Add((byte)testEntity.Int161);
            numbers.Add((byte)testEntity.Int162);
            numbers.Add((byte)testEntity.Int321);
            numbers.Add((byte)testEntity.Int322);
            numbers.Add((byte)testEntity.Long1);
            numbers.Add((byte)testEntity.Long2);

            numbers.Distinct().Should().HaveCount(numbers.Count());

            testEntity.ID.Should().Be(default(int));

            testEntity.DateTime1.Should().NotBe(testEntity.DateTime2);
            testEntity.Decimal1.Should().NotBe(testEntity.Decimal2);
            testEntity.DateTimeOffset1.Should().NotBe(testEntity.DateTimeOffset2);
        }

        [TestMethod]
        public void GetAsyncVoidMethodsReturnsAsyncVoidMethods()
        {
            IEnumerable<MethodInfo> methods = UnitTestHelper.GetAsyncVoidMethods(GetType().Assembly);
            methods.Any(x => x.Name == "BadAsyncMethod").Should().BeTrue();
            methods.Any(x => x.Name == "GoodAsyncMethod").Should().BeFalse();
        }

#pragma warning disable CS1998 // Needed for unit test
        private async void BadAsyncMethod()
#pragma warning restore CS1998 
        {
        }

#pragma warning disable CS1998 // Needed for unit test
        private async Task GoodAsyncMethod()
#pragma warning restore CS1998 
        {
        }

        public class TestEntity
        {
            public int ID
            {
                get;
                private set;
            }

            public byte Byte1
            {
                get;
                set;
            }

            public byte Byte2
            {
                get;
                set;
            }

            public short Int161
            {
                get;
                set;
            }

            public short Int162
            {
                get;
                set;
            }

            public int Int321
            {
                get;
                set;
            }

            public int Int322
            {
                get;
                set;
            }

            public long Long1
            {
                get;
                set;
            }

            public long Long2
            {
                get;
                set;
            }

            public decimal Decimal1
            {
                get;
                set;
            }

            public decimal Decimal2
            {
                get;
                set;
            }

            public DateTime DateTime1
            {
                get;
                set;
            }

            public DateTime DateTime2
            {
                get;
                set;
            }

            public DateTimeOffset DateTimeOffset1
            {
                get;
                set;
            }

            public DateTimeOffset DateTimeOffset2
            {
                get;
                set;
            }
        }
    }
}
