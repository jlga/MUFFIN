using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveFittingGeneticAlgorithm
{
    [Serializable]
    public class Equation
    {
        public double d0;
        public double d1;
        public double d2;
        public double d3;
        public double d4;
        public double d5;
        public double d6;
        public double d7;
        public double d8;

        public double fitness = 0;

        public Equation(double dd0, double dd1, double dd2, double dd3, double dd4, double dd5, double dd6, double dd7, double dd8)
        {
            d0 = dd0;
            d1 = dd1;
            d2 = dd2;
            d3 = dd3;
            d4 = dd4;
            d5 = dd5;
            d6 = dd6;
            d7 = dd7;
            d8 = dd8;
        }

        public Equation()
        {}

        override public string ToString()
        {
            return d0 + "*(x+" + d1 + ")^4+" + d2 + "*(x+" + d3 + ")^3+" + d4 + "*(x+" + d5 + ")^2+" + d6 + "*(x+" + d7 + ")^1+" + d8;
        }
    }
}
