using MBEPacker.MBE;

namespace MBEPacker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 3) { Help(); return; }
            if (args[0] != "d" && args[0] != "c") { Help(); return; }
            if (args[0] == "d")
            {
                MBEFile mbeFile = new MBEFile(args[1], false);
                mbeFile.WriteJson(args[2]);
            }
            if ((args[0] == "c"))
            {
                MBEFile mbeFile = new MBEFile(args[1], true);
                mbeFile.WriteMBE(args[2]);
            }
        }

        public static void Help()
        {
            Console.WriteLine("This utility is designed to pack and unpack .mbe files from Hundred Line.");
            Console.WriteLine("Use the following command line arguments to turn a mbe file into a json file:");
            Console.WriteLine("d [source mbe filepath] [destination json filepath]");
            Console.WriteLine("And use this to turn a json file back into a mbe file:");
            Console.WriteLine("c [source json filepath] [destination mbe filepath]");
        }

    }
}
