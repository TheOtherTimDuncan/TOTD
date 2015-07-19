using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TOTD.EntityFramework
{
    public class EntityTestHelper
    {
        public static void FillWithTestData(DbContext dbContext, object entity, params string[] ignoreProperties)
        {
            Int16 testInteger = 0;
            Int32 testLong = 0;
            Byte testByte = 0;
            Boolean testBoolean = false;
            DateTime testDate = new DateTime(2000, 1, 1, 1, 1, 1);
            Decimal testDecimal = 1.1m;
            Double? testDouble = 1.1f;
            TimeSpan testTimeSpan = TimeSpan.FromHours(1);

            IEnumerable<PropertyInfo> properties =
                from p in entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                where p.CanWrite && !ignoreProperties.Contains(p.Name)
                select p;

            foreach (PropertyInfo property in properties)
            {
                object value = null;
                Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                if (propertyType == typeof(string))
                {
                    string testString = property.Name;

                    EdmProperty edmProperty = GetEntityMetadataProperty(dbContext, entity.GetType(), property.Name);
                    if (edmProperty == null)
                    {
                        throw new Exception("Entity configuration not found for " + entity.GetType().Name + "." + property.Name);
                    }

                    int maxLength;
                    if (edmProperty.IsMaxLength)
                    {
                        maxLength = 4000;
                    }
                    else
                    {
                        if (edmProperty.MaxLength == null)
                        {
                            throw new Exception("MaxLength not configured for " + entity.GetType().Name + "." + property.Name);
                        }
                        maxLength = edmProperty.MaxLength.Value;
                    }

                    if (testString.Length > maxLength)
                    {
                        testString = testString.Substring(0, maxLength);
                    }
                    else
                    {
                        testString = testString + new string('*', maxLength - testString.Length);
                    }

                    value = testString;
                }
                else if (propertyType == typeof(DateTime))
                {
                    value = testDate;
                    testDate = testDate.AddYears(1).AddMonths(1).AddDays(1).AddHours(1).AddMinutes(1);
                }
                else if (propertyType == typeof(Int16))
                {
                    value = testInteger;
                    testInteger++;
                    testLong++;
                    testByte++;
                }
                else if (propertyType == typeof(Int32))
                {
                    value = testLong;
                    testInteger++;
                    testLong++;
                    testByte++;
                }
                else if (propertyType == typeof(Byte))
                {
                    value = testByte;
                    testInteger++;
                    testLong++;
                    testByte++;
                }
                else if (propertyType == typeof(Boolean))
                {
                    value = testBoolean;
                    testBoolean = !testBoolean;
                }
                else if (propertyType == typeof(Decimal))
                {
                    value = testDecimal;
                    testDecimal *= 2;
                }
                else if (propertyType == typeof(Double))
                {
                    value = testDouble;
                    testDouble *= 2;
                }
                else if (propertyType == typeof(TimeSpan))
                {
                    value = testTimeSpan;
                    testTimeSpan = TimeSpan.FromHours(testTimeSpan.Hours + 1);
                }

                if (value != null)
                {
                    property.SetValue(entity, value, null);
                }
            }
        }

        public static EdmProperty GetEntityMetadataProperty<T>(DbContext dbContext, Expression<Func<T, object>> selector)
        {
            LambdaExpression lambdaExpression = selector as LambdaExpression;
            if (lambdaExpression == null)
            {
                throw new Exception("Expression is not a lambda expression");
            }

            MemberExpression memberExpression;
            switch (lambdaExpression.Body.NodeType)
            {
                case ExpressionType.Convert:
                    memberExpression = (MemberExpression)((UnaryExpression)lambdaExpression.Body).Operand;
                    break;

                case ExpressionType.MemberAccess:
                    memberExpression = (MemberExpression)lambdaExpression.Body;
                    break;

                default:
                    throw new Exception("Unknown expression type");
            }

            return GetEntityMetadataProperty(dbContext, typeof(T), memberExpression.Member.Name);
        }

        public static EdmProperty GetEntityMetadataProperty(DbContext dbContext, Type entityType, string propertyName)
        {
            MetadataWorkspace metadata = ((IObjectContextAdapter)dbContext).ObjectContext.MetadataWorkspace;

            EdmProperty edmProperty = metadata
                .GetItems(DataSpace.CSpace)
                .Where(x => x.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                .OfType<EntityType>()
                .Where(x => x.Name == entityType.Name)
                .Single()
                    .DeclaredMembers
                    .OfType<EdmProperty>()
                    .Where(x => x.Name == propertyName)
                    .Single();

            return edmProperty;
        }
    }
}
