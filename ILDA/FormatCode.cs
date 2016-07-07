using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS.ILDA
{
    public enum FormatCode : byte
    {
        Format3DIndexedColour = 0,
        Format2DIndexedColour = 1,
        FormatColourPalette = 2,
        Format3DTrueColour = 4,
        Format2DTrueColour = 5
    }
}
