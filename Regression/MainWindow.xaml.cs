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

namespace Regression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<double, double> punkter = new Dictionary<double, double>();
            
            punkter[double.Parse(txtX1.Text)] = double.Parse(txtY1.Text);
            punkter[double.Parse(txtX2.Text)] = double.Parse(txtY2.Text);
            punkter[double.Parse(txtX3.Text)] = double.Parse(txtY3.Text);
            punkter[double.Parse(txtX4.Text)] = double.Parse(txtY4.Text);


            lblRes.Content = qdiff(punkter) + "x^2";
            lblQ.Content = q(qdiff(punkter), punkter);
            
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
                aveSumM = aveSumM + q(kord.Key, dict);
            }
            double averageM = aveSumM / dict.Count;


            double upperSum = 0;
            foreach (KeyValuePair<double, double> kord in dict)
            {
                upperSum = upperSum + Math.Pow((q(kord.Key, dict) - averageM),2);
            }

        }

    }
}
