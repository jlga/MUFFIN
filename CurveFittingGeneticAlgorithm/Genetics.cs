using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAF;
using GAF.Operators;

namespace CurveFittingGeneticAlgorithm
{
    class Genetics
    {
        const double crossoverProbability = 0.85;
        const double mutationProbability = 0.2;
        const int    elitismPercentage = 2;
        const int    populationSize = 50;

        double lastGenFitness = 0;

        GeneticAlgorithm ga;
        Main form;
        Func<string,int,string,bool> pop;

        public Genetics(Main form1, Func<string, int, string, bool> populateM)
        {
            pop = populateM;
            form1.Text = "test";
            form = form1;

            var population = new Population(populationSize, 576, false, false);

            //create the genetic operators 
            var elite = new Elite(elitismPercentage);

            var crossover = new Crossover(crossoverProbability, true)
            {
                CrossoverType = CrossoverType.SinglePoint
            };

            var mutation = new BinaryMutate(mutationProbability, true);

            //create the GA itself 
            ga = new GeneticAlgorithm(population, EvaluateFitness);

            ga.OnGenerationComplete += ga_OnGenerationComplete;

            ga.Operators.Add(elite);
            ga.Operators.Add(crossover);
            ga.Operators.Add(mutation);

            //run the GA 
            //ga.Run(TerminateAlgorithm);
        }

        public void run()
        {
            ga.Run(TerminateAlgorithm);
        }

        public static bool TerminateAlgorithm(Population population, int currentGeneration, long currentEvaluation)
        {
            return population.MaximumFitness == 1;
        }

        public double EvaluateFitness(Chromosome chromosome)
        {
            int numOfBytes = chromosome.ToBinaryString().Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for(int i=0; i<numOfBytes; i++)
            {
                bytes[i] = Convert.ToByte(chromosome.ToBinaryString().Substring(8 * i, 8), 2);
            }
            Dictionary<int, double> dicOG = Utils.convertToDictionary("x^2", 20);
            Dictionary<int, double> dicFK = Utils.convertToDictionary(Decoder.decode(bytes), 20);
            double error = Utils.calculateError(dicOG, dicFK);
            if(error != 0)
            {
                if(1/error < 0 || 1/error > 1)
                {
                    throw new Exception(Decoder.decode(bytes) + " " + error);
                }
                return 1 / error;
            }
            else
            {
                if (1 / error < 0 || 1 / error > 1)
                {
                    throw new Exception(Decoder.decode(bytes) + " " + error);
                }
                throw new Exception(Decoder.decode(bytes) + " " + error);
                return 1;
            }
            //double converted = Utils.ConvertRange(0, 1E40, 0, 1, error).Clamp(0, 1);
            //double fitness = 1 - converted;
            //Console.WriteLine(fitness);
            /*if(fitness==1)
            {
                throw new Exception(Decoder.decode(bytes) + " " + error);
            }
            return fitness.Clamp(0,1);*/
        }

        private void ga_OnGenerationComplete(object sender, GaEventArgs e)
        {
            Console.WriteLine("---Generation Complete---");
            Console.WriteLine("Gen: " + e.Generation);
            
            Console.WriteLine("Fit: " + e.Population.MaximumFitness + " " + (e.Population.MaximumFitness-lastGenFitness));
            lastGenFitness = e.Population.MaximumFitness;
            //Console.WriteLine("Generation Complete " + e.Generation + " " + EvaluateFitness(e.Population.GetTop(1)[0]));
            //pop("x^4",20,"BestFit");
            //get the best solution 
            var chromosome = e.Population.GetTop(1)[0];

            int numOfBytes = chromosome.ToBinaryString().Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; i++)
            {
                bytes[i] = Convert.ToByte(chromosome.ToBinaryString().Substring(8 * i, 8), 2);
            }
            Console.WriteLine("Eq : " + Decoder.decode(bytes));
            form.backgroundWorker1.ReportProgress(Convert.ToInt32(e.Population.MaximumFitness*100), Decoder.decode(bytes));
            //pop(Decoder.decode(bytes), 20, "BestFit");

            //form.populateMethod(Decoder.decode(bytes), 20, "BestFit");
            //decode chromosome
            /*
                        //get x and y from the solution 
                        var x1 = Convert.ToInt32(chromosome.ToBinaryString(0, chromosome.Count / 2), 2);
                        var y1 = Convert.ToInt32(chromosome.ToBinaryString(chromosome.Count / 2, chromosome.Count / 2), 2);

                        //Adjust range to -100 to +100 
                        var rangeConst = 200 / (System.Math.Pow(2, chromosome.Count / 2) - 1);
                        var x = (x1 * rangeConst) - 100;
                        var y = (y1 * rangeConst) - 100;
                        */
            //display the X, Y and fitness of the best chromosome in this generation 
            //Console.WriteLine("x:{0} y:{1} Fitness{2}", x, y, e.Population.MaximumFitness);
        }
    }
}
