using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Utility.EnumerableHelpers;
using TOTD.Utility.StringHelpers;
using FluentAssertions;

namespace TODT.Test.UtilityTests
{
    public class EnumerableExtensionsTests
    {
        [TestClass]
        public class IsNullOrEmptyMethod
        {
            [TestMethod]
            public void ReturnsTrueIfNull()
            {
                IEnumerable<int> nullTest = null;
                nullTest.IsNullOrEmpty().Should().BeTrue("source is null");
            }

            [TestMethod]
            public void ReturnsTrueIfEmpty()
            {
                new List<int>()
                    .IsNullOrEmpty()
                        .Should()
                        .BeTrue("source is empty");
            }

            [TestMethod]
            public void ReturnsFalseIfNotEmpty()
            {
                new int[] { 1, 2 }
                    .IsNullOrEmpty()
                        .Should()
                        .BeFalse("source is not empty or null");
            }
        }

        [TestClass]
        public class TakePageMethod
        {
            [TestMethod]
            public void ReturnsCorrectPage()
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }
                    .TakePage(2, 5)
                        .Should()
                        .HaveCount(5, "because page size is 5")
                        .And
                        .Equal(new int[] { 6, 7, 8, 9, 10 }, "because 5 elements starting at element 2 were asked for");
            }

            [TestMethod]
            public void ThrowsExceptionForNullSource()
            {
                Action testaction = () =>
                {
                    IEnumerable<int> test = null;
                    IEnumerable<int> result = test.TakePage(1, 10);
                };
                testaction.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("source");
            }
        }

        [TestClass]
        public class NullSafeAnyMethod
        {
            [TestMethod]
            public void ReturnsTrueIfContainsElement()
            {
                new int[] { 1, 2, 3 }
                    .NullSafeAny(x => x == 1)
                        .Should()
                        .BeTrue("original Any still works");
            }

            [TestMethod]
            public void ReturnsFalseIfNotContainsElement()
            {
                new int[] { 1, 2, 3 }
                    .NullSafeAny(x => x == 9)
                        .Should()
                        .BeFalse("original Any still works");
            }

            [TestMethod]
            public void ReturnsFalseForNull()
            {
                IEnumerable<int> test = null;
                test.NullSafeAny(x => x == 1)
                    .Should()
                    .BeFalse("null source should return false instead of throw exception");
            }
        }

        [TestClass]
        public class NullSafeWhereMethod
        {
            [TestMethod]
            public void ReturnsEmptySequenceIfNull()
            {
                IEnumerable<int> test = null;
                test.NullSafeWhere(x => x == 1)
                    .Should()
                    .HaveCount(0, "should return empty sequence from null source instead of throwing exception");
            }

            [TestMethod]
            public void ReturnsMatchingSequenceIfNotNull()
            {
                new int[] { 1, 2, 3 }
                    .NullSafeWhere(x => x >= 2)
                    .Should()
                    .Equal(new int[] { 2, 3 }, "original Where still works");
            }
        }

        [TestClass]
        public class NullSafeSelectMethod
        {
            [TestMethod]
            public void ReturnsEmptySequenceIfNull()
            {
                IEnumerable<int> test = null;
                test.NullSafeSelect(x => x * 2)
                    .Should()
                    .HaveCount(0, "should return empty sequence from null source instead of throwing exception");

            }

            [TestMethod]
            public void ReturnsSequenceIfNotNull()
            {
                new int[] { 1, 2, 3 }
                    .NullSafeSelect(x => x * 2)
                    .Should()
                    .Equal(new int[] { 2, 4, 6 }, "original Select still works");
            }
        }

        [TestClass]
        public class NullSafeOrderByMethod
        {
            [TestMethod]
            public void ReturnsEmptySequenceIfNull()
            {
                IEnumerable<int> test = null;
                test.NullSafeOrderBy(x => x).Should().BeEmpty();
            }

            [TestMethod]
            public void ReturnsSortedSequenceIfNotNull()
            {
                new[] { 2, 1, 4, 3, 5 }
                    .NullSafeOrderBy(x => x)
                    .Should().Equal(1, 2, 3, 4, 5);
            }
        }

        [TestClass]
        public class NullSafeOrderByDescendingMethod
        {
            [TestMethod]
            public void ReturnsEmptySequenceIfNull()
            {
                IEnumerable<int> test = null;
                test.NullSafeOrderByDescending(x => x).Should().BeEmpty();
            }

            [TestMethod]
            public void ReturnsSortedSequenceIfNotNull()
            {
                new[] { 2, 1, 4, 3, 5 }
                    .NullSafeOrderByDescending(x => x)
                    .Should().Equal(5, 4, 3, 2, 1);
            }
        }

        [TestClass]
        public class NullSafeForEachMethod
        {
            [TestMethod]
            public void DoesNotThrowExceptionForNullSequence()
            {
                Action action = () =>
                {
                    IEnumerable<int> test = null;
                    test.NullSafeForEach(x => x = x + 1);
                };
                action.Should().NotThrow();
            }

            [TestMethod]
            public void PerformsActionOnSequenceIfNotNull()
            {
                int sum = 0;
                new[] { 1, 2, 3 }.NullSafeForEach(x => sum += x);
                sum.Should().Be(6);
            }
        }

        [TestClass]
        public class ForrEachMethod
        {
            [TestMethod]
            public void ThrowsExceptionForNullSequence()
            {
                Action action = () =>
                {
                    IEnumerable<int> test = null;
                    test.ForEach(x => x = x + 1);
                };
                action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("source");
            }

            [TestMethod]
            public void ThrowsExceptionForNullAction()
            {
                Action action = () =>
                {
                    IEnumerable<int> test = new[] { 1, 2, 3 };
                    test.ForEach(null);
                };
                action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("action");
            }

            [TestMethod]
            public void PerformsActionOnSequenceIfNotNull()
            {
                int sum = 0;
                new[] { 1, 2, 3 }.ForEach(x => sum += x);
                sum.Should().Be(6);
            }
        }

        [TestClass]
        public class NullSafeJoinMethod
        {
            [TestMethod]
            public void ReturnsNullForNullSequence()
            {
                IEnumerable<string> test = null;
                test.NullSafeJoin(",").Should().BeNull();

            }

            [TestMethod]
            public void ReturnsEmptyStringForEmptySequence()
            {
                new string[] { }.NullSafeJoin(",").Should().BeEmpty();
            }

            [TestMethod]
            public void ReturnsJoinedSequenceForNonNullSequence()
            {
                new[] { "1", "2" }.NullSafeJoin(",").Should().Be("1,2");
            }
        }

        [TestClass]
        public class BatchMethod
        {
            [TestMethod]
            public void ExecutesSequenceInBatches()
            {
                IEnumerable<int> sequence = Enumerable.Range(1, 100);
                int value = 1;
                sequence.BatchForEach(10, (batch) =>
                {
                    batch.Should().HaveCount(10, "batch size is 10");

                    foreach (int i in batch)
                    {
                        i.Should().Be(value);
                        value++;
                    }
                });
            }
        }

        [TestClass]
        public class NullSafeCountMethod
        {
            [TestMethod]
            public void Returns0ForNullSequence()
            {
                IEnumerable<int> sequence = null;
                sequence.NullSafeCount()
                    .Should()
                    .Be(0, "should return 0 for null sequence instead of throwing exception");
            }

            [TestMethod]
            public void ReturnsCorrectCountForNonNullSequence()
            {
                new int[] { 1, 2, 3 }
                    .NullSafeCount()
                    .Should()
                    .Be(3, "original Count still works");
            }
        }
    }
}
