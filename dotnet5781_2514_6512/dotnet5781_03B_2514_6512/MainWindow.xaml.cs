using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace dotnet5781_03B_2514_6512
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        public static bool flag = true;
        public static List<Buses> BusDatabase = new List<Buses>();
        public List<Buses> BusData
        {
            get { return BusDatabase; }
            set { BusDatabase = value; }
        }
        public MainWindow()
        {
            int[] plate1 = { 4, 1, 2, 5, 9, 7, 3, 0 };
            int[] plate2 = { 5, 2, 3, 4, 0, 8, 4, 5 };
            int[] plate3 = { 6, 3, 4, 5, 1, 9, 5, 6 };
            int[] plate4 = { 4, 1, 4, 6, 2, 6, 3, 5 };
            int[] plate5 = { 2, 6, 4, 6, 3, 3, 7, 5 };
            int[] plate6 = { 5, 1, 7, 4, 2, 5, 4, 7 };
            int[] plate7 = { 5, 1, 8, 3, 5, 2, 5, 7 };
            int[] plate8 = { 5, 1, 6, 4, 7, 3, 5, 2 };
            int[] plate9 = { 4, 7, 3, 6, 2, 4, 3, 6 };
            int[] plate10 = { 5, 2, 7, 5, 7, 3, 4, 6 };
            Buses bus1 = new Buses(DateTime.Now, plate1, 39000, 20000, 39000, 1000);
            Buses bus2 = new Buses(DateTime.Now, plate2, 17000, 0, 17000, 200);
            Buses bus3 = new Buses(DateTime.Now, plate3, 15000, 0, 15000, 0);
            Buses bus4 = new Buses(DateTime.Now, plate3, 41000, 0, 41000, 1000);
            Buses bus5 = new Buses(DateTime.Now, plate3, 0, 0, 0, 1000);
            Buses bus6 = new Buses(DateTime.Now, plate3, 0, 0, 0, 1000);
            Buses bus7 = new Buses(DateTime.Now, plate3, 0, 0, 0, 1000);
            Buses bus8 = new Buses(DateTime.Now, plate3, 0, 0, 0, 1000);
            Buses bus9 = new Buses(DateTime.Now, plate3, 0, 0, 0, 1000);
            Buses bus10 = new Buses(DateTime.Now, plate3, 0, 0, 0, 0);
            BusDatabase.Add(bus1);
            BusDatabase.Add(bus2);
            BusDatabase.Add(bus3);
            BusDatabase.Add(bus4);
            BusDatabase.Add(bus5);
            BusDatabase.Add(bus6);
            BusDatabase.Add(bus7);
            BusDatabase.Add(bus8);
            BusDatabase.Add(bus9);
            BusDatabase.Add(bus10);
            InitializeComponent();
            Busses_List.ItemsSource = BusDatabase;
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(CheckUpdate);
            timer.Interval = new TimeSpan(0, 0, 2);
           

        }
        private void CheckUpdate(Object obj,EventArgs e)
        {
            foreach(Buses b1 in BusDatabase)
            {
                if( b1.Status == "under maintanance" && b1.time.TimeNow=="00:00:00")
                {
                    b1.Status = "Ready";
                    b1.time.Blank();
                    b1.fix();
                    MessageBox.Show("The bus with the ID of: " + b1.License_Plate + " had a successful maintaintance");
                    Busses_List.Items.Refresh();                  
                }
                if (b1.Status == "in_drive" && b1.time.TimeNow == "00:00:00")
                {
                    b1.Status = "Ready";
                    b1.time.Blank();
                    MessageBox.Show("The bus with the ID of: " + b1.License_Plate + " had a successful drive");
                    Busses_List.Items.Refresh();
                }
            }
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
            if (b1.Status== "under maintanance" || b1.Status == "in_drive")
            {
                MessageBox.Show("can't start a new action. in the middle of one");
            }
            else
            {
                b1.Status = "under maintanance";
                Busses_List.Items.Refresh();
                b1.time = new Timerclasstest(144);
                Busses_List.Items.Refresh();
                timer.Start();
            }

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
            }
            else
            {
                int fuel_before = line.Current_Fuel;
                ChooseBusToDrive cbtd = new ChooseBusToDrive(ref temp);
                cbtd.Show();
            }
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
        public void drive_timer(Buses line, int fuel_before)
        {
            int dist = line.Current_Fuel - fuel_before;
            if (dist != 0)
            {
                line.Status = "in_drive";
                Busses_List.Items.Refresh();
                line.time = new Timerclasstest(dist * 60);
                Busses_List.Items.Refresh();
                timer.Start();
            }

        }
    }
}
