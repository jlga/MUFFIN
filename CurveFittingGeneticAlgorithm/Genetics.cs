using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAF;
using GAF.Operators;

namespace CurveFittingGeneticAlgorithm
{
    class Genetics
    {
        const double crossoverProbability = 0.85;
        const double mutationProbability = 0.08;
        const int    elitismPercentage = 5;

        public Genetics()
        {
            var population = new Population(100, 576, false, false);

            //create the genetic operators 
            var elite = new Elite(elitismPercentage);

            var crossover = new Crossover(crossoverProbability, true)
            {
                CrossoverType = CrossoverType.SinglePoint
            };

            var mutation = new BinaryMutate(mutationProbability, true);

            //create the GA itself 
            var ga = new GeneticAlgorithm(population, EvaluateFitness);

            ga.OnGenerationComplete += ga_OnGenerationComplete;

            ga.Operators.Add(elite);
            ga.Operators.Add(crossover);
            ga.Operators.Add(mutation);

            //run the GA 
            ga.Run(TerminateAlgorithm);
        }

        public static bool TerminateAlgorithm(Population population, int currentGeneration, long currentEvaluation)
        {
            return currentGeneration > 1000;
        }

        public double EvaluateFitness(Chromosome chromosome)
        {
            return 0;
        }

        private void ga_OnGenerationComplete(object sender, GaEventArgs e)
        {

            //get the best solution 
            var chromosome = e.Population.GetTop(1)[0];

            //decode chromosome

            //get x and y from the solution 
            var x1 = Convert.ToInt32(chromosome.ToBinaryString(0, chromosome.Count / 2), 2);
            var y1 = Convert.ToInt32(chromosome.ToBinaryString(chromosome.Count / 2, chromosome.Count / 2), 2);

            //Adjust range to -100 to +100 
            var rangeConst = 200 / (System.Math.Pow(2, chromosome.Count / 2) - 1);
            var x = (x1 * rangeConst) - 100;
            var y = (y1 * rangeConst) - 100;

            //display the X, Y and fitness of the best chromosome in this generation 
            Console.WriteLine("x:{0} y:{1} Fitness{2}", x, y, e.Population.MaximumFitness);
        }
    }
}
