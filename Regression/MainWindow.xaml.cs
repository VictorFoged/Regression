using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.Charts;

namespace Regression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<double, double> punkter = new Dictionary<double, double>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {

            if (txtX1.Text != "" || txtY1.Text != "")
            {
                punkter[double.Parse(txtX1.Text)] = double.Parse(txtY1.Text);
            }
            if (txtX2.Text != "" || txtY2.Text != "")
            {
                punkter[double.Parse(txtX2.Text)] = double.Parse(txtY2.Text);
            }
            if (txtX3.Text != "" || txtY3.Text != "")
            {
                punkter[double.Parse(txtX3.Text)] = double.Parse(txtY3.Text);
            }
            if (txtX4.Text != "" || txtY4.Text != "")
            {
                punkter[double.Parse(txtX4.Text)] = double.Parse(txtY4.Text);
            }
            if (txtX5.Text != "" || txtY5.Text != "")
            {
                punkter[double.Parse(txtX5.Text)] = double.Parse(txtY5.Text);
            }


            VerticalAxis axis = new VerticalAxis();
            axis.SetConversion(0, 100, 100, 0);

            //plotter.Children.Add(axis);
            // this is only an example of visible rectange. Use here rect you actually need.
            plotter.Viewport.Visible = new Rect(0, 0, 1, 100);
            plotter.AddLineChart(punkter);




            lblRes.Content = qdiff(punkter) + "x^2";
            lblQ.Content = beregnR(punkter);
                        
        }
        
        public double qdiff(Dictionary<double, double> dict)
        {
            double upperSum = 0;
            double lowerSum = 0;
            
            foreach (KeyValuePair<double, double> kord in dict)
            {
                double xSq = Math.Pow(kord.Key, 2);
                upperSum = upperSum + (xSq * kord.Value);
            }

            foreach (KeyValuePair<double, double> kord in dict)
            {
                double xSq = Math.Pow(kord.Key, 2);
                lowerSum = lowerSum + Math.Pow(xSq, 2);
            }
            //Console.WriteLine(upperSum);
            //Console.WriteLine(lowerSum);
            double val = upperSum / lowerSum;
            return val;

        }

        public double q(double a, Dictionary<double, double> dict)
        {
            double sum = 0;
            foreach (KeyValuePair<double, double> kord in dict)
            {
                double xSq = Math.Pow(kord.Key, 2);
                sum = sum + Math.Pow(xSq - kord.Value, 2);
            }
            return sum;
        }

        public double beregnR(Dictionary<double, double> dict)
        {
            //Average Real
            double aveSumR = 0;
            foreach (KeyValuePair<double, double> kord in dict)
            {
                aveSumR = aveSumR + kord.Value;
            }
            double averageR = aveSumR / dict.Count;

            //Average Model
            double aveSumM = 0;
            foreach (KeyValuePair<double, double> kord in dict)
            {
                aveSumM = aveSumM + f(kord.Key);
            }
            double averageM = aveSumM / dict.Count;


            double upperSum = 0;
            foreach (KeyValuePair<double, double> kord in dict)
            {
                upperSum = upperSum + Math.Pow((f(kord.Key) - averageM),2);
                Console.WriteLine(upperSum);
            }

            double lowerSum = 0;
            foreach (KeyValuePair<double, double> kord in dict)
            {
                lowerSum = lowerSum + Math.Pow(kord.Value - averageR, 2);
            }

            double val = upperSum / lowerSum;
            Console.WriteLine(val);

            Console.WriteLine(aveSumM);
            Console.WriteLine(aveSumR);
            return val;
        }

        public double f(double x)
        {
            double a = qdiff(punkter);
            return a * Math.Pow(x, 2);
        }

    }
}
