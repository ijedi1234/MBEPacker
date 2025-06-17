using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MBEPacker.MBE.CHNK
{
    public class CHNKHeader
    {

        public string MagicNumber { get; set; } = "CHNK";
        public int NumRecords { get; set; }

        public CHNKHeader(FileStream fStream)
        {
            byte[] bytes4 = new byte[sizeof(int)];
            fStream.Read(bytes4, 0, sizeof(int));
            MagicNumber = Encoding.UTF8.GetString(bytes4);
            fStream.Read(bytes4, 0, sizeof(int));
            NumRecords = BitConverter.ToInt32(bytes4);
        }

        public CHNKHeader(int numRecords)
        {
            NumRecords = numRecords;
        }

        public int GetSize() { return 0x8; }

        public void WriteMBE(FileStream fStream)
        {
            fStream.Write(Encoding.UTF8.GetBytes(MagicNumber), 0, 4);
            fStream.Write(BitConverter.GetBytes(NumRecords), 0, 4);
        }
    }
}
