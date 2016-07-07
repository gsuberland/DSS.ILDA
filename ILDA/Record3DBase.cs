using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSS.Extensions;

namespace DSS.ILDA
{
    public class Record3DBase : CoordinateRecord
    {
        public Int16 X { get; set; }
        public Int16 Y { get; set; }
        public Int16 Z { get; set; }

        protected Record3DBase(BinaryReader stream)
        {
            this.X = stream.ReadInt16BE();
            this.Y = stream.ReadInt16BE();
            this.Z = stream.ReadInt16BE();
            this.StatusCode = stream.ReadByte();
        }
        protected Record3DBase(Int16 x, Int16 y, Int16 z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

    }
}
