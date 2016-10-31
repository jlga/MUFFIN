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
            double double0 = Math.Round(BitConverter.ToDouble(chromosome, 0*8).Clamp(-100000,100000), 4);
            double double1 = Math.Round(BitConverter.ToDouble(chromosome, 1*8).Clamp(-100000, 100000), 4);

            double double2 = Math.Round(BitConverter.ToDouble(chromosome, 2*8).Clamp(-100000, 100000), 4);
            double double3 = Math.Round(BitConverter.ToDouble(chromosome, 3*8).Clamp(-100000, 100000), 4);

            double double4 = Math.Round(BitConverter.ToDouble(chromosome, 4*8).Clamp(-100000, 100000), 4);
            double double5 = Math.Round(BitConverter.ToDouble(chromosome, 5*8).Clamp(-100000, 100000), 4);

            double double6 = Math.Round(BitConverter.ToDouble(chromosome, 6*8).Clamp(-100000, 100000), 4);
            double double7 = Math.Round(BitConverter.ToDouble(chromosome, 7*8).Clamp(-100000, 100000), 4);

            double double8 = Math.Round(BitConverter.ToDouble(chromosome, 8*8).Clamp(-100000, 100000), 4);
            string res = double0.ToString();
            string result = double0 + "*(x+" + double1 + ")^4+" + double2 + "*(x+" + double3 + ")^3+" + double4 + "*(x+" + double5 + ")^2+" + double6 + "*(x+" + double7 + ")^1+" + double8;

            return result;
        }
    }
}
