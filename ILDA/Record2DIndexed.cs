using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSS.Extensions;

namespace DSS.ILDA
{
    public class Record2DIndexed : Record2DBase, IIndexedColour, IDSSSerialisable
    {
        public byte ColourIndex { get; set; }

        public Record2DIndexed(BinaryReader stream) : base(stream)
        {
            this.ColourIndex = stream.ReadByte();
        }

        public Record2DIndexed(Int16 x, Int16 y, bool blanking, bool lastPoint, byte colourIndex) : base(x, y)
        {
            this.SetStatus(lastPoint, blanking);
            this.ColourIndex = colourIndex;
        }

        public void Serialise(BinaryWriter bw)
        {
            bw.WriteInt16BE(this.X);
            bw.WriteInt16BE(this.Y);
            bw.Write(this.StatusCode);
            bw.Write(this.ColourIndex);
        }
    }
}
