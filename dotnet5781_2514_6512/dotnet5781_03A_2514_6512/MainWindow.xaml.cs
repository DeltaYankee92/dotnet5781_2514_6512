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

namespace dotnet5781_03A_2514_6512
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            //***********Functions to generate Random numbers for the constructors***************

            LineCollecton Lines = new LineCollecton();
            LineStation[] ls = new LineStation[20];
            for (int i = 0; i < ls.Length; i++)
            {
                ls[i] = new LineStation();
            }
            BusLine[] bs = new BusLine[10];
            for (int i = 0; i < bs.Length; i++)
            {
                bs[i] = new BusLine();
            }

            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                for (int j = 0; j < rand.Next(1, 10); j++)
                {
                    bs[i].add_station(ls[j]);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Lines.ADD_Line(bs[i]);
            }
            InitializeComponent();
            cbBusLines.ItemsSource = Lines;
            cbBusLines.DisplayMemberPath = " BusLineNum ";
            cbBusLines.SelectedIndex = 0;
            Console.WriteLine("Hellp");
            //ShowBusLine(……….)

        }
    }
}
