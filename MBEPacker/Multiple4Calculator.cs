using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBEPacker
{
    public class Multiple4Calculator
    {

        //Round to next multiple of four, while leaving space for 2 mull terminators.
        public static int RoundUp2MultipleOf4(int number, int padding)
        {
            number += padding;
            while (number % 4 != 0) number++;
            return number;
        }

    }
}
