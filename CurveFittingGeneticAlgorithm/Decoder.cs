using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveFittingGeneticAlgorithm
{
    class Decoder
    {
        public static string decodeToString(byte[] chromosome)
        {
            double double0 = Math.Round(BitConverter.ToDouble(chromosome, 0 * 8).Clamp(-100000, 100000), 4);
            double double1 = Math.Round(BitConverter.ToDouble(chromosome, 1 * 8).Clamp(-100000, 100000), 4);

            double double2 = Math.Round(BitConverter.ToDouble(chromosome, 2 * 8).Clamp(-100000, 100000), 4);
            double double3 = Math.Round(BitConverter.ToDouble(chromosome, 3 * 8).Clamp(-100000, 100000), 4);

            double double4 = Math.Round(BitConverter.ToDouble(chromosome, 4 * 8).Clamp(-100000, 100000), 4);
            double double5 = Math.Round(BitConverter.ToDouble(chromosome, 5 * 8).Clamp(-100000, 100000), 4);

            double double6 = Math.Round(BitConverter.ToDouble(chromosome, 6 * 8).Clamp(-100000, 100000), 4);
            double double7 = Math.Round(BitConverter.ToDouble(chromosome, 7 * 8).Clamp(-100000, 100000), 4);

            double double8 = Math.Round(BitConverter.ToDouble(chromosome, 8 * 8).Clamp(-100000, 100000), 4);
            string res = double0.ToString();
            string result = double0 + "*(x+" + double1 + ")^4+" + double2 + "*(x+" + double3 + ")^3+" + double4 + "*(x+" + double5 + ")^2+" + double6 + "*(x+" + double7 + ")^1+" + double8;

            return result;
        }

        public static Equation decodeToEquation(byte[] chromosome)
        {
            double double0 = Math.Round(BitConverter.ToDouble(chromosome, 0 * 8).Clamp(-100000, 100000), 4);
            double double1 = Math.Round(BitConverter.ToDouble(chromosome, 1 * 8).Clamp(-100000, 100000), 4);

            double double2 = Math.Round(BitConverter.ToDouble(chromosome, 2 * 8).Clamp(-100000, 100000), 4);
            double double3 = Math.Round(BitConverter.ToDouble(chromosome, 3 * 8).Clamp(-100000, 100000), 4);

            double double4 = Math.Round(BitConverter.ToDouble(chromosome, 4 * 8).Clamp(-100000, 100000), 4);
            double double5 = Math.Round(BitConverter.ToDouble(chromosome, 5 * 8).Clamp(-100000, 100000), 4);

            double double6 = Math.Round(BitConverter.ToDouble(chromosome, 6 * 8).Clamp(-100000, 100000), 4);
            double double7 = Math.Round(BitConverter.ToDouble(chromosome, 7 * 8).Clamp(-100000, 100000), 4);

            double double8 = Math.Round(BitConverter.ToDouble(chromosome, 8 * 8).Clamp(-100000, 100000), 4);
            string res = double0.ToString();
            string result = double0 + "*(x+" + double1 + ")^4+" + double2 + "*(x+" + double3 + ")^3+" + double4 + "*(x+" + double5 + ")^2+" + double6 + "*(x+" + double7 + ")^1+" + double8;



            return new Equation(double0, double1, double2, double3, double4, double5, double6, double7, double8);
        }

        public static SmallEquation decodeToSmallEquation(byte[] chromosome)
        {
            double double0 = Math.Round(BitConverter.ToDouble(chromosome, 0 * 8).Clamp(-100000, 100000), 4);
            double double1 = Math.Round(BitConverter.ToDouble(chromosome, 1 * 8).Clamp(-100000, 100000), 4);

            double double2 = Math.Round(BitConverter.ToDouble(chromosome, 2 * 8).Clamp(-100000, 100000), 4);
            double double3 = Math.Round(BitConverter.ToDouble(chromosome, 3 * 8).Clamp(-100000, 100000), 4);

            double double4 = Math.Round(BitConverter.ToDouble(chromosome, 4 * 8).Clamp(-100000, 100000), 4);

            string res = double0.ToString();



            return new SmallEquation(double0, double1, double2, double3, double4);
        }

        public static byte[] stringToByteArray(String input)
        {
            if (input.Length % 8 != 0)
            {
                throw new Exception("Input String must be a multiple of 8");
            }
            else
            {
                byte[] b = new byte[input.Length / 8];
                char[] inchar = input.ToCharArray();
                for (int i = 0; i < inchar.Length / 8; i++)
                {
                    b[i] = stringToByte(input.Substring(i * 8, 8));
                }
                return b;
            }
        }

        public static void testBit()
        {
            string s = "00000001";
            Byte[] b = stringToByteArray(s);
            Console.WriteLine(b);
        }

        public static byte stringToByte(String input)
        {
            byte b = new byte();
            if (input.Length > 8 || input.Length < 8)
            {
                throw new Exception("Input String is not a byte");
            }
            else
            {
                char[] inchar = input.ToCharArray();
                for (int i = 0; i < inchar.Length; i++)
                {
                    if (inchar[i] == '1')
                    {
                        b = setBit(b, 7-i, true);
                    }
                }
                return b;
            }
        }

        public static byte setBit(byte b, int BitNumber)
        {
            //Kleine Fehlerbehandlung
            if (BitNumber < 8 && BitNumber > -1)
            {
                return (byte)(b | (byte)(0x01 << BitNumber));
            }
            else
            {
                throw new InvalidOperationException(
                "Der Wert für BitNumber " + BitNumber.ToString() + " war nicht im zulässigen Bereich! (BitNumber = (min)0 - (max)7)");
            }
        }

        public static byte setBit(byte aByte, int pos, bool value)
        {
            if (value)
            {
                //left-shift 1, then bitwise OR
                aByte = (byte)(aByte | (1 << pos));
            }
            else
            {
                //left-shift 1, then take complement, then bitwise AND
                aByte = (byte)(aByte & ~(1 << pos));
            }
            return aByte;
        }
    }
}
