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

        private void DoMaintenance_Click(object sender, RoutedEventArgs e)
        {
            var temp = (FrameworkElement)sender;
            Buses b1 = (Buses)temp.DataContext;
            b1.fix();
            b1.Status = "Ready";
            MessageBox.Show("The bus with the ID of: " + b1.License_Plate + " had a successful maintaintance");
            Busses_List.Items.Refresh();
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
                MessageBox.Show("The bus with the ID of: "+b1.License_Plate+" has been removed successfully");
            }
            Busses_List.Items.Refresh();
        }


        private void Busses_List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    ListView ls = sender as ListView;
                    MessageBox.Show(ls.SelectedItem.ToString());

                }
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message);
            }
        }

        private void Send_Bus_Click(object sender, RoutedEventArgs e)
        {
            var temp = (FrameworkElement)sender;
            Buses line = (Buses)temp.DataContext;
            if (line.Status != "Ready")
            {
                MessageBox.Show("Bus not ready to drive");
                return;
            }
            ChooseBusToDrive cbtd = new ChooseBusToDrive(ref temp);
            cbtd.Show();
        }

        private void Refuel_Click(object sender, RoutedEventArgs e)
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
                b1.fuel_up();
                MessageBox.Show("The bus with the ID of: " + b1.License_Plate + " Was successfuly fueled up.");
            }
            Busses_List.Items.Refresh();
        }
    }
}
