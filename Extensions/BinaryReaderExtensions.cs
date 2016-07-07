using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS.Extensions
{
    static class BinaryReaderExtensions
    {
        public static UInt16 ReadUInt16BE(this BinaryReader reader)
        {
            return (UInt16)((reader.ReadByte() * 256) + reader.ReadByte());
        }

        public static Int16 ReadInt16BE(this BinaryReader reader)
        {
            byte H = reader.ReadByte();
            byte L = reader.ReadByte();
            if (BitConverter.IsLittleEndian)
                return BitConverter.ToInt16(new byte[] { L, H }, 0);
            else
                return BitConverter.ToInt16(new byte[] { H, L }, 0);
        }
    }
}
