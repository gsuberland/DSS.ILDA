using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS.ILDA
{
    public class CoordinateRecord : DataRecord
    {
        public byte StatusCode { get; set; }

        public bool LastPoint
        {
            get
            {
                return (this.StatusCode & 0x80) == 0x80;
            }
        }

        public bool Blanking
        {
            get
            {
                return (this.StatusCode & 0x40) == 0x40;
            }
        }

        protected void SetStatus(bool lastPoint, bool blanking)
        {
            this.StatusCode = (byte)((lastPoint ? 0x80 : 0x00) | (blanking ? 0x40 : 0x00));
        }
    }
}
