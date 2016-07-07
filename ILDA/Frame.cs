using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS.ILDA
{
    public class Frame : IDSSSerialisable
    {
        public ILDAHeader Header { get; private set; }
        private List<CoordinateRecord> _records;
        public IReadOnlyCollection<CoordinateRecord> Records
        {
            get
            {
                return _records.AsReadOnly();
            }
        }

        public Frame(ILDAHeader header, IEnumerable<CoordinateRecord> records)
        {
            this.Header = header;
            this._records = new List<CoordinateRecord>(records);
        }

        public void Serialise(BinaryWriter bw)
        {
            this.Header.Serialise(bw);
            foreach (IDSSSerialisable record in Records)
            {
                // we don't know the type at compile-time so we invoke the child class method at runtime
                /*record.GetType().InvokeMember(
                    "Serialise",
                    System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance,
                    null,
                    record,
                    new object[] { bw });*/
                record.Serialise(bw);
            }
        }
    }
}
