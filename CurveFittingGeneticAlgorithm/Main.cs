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
using System.Threading;
using Newtonsoft.Json;
using Jace;

//MUtative Function FIttiNg - MUFFIN

namespace CurveFittingGeneticAlgorithm
{
    public partial class Main : Form
    {
        const int GRAPH_SIZE = 10;
        CalculationEngine engine;
        Genetics g;
        SmallGenetics sg;
        public delegate void populate();
        public populate myDelegate;
        public SmallEquation target = new SmallEquation(0.5, 0, -100, 0, 0);

        public Main()
        {
            InitializeComponent();
            Console.WriteLine(Utils.ConvertRange(0, 1.6E+42,0,1, Utils.calculateError(Utils.convertToDictionary("(100000^4)", 20), Utils.convertToDictionary("-(100000^4)", 20))));
            engine = new CalculationEngine();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Decoder.testBit();



            init();
        }

        public void init()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            populateMethod(Config.target, 20,"Graph");
            
            sw.Stop();
            this.Text = Convert.ToString(sw.ElapsedMilliseconds);
            RandomBufferGenerator rrr = new RandomBufferGenerator(1024);

            //g = new Genetics(this, populateMethod);
            sg = new SmallGenetics(this, populateMethod, Config.target);
        }

        public bool populateMethod(string equation, int size, string graphseries)
        {
            chart1.Series.FindByName(graphseries).Points.Clear();
            for (int i = -size; i<=size;i++)
            {
                chart1.Series.FindByName(graphseries).Points.AddXY(i, Utils.calculateY(equation, i));
            }
            Thread.Sleep(10);
            return true;
        }

        public bool populateMethod(Equation equation, int size, string graphseries)
        {
            chart1.Series.FindByName(graphseries).Points.Clear();
            for (int i = -size; i <= size; i++)
            {
                chart1.Series.FindByName(graphseries).Points.AddXY(i, Utils.calculateY(equation.ToString(), i));
                
            }
            Thread.Sleep(10);
            return true;
        }

        public bool populateMethod(SmallEquation equation, int size, string graphseries)
        {
            chart1.Series.FindByName(graphseries).Points.Clear();
            for (int i = -size; i <= size; i++)
            {
                chart1.Series.FindByName(graphseries).Points.AddXY(i, Utils.calculateY(equation, i));

            }
            Thread.Sleep(10);
            return true;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("start");
           
            sg.run();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            chart1.Series.FindByName("Fitness").Points.Add(JsonConvert.DeserializeObject<Equation>(e.UserState.ToString()).fitness*100);
            Console.WriteLine("Progress! " + JsonConvert.DeserializeObject<Equation>(e.UserState.ToString()).fitness*100);
            populateMethod(JsonConvert.DeserializeObject<SmallEquation>(e.UserState.ToString()), 20, "BestFit");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(Utils.calculateError(Utils.convertToDictionary("x^2", 20), Utils.convertToDictionary("0*(x+0)^4+0*(x+-100000)^3+0,9992*(x+0)^2+0*(x+-100000)^1+0",20))));
        }
    }
}
