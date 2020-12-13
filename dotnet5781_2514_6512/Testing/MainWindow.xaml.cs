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

namespace Testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<Buses> BusDatabase = new List<Buses>();
        public List<Buses> BusData
        {
            get { return BusDatabase; }
            set { BusDatabase = value; }
        }
        public MainWindow()
        {
            string plate1 = "4125973";
            string plate2 = "4235423";
            string plate3 = "6523646";
            Buses busA = new Buses(DateTime.Now, plate1, 0, 0, 1000);
            Buses busB = new Buses(DateTime.Now, plate2, 0, 0, 1000);
            Buses busC = new Buses(DateTime.Now, plate3, 0, 0, 1000);
            BusDatabase.Add(busA);
            BusDatabase.Add(busB);
            BusDatabase.Add(busC);
            InitializeComponent();
            //BusMenu.ItemsSource = BusDatabase;
            Busses_List.ItemsSource = BusDatabase;

        }
    }
}
