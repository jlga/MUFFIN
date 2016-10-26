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
            populate("-3,4*x^3+4,34*x^2+2", 20);
            sw.Stop();
            this.Text = Convert.ToString(sw.ElapsedMilliseconds);
            RandomBufferGenerator rrr = new RandomBufferGenerator(1024);
            string rand = Decoder.decode(rrr.GenerateBufferFromSeed(712));
            this.Text = rand;
        }

        public double calculateY(string equation, double x)
        {
            Dictionary<string, double> variables = new Dictionary<string, double>();
            variables.Add("x", x);
            double result = engine.Calculate(equation, variables);

            return result;
        }

        public void populate(string equation, int size)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            for (int i = -size; i<=size;i++)
            {
                chart1.Series.FindByName("Graph").Points.AddXY(i, calculateY(equation, i));
            }
        }
    }
}
