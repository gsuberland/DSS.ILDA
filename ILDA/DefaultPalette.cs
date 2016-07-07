using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS.ILDA
{
    public static class DefaultPalette
    {
        public static List<RecordColourPalette> GetDefaultPalette()
        {
            var p = new List<RecordColourPalette>();

            // 0-16
            for (int g = 0; g <= 256; g += 16)
                p.Add(new RecordColourPalette(255, (byte)Math.Min(255, g), 0));

            // 17-24
            for (int r = 224; r >= 0; r -= 32)
                p.Add(new RecordColourPalette((byte)r, 255, 0));

            /* 25 */ p.Add(new RecordColourPalette(0, 255, 36));
            /* 26 */ p.Add(new RecordColourPalette(0, 255, 73));
            /* 27 */ p.Add(new RecordColourPalette(0, 255, 109));
            /* 28 */ p.Add(new RecordColourPalette(0, 255, 146));
            /* 29 */ p.Add(new RecordColourPalette(0, 255, 182));
            /* 30 */ p.Add(new RecordColourPalette(0, 255, 219));
            /* 31 */ p.Add(new RecordColourPalette(0, 255, 255));

            /* 32 */ p.Add(new RecordColourPalette(0, 227, 255));
            /* 33 */ p.Add(new RecordColourPalette(0, 198, 255));
            /* 34 */ p.Add(new RecordColourPalette(0, 170, 255));
            /* 35 */ p.Add(new RecordColourPalette(0, 142, 255));
            /* 36 */ p.Add(new RecordColourPalette(0, 113, 255));
            /* 37 */ p.Add(new RecordColourPalette(0, 85, 255));
            /* 38 */ p.Add(new RecordColourPalette(0, 56, 255));
            /* 39 */ p.Add(new RecordColourPalette(0, 28, 255));
            /* 40 */ p.Add(new RecordColourPalette(0, 0, 255));

            // 41-48
            for (int r = 32; r <= 256; r += 32)
                p.Add(new RecordColourPalette((byte)Math.Min(255, r), 0, 255));

            // 49-56
            for (int g = 32; g <= 256; g += 32)
                p.Add(new RecordColourPalette(255, (byte)Math.Min(255, g), 255));

            // 57-63
            for (int b = 224; b >= 32; b -= 32)
                p.Add(new RecordColourPalette(255, 255, (byte)Math.Min(255, b)));

            return p;
        }
    }
}
