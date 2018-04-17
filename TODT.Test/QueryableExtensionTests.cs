using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Testing.Moq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.EntityFramework;

namespace TODT.Test
{
    [TestClass]
    public class QueryableExtensionTests
    {
        [TestClass]
        public class TakePageMethod
        {
            [TestMethod]
            public void ReturnsCorrectPage()
            {
                IQueryable<int> test = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }.AsQueryable();
                int[] result = test.TakePage(2, 5).ToArray();
                result.Should().Equal(new[] { result[0], result[1], result[2], result[3], result[4] });
            }

            [TestMethod]
            public void ThrowsExceptionForNullSource()
            {
                IQueryable<int> test = null;
                Action action = () =>
                {
                    IQueryable<int> result = test.TakePage(1, 10);
                };
                action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("source");
            }
        }

        [TestClass]
        public class SelectToListMethod : QueryableExtensionTests
        {
            [TestMethod]
            public void ReturnsExecutedProjection()
            {
                TestEntity testEntity1 = new TestEntity()
                {
                    ID = 1,
                    Name = "name1"
                };

                TestEntity testEntity2 = new TestEntity()
                {
                    ID = 2,
                    Name = "name2"
                };

                MockDbSet<TestEntity> mockDbSet = CreateMockDbSet(testEntity1, testEntity2);
                var result = mockDbSet.Object.SelectToList(x => x.ID.Value);
                result.Should().BeOfType<List<int>>();
                result.Should().Equal(new[] { testEntity1.ID, testEntity2.ID });
            }

            [TestMethod]
            public async Task ReturnsExecutedProjectionAsynchronously()
            {
                TestEntity testEntity1 = new TestEntity()
                {
                    ID = 1,
                    Name = "name1"
                };

                TestEntity testEntity2 = new TestEntity()
                {
                    ID = 2,
                    Name = "name2"
                };

                MockDbSet<TestEntity> mockDbSet = CreateMockDbSet(testEntity1, testEntity2);
                var result = await mockDbSet.Object.SelectToListAsync(x => x.ID.Value);
                result.Should().BeOfType<List<int>>();
                result.Should().Equal(new[] { testEntity1.ID, testEntity2.ID });
            }
        }

        [TestClass]
        public class SelectSingleMethod : QueryableExtensionTests
        {
            [TestMethod]
            public void ReturnsExecutedProjection()
            {
                TestEntity testEntity1 = new TestEntity()
                {
                    ID = 1,
                    Name = "name1"
                };

                TestEntity testEntity2 = new TestEntity()
                {
                    ID = 2,
                    Name = "name2"
                };

                MockDbSet<TestEntity> mockDbSet = CreateMockDbSet(testEntity1, testEntity2);
                var result = mockDbSet.Object.Where(x => x.ID == 1).SelectSingle(x => x.ID);
                result.Should().Be(1);
            }

            [TestMethod]
            public async Task ReturnsExecutedProjectionAsynchronously()
            {
                TestEntity testEntity1 = new TestEntity()
                {
                    ID = 1,
                    Name = "name1"
                };

                TestEntity testEntity2 = new TestEntity()
                {
                    ID = 2,
                    Name = "name2"
                };

                MockDbSet<TestEntity> mockDbSet = CreateMockDbSet(testEntity1, testEntity2);
                var result = await mockDbSet.Object.Where(x => x.ID == 1).SelectSingleAsync(x => x.ID);
                result.Should().Be(1);
            }
        }

        [TestClass]
        public class SelectFirstMethod : QueryableExtensionTests
        {
            [TestMethod]
            public void ReturnsExecutedProjection()
            {
                TestEntity testEntity1 = new TestEntity()
                {
                    ID = 1,
                    Name = "name1"
                };

                TestEntity testEntity2 = new TestEntity()
                {
                    ID = 2,
                    Name = "name2"
                };

                MockDbSet<TestEntity> mockDbSet = CreateMockDbSet(testEntity1, testEntity2);
                var result = mockDbSet.Object.Where(x => x.ID == 1).SelectFirst(x => x.ID);
                result.Should().Be(1);
            }

            [TestMethod]
            public async Task ReturnsExecutedProjectionAsynchronously()
            {
                TestEntity testEntity1 = new TestEntity()
                {
                    ID = 1,
                    Name = "name1"
                };

                TestEntity testEntity2 = new TestEntity()
                {
                    ID = 2,
                    Name = "name2"
                };

                MockDbSet<TestEntity> mockDbSet = CreateMockDbSet(testEntity1, testEntity2);
                var result = await mockDbSet.Object.Where(x => x.ID == 1).SelectFirstAsync(x => x.ID);
                result.Should().Be(1);
            }
        }

        [TestClass]
        public class SelectSingleOrDefaultMethod : QueryableExtensionTests
        {
            [TestMethod]
            public void ReturnsExecutedProjection()
            {
                TestEntity testEntity1 = new TestEntity()
                {
                    ID = 1,
                    Name = "name1"
                };

                TestEntity testEntity2 = new TestEntity()
                {
                    ID = 2,
                    Name = "name2"
                };

                MockDbSet<TestEntity> mockDbSet = CreateMockDbSet(testEntity1, testEntity2);
                var result = mockDbSet.Object.Where(x => x.ID == 1).SelectSingleOrDefault(x => x.ID);
                result.Should().Be(1);
            }

            [TestMethod]
            public async Task ReturnsExecutedProjectionAsynchronously()
            {
                TestEntity testEntity1 = new TestEntity()
                {
                    ID = 1,
                    Name = "name1"
                };

                TestEntity testEntity2 = new TestEntity()
                {
                    ID = 2,
                    Name = "name2"
                };

                MockDbSet<TestEntity> mockDbSet = CreateMockDbSet(testEntity1, testEntity2);
                var result = await mockDbSet.Object.Where(x => x.ID == 1).SelectSingleOrDefaultAsync(x => x.ID);
                result.Should().Be(1);
            }

            [TestMethod]
            public void ReturnsDefaultValueIfProjectionIsEmpty()
            {
                TestEntity testEntity1 = new TestEntity()
                {
                    ID = 1,
                    Name = "name1"
                };

                TestEntity testEntity2 = new TestEntity()
                {
                    ID = 2,
                    Name = "name2"
                };

                MockDbSet<TestEntity> mockDbSet = CreateMockDbSet(testEntity1, testEntity2);
                var result = mockDbSet.Object.Where(x => x.ID == 1).SelectSingleOrDefault(x => x.ID);
                result.Should().Be(1);
            }

            [TestMethod]
            public async Task ReturnsDefaultValueAsynchronouslyIfProjectionIsEmpty()
            {
                TestEntity testEntity1 = new TestEntity()
                {
                    ID = 1,
                    Name = "name1"
                };

                TestEntity testEntity2 = new TestEntity()
                {
                    ID = 2,
                    Name = "name2"
                };

                MockDbSet<TestEntity> mockDbSet = CreateMockDbSet(testEntity1, testEntity2);
                var result = await mockDbSet.Object.Where(x => x.ID == 1).SelectSingleOrDefaultAsync(x => x.ID);
                result.Should().Be(1);
            }
        }

        private MockDbSet<TestEntity> CreateMockDbSet(params TestEntity[] entities)
        {
            return new MockDbSet<TestEntity>()
                .SetupLinq()
                .SetupSeedData(entities);
        }

        public class TestEntity
        {
            public int? ID
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }
        }
    }
}
