using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveFittingGeneticAlgorithm
{
    class Decoder
    {
        public static string decode(byte[] chromosome)
        {
            double double0 = BitConverter.ToDouble(chromosome, 0*8);
            double double1 = BitConverter.ToDouble(chromosome, 1*8);

            double double2 = BitConverter.ToDouble(chromosome, 2*8);
            double double3 = BitConverter.ToDouble(chromosome, 3*8);

            double double4 = BitConverter.ToDouble(chromosome, 4*8);
            double double5 = BitConverter.ToDouble(chromosome, 5*8);

            double double6 = BitConverter.ToDouble(chromosome, 6*8);
            double double7 = BitConverter.ToDouble(chromosome, 7*8);

            double double8 = BitConverter.ToDouble(chromosome, 8 * 8);

            string result = double0 + "*(x+" + double1 + ")^4+" + double2 + "*(x+" + double3 + ")^3+" + double4 + "*(x+" + double5 + ")^2+" + double6 + "*(x+" + double7 + ")^1+" + double8;

            return result;
        }
    }
}
