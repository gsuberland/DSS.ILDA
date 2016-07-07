using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS.ILDA
{
    public class RecordColourPalette : DataRecord, IDSSSerialisable
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public RecordColourPalette(BinaryReader stream)
        {
            this.Red = stream.ReadByte();
            this.Green = stream.ReadByte();
            this.Blue = stream.ReadByte();
        }

        public RecordColourPalette(byte r, byte g, byte b)
        {
            this.Red = r;
            this.Green = g;
            this.Blue = b;
        }

        public void Serialise(BinaryWriter bw)
        {
            bw.Write(this.Red);
            bw.Write(this.Green);
            bw.Write(this.Blue);
        }
    }
}
