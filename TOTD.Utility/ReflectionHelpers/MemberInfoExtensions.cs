using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TOTD.Utility.ExceptionHelpers;

namespace TOTD.Utility.ReflectionHelpers
{
    public static class MemberInfoExtensions
    {
        /// <summary>
        /// Returns the specified attribute from the source property
        /// </summary>
        /// <typeparam name="AttributeType"></typeparam>
        /// <param name="member"></param>
        /// <returns>Returns the attribute if found; otherwise returns null</returns>
        public static AttributeType GetAttribute<AttributeType>(this MemberInfo member)
            where AttributeType : Attribute
        {
            ThrowIf.Argument.IsNull(member, "member");

            object[] attributes = member.GetCustomAttributes(typeof(AttributeType), true);
            if (attributes != null && attributes.Length > 0)
            {
                return (AttributeType)attributes[0];
            }
            else
            {
                return null;
            }
        }
    }
}
