using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MBEPacker.MBE.CHNK
{
    public class CHNKRecord
    {

        //This isn't seen out of game, but this points to where the pointer to this chnk should go in one of the EXPA Records.
        public int Offset { get; set; }
        public int Size { get; set; }
        public string Text { get; set; }

        public CHNKRecord(FileStream fStream)
        {
            byte[] bytes4 = new byte[sizeof(int)];
            fStream.Read(bytes4, 0, sizeof(int));
            Offset = BitConverter.ToInt32(bytes4);
            fStream.Read(bytes4, 0, sizeof(int));
            Size = BitConverter.ToInt32(bytes4);
            byte[] bytesStr = new byte[Size];
            fStream.Read(bytesStr, 0, Size);
            Text = Encoding.UTF8.GetString(bytesStr).Trim('\0');
        }

        public CHNKRecord(string text, int offset)
        {
            Text = text;
            Offset = offset;
            Size = Multiple4Calculator.RoundUp2MultipleOf4(Text.Length);
        }

        public void WriteMBE(FileStream fStream)
        {
            fStream.Write(BitConverter.GetBytes(Offset), 0, 4);
            fStream.Write(BitConverter.GetBytes(Size), 0, 4);
            byte[] textBytes = new byte[Size];
            Buffer.BlockCopy(Encoding.UTF8.GetBytes(Text), 0, textBytes, 0, Text.Length);
            fStream.Write(textBytes, 0, Size);
        }
    }
}
