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
        private BusLine currentDisplayLine;
        static LineCollecton busLines = new LineCollecton();
        public MainWindow()
        {
            //-----------------Random variable to be used for random number generators------------------------------------
            Random rand = new Random();

            //-----------------creation of 10 buses with 20 LineStations devided unequally between them-------------------

            LineStation[] ls = new LineStation[20];
            for (int i = 0; i < ls.Length; i++)
            {
                string str = "line # " + i;
                ls[i] = new LineStation((Double)rand.Next(100,300), (double)rand.Next(0,2)+rand.NextDouble(), (int)rand.Next(100000,1000000), rand.Next(31,34)+rand.NextDouble(), rand.Next(33, 36) + rand.NextDouble(), str);
            }
            BusLine[] bs = new BusLine[10];
            for (int i = 0; i < bs.Length; i++)
            {
                bs[i] = new BusLine((int)rand.Next(1,1000));
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < rand.Next(2, 11); j++)
                {
                    bs[i].add_station(ls[j]);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                busLines.ADD_Line(bs[i]);
            }
            InitializeComponent();

            
            cbBusLines.ItemsSource = busLines;
            cbBusLines.DisplayMemberPath = "busNumber"; 
            cbBusLines.SelectedIndex = 0;

            ShowBusLine(busLines.Lines[0].get_line_num());

        }
        public void ShowBusLine(int index)
        {
            currentDisplayLine = busLines[busLines.index_find(index)];
             UpGrid.DataContext = currentDisplayLine; 
            lbBusLineStations.DataContext = currentDisplayLine.Stations;

        }
        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as BusLine).BusNumber);
        }

        private void tbArea_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbArea.Clear();
        }
    }
}
