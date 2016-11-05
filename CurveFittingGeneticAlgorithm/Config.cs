using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveFittingGeneticAlgorithm
{
    public static class Config
    {
        public static SmallEquation target = new SmallEquation(0.5, 0, -100, 0, 0);

        public const double     crossoverProbability        =   0.85;
        public const double     mutationProbability         =   0.08;
        public const int        elitismPercentage           =   1;
        public const int        populationSize              =   1000;


    }
}
