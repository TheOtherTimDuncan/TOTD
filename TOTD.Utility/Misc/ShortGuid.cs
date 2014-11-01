using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOTD.Utility.Misc
{
    // Thanks to:
    // http://madskristensen.net/post/a-shorter-and-url-friendly-guid
    // http://www.singular.co.nz/blog/archive/2007/12/20/shortguid-a-shorter-and-url-friendly-guid-in-c-sharp.aspx
    public struct ShortGuid
    {
        public static readonly ShortGuid Empty = new ShortGuid(Guid.Empty);

        private Guid _guid;
        private string _value;

        public ShortGuid(string value)
        {
            _value = value;
            _guid = Decode(value);
        }

        public ShortGuid(Guid guid)
        {
            _value = Encode(guid);
            _guid = guid;
        }

        public Guid Guid
        {
            get
            {
                return _guid;
            }
            set
            {
                if (value != _guid)
                {
                    _guid = value;
                    _value = Encode(value);
                }
            }
        }

        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value != _value)
                {
                    _value = value;
                    _guid = Decode(value);
                }
            }
        }

        public override string ToString()
        {
            return _value;
        }

        public override bool Equals(object obj)
        {
            if (obj is ShortGuid)
            {
                return _guid.Equals(((ShortGuid)obj)._guid);
            }

            if (obj is Guid)
            {
                return _guid.Equals((Guid)obj);
            }

            if (obj is string)
            {
                return _guid.Equals(((ShortGuid)obj)._guid);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _guid.GetHashCode();
        }

        public static ShortGuid NewGuid()
        {
            return new ShortGuid(Guid.NewGuid());
        }

        public static string Encode(string guidText)
        {
            Guid guid = new Guid(guidText);
            return Encode(guid);
        }

        public static string Encode(Guid guid)
        {
            string enc = Convert.ToBase64String(guid.ToByteArray());
            enc = enc.Replace("/", "_");
            enc = enc.Replace("+", "-");
            return enc.Substring(0, 22);
        }

        public static Guid Decode(string encoded)
        {
            encoded = encoded.Replace("_", "/");
            encoded = encoded.Replace("-", "+");
            byte[] buffer = Convert.FromBase64String(encoded + "==");
            return new Guid(buffer);
        }

        public static bool operator ==(ShortGuid x, ShortGuid y)
        {
            if ((object)x == null)
            {
                return (object)y == null;
            }

            return x._guid == y._guid;
        }

        public static bool operator !=(ShortGuid x, ShortGuid y)
        {
            return !(x == y);
        }

        public static implicit operator string(ShortGuid shortGuid)
        {
            return shortGuid._value;
        }

        public static implicit operator Guid(ShortGuid shortGuid)
        {
            return shortGuid._guid;
        }

        public static implicit operator ShortGuid(string shortGuid)
        {
            return new ShortGuid(shortGuid);
        }

        public static implicit operator ShortGuid(Guid guid)
        {
            return new ShortGuid(guid);
        }
    }
}
