using System;
using System.Collections.Generic;

namespace TODT.Test.EntityFramework
{
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

        public string AliasedColumn
        {
            get;
            set;
        }

        public const int AliasedColumnLength = 50;
    }
}
