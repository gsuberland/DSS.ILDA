using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSS.Extensions;

namespace DSS.ILDA
{
    public class Record2DBase : CoordinateRecord
    {
        public Int16 X { get; set; }
        public Int16 Y { get; set; }

        protected Record2DBase(BinaryReader stream)
        {
            this.X = stream.ReadInt16BE();
            this.Y = stream.ReadInt16BE();
            this.StatusCode = stream.ReadByte();
        }

        protected Record2DBase(Int16 x, Int16 y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
