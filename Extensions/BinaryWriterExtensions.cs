using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS.Extensions
{
    static class BinaryWriterExtensions
    {
        public static void WriteUInt16BE(this BinaryWriter writer, UInt16 value)
        {
            writer.Write((byte)((value & 0xFF00) >> 8));
            writer.Write((byte)(value & 0x00FF));
        }

        public static void WriteInt16BE(this BinaryWriter writer, Int16 value)
        {
            if (BitConverter.IsLittleEndian)
                writer.Write(BitConverter.GetBytes(value).Reverse().ToArray());
            else
                writer.Write(BitConverter.GetBytes(value));
        }
    }
}
