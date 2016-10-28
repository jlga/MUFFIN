using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveFittingGeneticAlgorithm
{
    static class CurveMath
    {
        static double calculateError(Dictionary<int,double> original, Dictionary<int, double> fake)
        {
            double result = 0;
            for(int i = -original.Count/2; i<original.Count/2; i++)
            {
                result += Math.Pow(original[i]-fake[i],2);
               
            }
            return 0;
        }

        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
    }
}
