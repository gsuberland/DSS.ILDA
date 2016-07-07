using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSS.Extensions;

namespace DSS.ILDA
{
    public class ILDAHeader : IDSSSerialisable
    {
        const string ILDAIdentifier = @"ILDA";

        public string Identifier { get; private set; }
        public byte[] Reserved05 { get; private set; }
        public FormatCode Format { get; private set; }
        public string EntityName { get; private set; }
        public string CompanyName { get; private set; }
        public UInt16 NumberOfRecords { get; private set; }
        public UInt16 EntityNumber { get; private set; }
        public UInt16 TotalFrames { get; private set; }
        public byte ProjectorNumber { get; private set; }
        public byte Reserved32 { get; private set; }

        public ILDAHeader(BinaryReader stream)
        {
            this.Identifier = Encoding.ASCII.GetString(stream.ReadBytes(4));
            if (!this.Identifier.Equals(ILDAIdentifier))
                throw new InvalidDataException("ILDA identifier was not present.");
            this.Reserved05 = stream.ReadBytes(3);
            this.Format = (FormatCode)stream.ReadByte();
            if (!Enum.IsDefined(typeof(FormatCode), this.Format))
                throw new InvalidDataException(string.Format("Unknown format {0:d}", this.Format));
            this.EntityName = Encoding.ASCII.GetString(stream.ReadBytes(8)).Split('\0').FirstOrDefault() ?? "";
            this.CompanyName = Encoding.ASCII.GetString(stream.ReadBytes(8)).Split('\0').FirstOrDefault() ?? "";
            this.NumberOfRecords = stream.ReadUInt16BE();
            this.EntityNumber = stream.ReadUInt16BE();
            this.TotalFrames = stream.ReadUInt16BE();
            this.ProjectorNumber = stream.ReadByte();
            this.Reserved32 = stream.ReadByte();
        }

        private ILDAHeader(FormatCode format, string entityName, string companyName, UInt16 numberOfRecords, UInt16 entityNumber, UInt16 totalFrames, byte projectorNumber)
        {
            this.Identifier = ILDAIdentifier;
            this.Reserved05 = new byte[3];
            this.Format = format;
            this.EntityName = entityName;
            this.CompanyName = companyName;
            this.NumberOfRecords = numberOfRecords;
            this.EntityNumber = entityNumber;
            this.TotalFrames = totalFrames;
            this.ProjectorNumber = projectorNumber;
            this.Reserved32 = 0;
        }

        public static ILDAHeader Create(FormatCode format, string entityName, string companyName, UInt16 numberOfRecords, UInt16 entityNumber, UInt16 totalFrames, byte projectorNumber)
        {
            return new ILDAHeader(format, entityName, companyName, numberOfRecords, entityNumber, totalFrames, projectorNumber);
        }

        public void Serialise(BinaryWriter bw)
        {
            bw.Write(Encoding.ASCII.GetBytes(this.Identifier), 0, this.Identifier.Length);
            bw.Write(this.Reserved05, 0, 3);
            bw.Write((byte)this.Format);
            bw.Write(Encoding.ASCII.GetBytes((this.EntityName.Length > 8 ? this.EntityName.Substring(0, 8) : this.EntityName.PadRight(8, '\0'))));
            bw.Write(Encoding.ASCII.GetBytes((this.CompanyName.Length > 8 ? this.CompanyName.Substring(0, 8) : this.CompanyName.PadRight(8, '\0'))));
            bw.WriteUInt16BE(this.NumberOfRecords);
            bw.WriteUInt16BE(this.EntityNumber);
            bw.WriteUInt16BE(this.TotalFrames);
            bw.Write(this.ProjectorNumber);
            bw.Write(this.Reserved32);
        }
    }
}
