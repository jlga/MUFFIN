using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jace;
using System.Windows.Forms;

namespace CurveFittingGeneticAlgorithm
{
    static class Utils
    {
        public static double calculateError(Dictionary<int,double> original, Dictionary<int, double> fake)
        {
            double result = 0;
            for(int i = -original.Count/2; i<original.Count/2; i++)
            {
                result += Math.Pow(original[i]-fake[i],2);
               
            }
            return result;
        }

        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public static Dictionary<int,double> convertToDictionary(string equation, int size)
        {
            Dictionary<int, double> output = new Dictionary<int, double>();
            for (int i =-size; i<=size; i++)
            {
                output.Add(i, calculateY(equation, i));
            }
            return output;
        }

        public static double calculateY(string equation, double x)
        {
            CalculationEngine engine = new CalculationEngine();
            Dictionary<string, double> variables = new Dictionary<string, double>();
            variables.Add("x", x);
            double result = engine.Calculate(equation, variables);

            return result;
        }

        public static double ConvertRange(double originalStart, double originalEnd, double newStart, double newEnd, double value)
        {
            value = value.Clamp(originalStart, originalEnd); ;
            double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            if(value > originalEnd)
            {
                return newEnd;
            }
            return newStart + ((value - originalStart) * scale);
        }

        public static void UIThread(this Control @this, Action code)
        {
            if (@this.InvokeRequired)
            {
                @this.BeginInvoke(code);
            }
            else
            {
                code.Invoke();
            }
        }
    }
}
