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

namespace dotnet5781_03B_2514_6512
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool flag = true;
        private static List<Buses> BusDatabase = new List<Buses>();
        public List<Buses> BusData
        {
            get { return BusDatabase; }
            set { BusDatabase = value; }
        }
        public MainWindow()
        {
            int[] plate1 = { 4, 1, 2, 5, 9, 7, 3 };
            int[] plate2 = { 5, 2, 3, 4, 0, 8, 4 };
            int[] plate3 = { 6, 3, 4, 5, 1, 9, 5 };
            Buses busA = new Buses(DateTime.Now, plate1, 0, 0, 1000);
            Buses busB = new Buses(DateTime.Now, plate2, 0, 0, 1000);
            Buses busC = new Buses(DateTime.Now, plate3, 0, 0, 1000);
            BusDatabase.Add(busA);
            BusDatabase.Add(busB);
            BusDatabase.Add(busC);
            InitializeComponent();
            Busses_List.ItemsSource = BusDatabase;



        }
        

        public void InitializeBuses()
        {

        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            InsertNewBus objInsertNewBus = new InsertNewBus();
            objInsertNewBus.Show();
        }

        private void SendBus_Click(object sender, RoutedEventArgs e)
        {
            ChooseBusToDrive objChooseBusToDrive = new ChooseBusToDrive();
            objChooseBusToDrive.Show();
        }

        private void DeleteBus_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            bool flag = false;
            var temp = (FrameworkElement)sender;
            Buses b1 = (Buses)temp.DataContext;
            foreach (Buses item in BusDatabase)
            {
                if (item.compare_plate(b1))
                {
                    index = BusDatabase.IndexOf(item);
                    flag = true;
                }
            }
            if (flag)
            {
                BusDatabase.RemoveAt(index);
            }
            Busses_List.Items.Refresh();
        }

        private void SendToDrive_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
