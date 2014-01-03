using System;
using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.MemoryEditor
{
    public class SysTypes : Dictionary<Type, SysType>
    {
        SysTypes() {}

        private static readonly SysTypes Table = new SysTypes
                                                 {
                                                     {typeof(byte), SysType.Byte},
                                                     {typeof(sbyte), SysType.SByte},
                                                     {typeof(char), SysType.Char},
                                                     {typeof(short), SysType.Short},
                                                     {typeof(ushort), SysType.UShort},
                                                     {typeof(int), SysType.Int},
                                                     {typeof(uint), SysType.UInt},
                                                     {typeof(long), SysType.Long},
                                                     {typeof(ulong), SysType.ULong},
                                                     {typeof(float), SysType.Float},
                                                     {typeof(double), SysType.Double},
                                                     {typeof(string), SysType.String},
                                                     {typeof(byte[]), SysType.ByteArray},
                                                 };

        public static SysType TypeOf(object obj)
        {
            if (obj != null)
            {
                Type type = obj.GetType();
                if (Table.ContainsKey(type))
                {
                    return Table[type];
                }
            }
            return SysType.Unknown;
        }

        public static int GetObjectSize(object obj)
        {
            if (obj != null)
            {
                switch (TypeOf(obj))
                {
                    case SysType.Byte:
                    case SysType.SByte:
                        return sizeof (byte);
                    case SysType.Char:
                        return sizeof(char);
                    case SysType.Short:
                    case SysType.UShort:
                        return sizeof(short);
                    case SysType.Int:
                    case SysType.UInt:
                        return sizeof(int);
                    case SysType.Long:
                    case SysType.ULong:
                        return sizeof(long);
                    case SysType.Float:
                        return sizeof(float);
                    case SysType.Double:
                        return sizeof(double);
                    case SysType.String:
                        return ((string)obj).Length;
                    case SysType.ByteArray:
                        return ((byte[])obj).Length;
                }
            }
            return 0;
        }
    }
}