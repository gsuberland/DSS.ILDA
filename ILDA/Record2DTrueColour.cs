using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSS.Extensions;

namespace DSS.ILDA
{
    public class Record2DTrueColour : Record2DBase, ITrueColour, IDSSSerialisable
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public Record2DTrueColour(BinaryReader stream) : base(stream)
        {
            this.Blue = stream.ReadByte();
            this.Green = stream.ReadByte();
            this.Red = stream.ReadByte();
        }

        public Record2DTrueColour(Int16 x, Int16 y, bool blanking, bool lastPoint, byte r, byte g, byte b) : base(x, y)
        {
            this.SetStatus(lastPoint, blanking);
            this.Red = r;
            this.Green = g;
            this.Blue = b;
        }

        public void Serialise(BinaryWriter bw)
        {
            bw.WriteInt16BE(this.X);
            bw.WriteInt16BE(this.Y);
            bw.Write(this.StatusCode);
            bw.Write(this.Blue);
            bw.Write(this.Green);
            bw.Write(this.Red);
        }
    }
}
