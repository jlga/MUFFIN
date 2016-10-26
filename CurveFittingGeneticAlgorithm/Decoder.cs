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
            double double0 = BitConverter.ToDouble(chromosome, 0*64);
            double double1 = BitConverter.ToDouble(chromosome, 1*64);

            double double2 = BitConverter.ToDouble(chromosome, 2*64);
            double double3 = BitConverter.ToDouble(chromosome, 3*64);

            double double4 = BitConverter.ToDouble(chromosome, 4*64);
            double double5 = BitConverter.ToDouble(chromosome, 5*64);

            double double6 = BitConverter.ToDouble(chromosome, 6*64);
            double double7 = BitConverter.ToDouble(chromosome, 7*64);

            double double8 = BitConverter.ToDouble(chromosome, 8 * 64);

            string result = double0 + "*(x+" + double1 + ")^4+" + double2 + "*(x+" + double3 + ")^3+" + double4 + "*(x+" + double5 + ")^2+" + double6 + "*(x+" + double7 + ")^1+" + double8;

            return result;
        }
    }
}
