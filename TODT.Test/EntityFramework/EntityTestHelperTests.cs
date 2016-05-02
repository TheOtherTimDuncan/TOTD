using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.EntityFramework;

namespace TODT.Test.EntityFramework
{
    [TestClass]
    public class EntityTestHelperTests
    {
        [TestMethod]
        public void GetKeyPropertyNamesReturnsNameOfPropertiesConfiguredAsPrimaryKey()
        {
            using (TestDbContext testContext = new TestDbContext())
            {
                testContext.GetKeyPropertyNames<TestEntity>().Should().Equal(new[] { "ID" });
                testContext.GetKeyPropertyNames<TestAliasedEntity>().Should().Equal(new[] { "ID1", "ID2" });
            }
        }

        [TestMethod]
        public void GetIdentityPropertyNamesReturnsNameOfPropertiesConfiguredAsIdentityValues()
        {
            using (TestDbContext testContext = new TestDbContext())
            {
                testContext.GetIdentityPropertyNames<TestEntity>().Should().Equal(new[] { "ID" });
                testContext.GetIdentityPropertyNames<TestAliasedEntity>().Should().BeNullOrEmpty();
            }
        }

        [TestMethod]
        public void FillWithTestDataFillsEntityWithUniqueValues()
        {
            using (TestDbContext testContext = new TestDbContext())
            {
                TestEntity testEntity = new TestEntity();
                testContext.FillWithTestData(testEntity);

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

                testEntity.AliasedColumn.Should().HaveLength(TestEntity.AliasedColumnLength);
            }
        }
    }
}
