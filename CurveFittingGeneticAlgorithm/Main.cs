using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Jace;

//MUtative Function FIttiNg - MUFFIN

namespace CurveFittingGeneticAlgorithm
{
    public partial class Main : Form
    {
        const int GRAPH_SIZE = 10; //
        CalculationEngine engine;

        public Main()
        {
            InitializeComponent();
            engine = new CalculationEngine();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        public void init()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            populate("-3,4*x^3+4,34*x^2+2", 20,"Graph");
            
            sw.Stop();
            this.Text = Convert.ToString(sw.ElapsedMilliseconds);
            RandomBufferGenerator rrr = new RandomBufferGenerator(1024);
            string rand = Decoder.decode(rrr.GenerateBufferFromSeed(712));
            //calculateY("-7,2711004537369E-289*(x+-1,29729856441743E+200)^4+-8,55276388740592E+148*(x+-1,5076262475443E+226)^3+6,97391098666866E-115*(x+-1,78144481002356E+304)^2+-9,55581921478411E-306*(x+-3,02431166243636E+212)^1+3,80136089506401E+122", 1);
            populate(rand, 20, "BestFit");
            this.Text = rand;
        }

        public double calculateY(string equation, double x)
        {
            Dictionary<string, double> variables = new Dictionary<string, double>();
            variables.Add("x", x);
            double result = engine.Calculate(equation, variables);

            return result;
        }

        public void populate(string equation, int size, string graphseries)
        {
            //foreach (var series in chart1.Series.FindByName(graphseries))
            {
                chart1.Series.FindByName(graphseries);
            }
            for (int i = -size; i<=size;i++)
            {
                chart1.Series.FindByName(graphseries).Points.AddXY(i, calculateY(equation, i));
            }
        }
    }
}
