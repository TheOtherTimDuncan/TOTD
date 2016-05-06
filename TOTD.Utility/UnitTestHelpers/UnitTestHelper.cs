using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TOTD.Utility.UnitTestHelpers
{
    public static class UnitTestHelper
    {
        private static Byte _testNumber = 0;
        private static Boolean _testBoolean = false;
        private static DateTime _testDate = new DateTime(2000, 1, 1, 1, 1, 1);
        private static Decimal _testDecimal = 1.1m;
        private static Double? _testDouble = 1.1f;
        private static TimeSpan testTimeSpan = TimeSpan.FromHours(1);

        public static IEnumerable<MethodInfo> GetAsyncVoidMethods(Assembly assembly)
        {
            return
                from t in assembly.GetTypes()
                from m in t.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
                where Attribute.GetCustomAttribute(m, typeof(AsyncStateMachineAttribute)) != null && m.ReturnType == typeof(void)
                select m;
        }

        public static string GetSolutionRoot()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            int pos = basePath.IndexOf("TestResults", StringComparison.OrdinalIgnoreCase);
            if (pos > 0)
            {
                string result = basePath.Substring(0, pos);
                return result;
            }
            else
            {
                pos = basePath.IndexOf("bin", StringComparison.OrdinalIgnoreCase);
                string projectPath = basePath.Substring(0, pos - 1);
                string result = Directory.GetParent(projectPath).FullName;
                return result;
            }
        }

        public static T SetEntityID<T>(this T source, Expression<Func<T, object>> selector) where T : class
        {
            LambdaExpression lambdaExpression = selector as LambdaExpression;
            MemberExpression memberExpression = (MemberExpression)((UnaryExpression)lambdaExpression.Body).Operand;
            PropertyInfo property = (PropertyInfo)memberExpression.Member;
            property.SetValue(source, GetNextNumber());
            return source;
        }

        /// <summary>
        /// Sets the writable properties of the given object to unique values. Numeric properties and DateTime properties have incrementing values.
        /// String values will be set to the name of the property
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ignoreProperties">The names of the properties to not fill with test data</param>
        public static T FillWithTestData<T>(this T source, params string[] ignoreProperties) where T : class
        {
            List<string> ignores = new List<string>();

            if (ignoreProperties != null)
            {
                ignores.AddRange(ignoreProperties);
            }

            IEnumerable<PropertyInfo> properties =
              from p in source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
              where p.GetSetMethod() != null && !ignores.Contains(p.Name)
              select p;

            foreach (PropertyInfo property in properties)
            {
                object value = null;
                Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                if (propertyType == typeof(string))
                {
                    value = property.Name;
                }
                else if (propertyType == typeof(DateTime))
                {
                    value = GetNextDateTime();
                }
                else if (propertyType == typeof(DateTimeOffset))
                {
                    value = new DateTimeOffset(GetNextDateTime());
                }
                else if (propertyType == typeof(Int16))
                {
                    value = Convert.ToInt16(GetNextNumber());
                }
                else if (propertyType == typeof(Int32))
                {
                    value = Convert.ToInt32(GetNextNumber());
                }
                else if (propertyType == typeof(Int64))
                {
                    value = Convert.ToInt64(GetNextNumber());
                }
                else if (propertyType == typeof(Byte))
                {
                    value = GetNextNumber();
                }
                else if (propertyType == typeof(Boolean))
                {
                    value = _testBoolean;
                    _testBoolean = !_testBoolean;
                }
                else if (propertyType == typeof(Decimal))
                {
                    value = _testDecimal;
                    _testDecimal *= 2;
                }
                else if (propertyType == typeof(Double))
                {
                    value = _testDouble;
                    _testDouble *= 2;
                }
                else if (propertyType == typeof(TimeSpan))
                {
                    value = testTimeSpan;
                    testTimeSpan = TimeSpan.FromHours(testTimeSpan.Hours + 1);
                }

                if (value != null)
                {
                    property.SetValue(source, value, null);
                }
            }

            return source;
        }

        public static byte GetNextNumber()
        {
            if (_testNumber == Byte.MaxValue)
            {
                _testNumber = 1;
            }
            else
            {
                _testNumber++;
            }
            return _testNumber;
        }

        public static DateTime GetNextDateTime()
        {
            _testDate = _testDate.AddYears(1).AddMonths(1).AddDays(1).AddHours(1).AddMinutes(1);
            return _testDate;
        }
    }
}
