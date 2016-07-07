using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS.ILDA
{
    interface IDSSSerialisable
    {
        void Serialise(BinaryWriter bw);
    }
}
