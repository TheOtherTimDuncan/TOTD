using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Utility.EnumerableHelpers;
using TOTD.Utility.StringHelpers;

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
                Assert.IsTrue(nullTest.IsNullOrEmpty());
            }

            [TestMethod]
            public void ReturnsTrueIfEmpty()
            {
                List<int> emptyTest = new List<int>();
                Assert.IsTrue(emptyTest.IsNullOrEmpty());
            }

            [TestMethod]
            public void ReturnsFalseIfNotEmpty()
            {
                int[] notEmptyTest = new int[] { 1, 2 };
                Assert.IsFalse(notEmptyTest.IsNullOrEmpty());
            }
        }

        [TestClass]
        public class TakePageMethod
        {
            [TestMethod]
            public void ReturnsCorrectPage()
            {
                IEnumerable<int> test = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                int[] result = test.TakePage(2, 5).ToArray();
                Assert.AreEqual(5, result.Length);
                Assert.AreEqual(6, result[0]);
                Assert.AreEqual(7, result[1]);
                Assert.AreEqual(8, result[2]);
                Assert.AreEqual(9, result[3]);
                Assert.AreEqual(10, result[4]);
            }

            [TestMethod]
            public void ThrowsExceptionForNullSource()
            {
                try
                {
                    IEnumerable<int> test = null;
                    IEnumerable<int> result = test.TakePage(1, 10);
                    Assert.Fail("Exception not thrown");
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("source", ex.ParamName);
                }
            }
        }

        [TestClass]
        public class NullSafeAnyMethod
        {
            [TestMethod]
            public void ReturnsTrueIfContainsElement()
            {
                IEnumerable<int> test = new int[] { 1, 2, 3 };
                Assert.IsTrue(test.NullSafeAny(x => x == 1));
            }

            [TestMethod]
            public void ReturnsFalseIfNotContainsElement()
            {
                IEnumerable<int> test = new int[] { 1, 2, 3 };
                Assert.IsFalse(test.NullSafeAny(x => x == 9));
            }

            [TestMethod]
            public void ReturnsFalseForNull()
            {
                IEnumerable<int> test = null;
                Assert.IsFalse(test.NullSafeAny(x => x == 1));
            }
        }

        [TestClass]
        public class NullSafeWhereMethod
        {
            [TestMethod]
            public void ReturnsEmptySequenceIfNull()
            {
                IEnumerable<int> test = null;
                IEnumerable<int> result = test.NullSafeWhere(x => x == 1);
                Assert.IsTrue(result.Count() == 0);
            }

            [TestMethod]
            public void ReturnsMatchingSequenceIfNotNull()
            {
                IEnumerable<int> test = new int[] { 1, 2, 3 };
                IEnumerable<int> result = test.NullSafeWhere(x => x >= 2);
                Assert.IsTrue(result.Count() == 2);
            }
        }

        [TestClass]
        public class NullSafeSelectMethod
        {
            [TestMethod]
            public void ReturnsEmptySequenceIfNull()
            {
                IEnumerable<int> test = null;
                IEnumerable<int> result = test.NullSafeSelect(x => x * 2);
                Assert.IsTrue(result.Count() == 0);
                Assert.AreEqual(0, result.Sum());
            }

            [TestMethod]
            public void ReturnsSequenceIfNotNull()
            {
                IEnumerable<int> test = new int[] { 1, 2, 3 };
                IEnumerable<int> result = test.NullSafeSelect(x => x * 2);
                Assert.IsTrue(result.Count() == 3);
                Assert.AreEqual(12, result.Sum());
            }
        }

        [TestClass]
        public class BatchMethod
        {
            public IEnumerable<int> BuildSequence()
            {
                for (int i = 1; i <= 100; i++)
                {
                    yield return i;
                }
            }

            [TestMethod]
            public void ExecutesSequenceInBatches()
            {
                IEnumerable<int> sequence = BuildSequence();
                int value = 1;
                sequence.BatchForEach(10, (batch) =>
                {
                    Assert.AreEqual(10, batch.Count());

                    foreach (int i in batch)
                    {
                        Assert.AreEqual(value, i);
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
                Assert.AreEqual(0, sequence.NullSafeCount());
            }

            [TestMethod]
            public void ReturnsCorrectCountForNonNullSequence()
            {
                IEnumerable<int> sequence = new int[] { 1, 2, 3 };
                Assert.AreEqual(3, sequence.NullSafeCount());
            }
        }
    }
}
