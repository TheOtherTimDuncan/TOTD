using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TOTD.Utility.Misc
{
    /// <summary>
    /// Base class for Enum-like class that includes a display name for each value
    /// </summary>
    /// <remarks>
    /// http://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/
    /// </remarks>
    public abstract class Enumeration<T> : IComparable
        where T : Enumeration<T>
    {
        private readonly int _value;
        private readonly string _displayName;

        protected Enumeration()
        {
        }

        protected Enumeration(int value, string displayName)
        {
            _value = value;
            _displayName = displayName;
        }

        public int Value
        {
            get
            {
                return _value;
            }
        }

        public string DisplayName
        {
            get
            {
                return _displayName;
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public static IEnumerable<T> GetAll()
        {
            Type type = typeof(T);
            IEnumerable<FieldInfo> fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (FieldInfo info in fields)
            {
                T instance = Activator.CreateInstance(type, nonPublic: true) as T;
                T locatedValue = info.GetValue(instance) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }

        public override bool Equals(object obj)
        {
            Enumeration<T> otherValue = obj as Enumeration<T>;

            if (otherValue == null)
            {
                return false;
            }

            bool typeMatches = GetType().Equals(obj.GetType());
            bool valueMatches = _value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static int AbsoluteDifference(Enumeration<T> firstValue, Enumeration<T> secondValue)
        {
            int absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
            return absoluteDifference;
        }

        public static T FromValue(int value)
        {
            T matchingItem = Parse<int>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static T FromDisplayName(string displayName)
        {
            T matchingItem = Parse<string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        private static T Parse<ValueType>(ValueType value, string description, Func<T, bool> predicate)
        {
            T matchingItem = GetAll().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                string message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public int CompareTo(object other)
        {
            return Value.CompareTo(((Enumeration<T>)other).Value);
        }
    }
}
