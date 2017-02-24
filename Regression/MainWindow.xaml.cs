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
            double q = 0;
            punkter[double.Parse(txtX1.Text)] = double.Parse(txtY1.Text);
            punkter[double.Parse(txtX2.Text)] = double.Parse(txtY2.Text);
            punkter[double.Parse(txtX3.Text)] = double.Parse(txtY3.Text);
            punkter[double.Parse(txtX4.Text)] = double.Parse(txtY4.Text);



            
        }
        public double q(double a, Dictionary<double, double> dict)
        {
            double val = 0;

            foreach (KeyValuePair<double, double> entry in dict)
            {
                val = val + Math.Pow(Math.Pow(entry.Key, 2)*a - entry.Value, 2);
            }

            return val;
        }
        public double qdiff(double a, Dictionary<double, double> dict)
        {
            double val = 0;

            foreach (KeyValuePair<double, double> entry in dict)
            {
                val = val + 2 * Math.Pow(entry.Key, 2)*(Math.Pow(entry.Key, 2) * a - entry.Value);
            }

            return val;

        }

        public double brute(int range)
        {
            double a = -10;
            double high = double.MaxValue;
            for (int i = 0; i < range; i++)
            {
                if (q(a)
                {

                }
            }
        }

    }
}
