using MBEPacker.MBE.CHNK;
using MBEPacker.MBE.EXPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MBEPacker.MBE
{
    public class MBEFile
    {

        public EXPASection EXPA { get; set; }
        public CHNKSection CHNK { get; set; }

        public MBEFile(string filepath, bool compile)
        {
            if (compile)
            {
                string jsonString = File.ReadAllText(filepath, Encoding.UTF8);
                JsonNode? jsonNode = JsonNode.Parse(jsonString);
                if (jsonNode == null) throw new Exception("Cannot parse json file.");
                JsonObject json = jsonNode.AsObject();
                EXPA = new EXPASection(json);
                CHNK = new CHNKSection(EXPA);
            } else
            {
                using (FileStream fStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    EXPA = new EXPASection(fStream);
                    CHNK = new CHNKSection(fStream);
                    EXPA.FormatEXPARecords(CHNK);
                }
            }
        }

        public void WriteJson(string filepath)
        {
            JsonObject jsonFile = EXPA.GetJson();
            string jsonString = jsonFile.ToJsonString();
            File.WriteAllText(filepath, jsonString, Encoding.UTF8);
        }

        public void WriteMBE(string filepath)
        {
            using (FileStream fStream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                EXPA.WriteMBE(fStream);
                CHNK.WriteMBE(fStream);
            }
        }

    }
}
