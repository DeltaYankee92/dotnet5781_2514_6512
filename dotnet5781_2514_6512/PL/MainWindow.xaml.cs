using System;
using System.Collections.Generic;
using System.Globalization;
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
using BL.BO;



//-----------------Bonuses:---------------------
//Timer is displaed for each bus seperately. "send drive button is not preducng a timer. we couldn't sove this.
//Rows change colors based on the bus status (Ready / Not Ready / Under Maintenance).
//The action button are loaded for each bus seperatly. No need to open window and pick a bus. The button will preform the action on thw row it was called from.



namespace PL
{

    public partial class MainWindow : Window
    {
        BL.BLapi.IBL bl = BLapi.BLFactory.GetBL();
    //    DispatcherTimer timer;
        public static bool flag = true;
        //public static List<Buses> BusDatabase = new List<Buses>();
        //public List<Buses> BusData
        //{
        //    get { return BusDatabase; }
        //    set { BusDatabase = value; }
        //}
        public MainWindow()
        {
            InitializeComponent();
            Busses_List.ItemsSource = bl.GetAllBuses();
            //         timer = new DispatcherTimer();
            //         timer.Tick += new EventHandler(CheckUpdate);
            //        timer.Interval = new TimeSpan(0, 0, 2);


        }


        //-----------------------Function to refresh the display and update the statuses of the busses-------------------------
        private void CheckUpdate(Object obj, EventArgs e)
        {
            //foreach (Bus b1 in bl.GetAllBuses())
            //{
            //    if (b1.Status == "Under Maintenance" && b1..TimeNow == "00:00:00")
            //    {
            //        b1.Status = "Ready";
            //        b1.time.Blank();
            //        b1.fix();
            //        MessageBox.Show("The bus with the ID of: " + b1.License_Plate + " had a successful maintenance");
            //        Busses_List.Items.Refresh();
            //    }
            //    if (b1.Status == "in_drive" && b1.time.TimeNow == "00:00:00")
            //    {
            //        b1.Status = "Ready";
            //        b1.time.Blank();
            //        MessageBox.Show("The bus with the ID of: " + b1.License_Plate + " had a successful drive");
            //        Busses_List.Items.Refresh();
            //    }
            //}
        }

        //----------------Button "insert" which inserts a new bus to the database-------------------------
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            //InsertNewBus objInsertNewBus = new InsertNewBus();
            //objInsertNewBus.Show();
        }


        private void SendBus_Click(object sender, RoutedEventArgs e)
        {
            //ChooseBusToDrive objChooseBusToDrive = new ChooseBusToDrive();
            //objChooseBusToDrive.Show();
        }

        //----------------button to send bus to mantenance. the button will appear in each row and is specific to that bus-----------------
        private void DoMaintenance_Click(object sender, RoutedEventArgs e)
        {
            //var temp = (FrameworkElement)sender;
            //Buses b1 = (Buses)temp.DataContext;
            //if (b1.Status == "Under Maintenance" || b1.Status == "in_drive")
            //{
            //    MessageBox.Show("can't start a new action. in the middle of one");
            //}
            //else
            //{
            //    b1.Status = "Under Maintenance";
            //    Busses_List.Items.Refresh();
            //    b1.time = new Timerclasstest(30);
            //    Busses_List.Items.Refresh();
            //    timer.Start();
            //}

        }
        private void DeleteBus_Click(object sender, RoutedEventArgs e)
        {
            //int index = 0;
            //bool flag = false;
            //var temp = (FrameworkElement)sender;
            //Buses b1 = (Buses)temp.DataContext;
            //foreach (Buses item in BusDatabase)
            //{
            //    if (item.compare_plate(b1))
            //    {
            //        index = BusDatabase.IndexOf(item);
            //        flag = true;
            //    }
            //}
            //if (flag)
            //{
            //    BusDatabase.RemoveAt(index);
            //    MessageBox.Show("The bus with the ID of: " + b1.License_Plate + " has been removed successfully");
            //}
            //Busses_List.Items.Refresh();
        }


        //---------------this will cuase a bus information window to appear when double clicking a bus (the row)-------------------
        private void Busses_List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            //    if (sender != null)
            //    {
            //        ListView ls = sender as ListView;
            //        MessageBox.Show(ls.SelectedItem.ToString());

            //    }
            //}
            //catch (Exception exep)
            //{
            //    MessageBox.Show(exep.Message);
            //}
        }
        //----------------Button to send bus to drive. will generate a new window to enter detailes-------------------
        //----------------------the button will appear in each row and is specific to that bus------------------------

        private void Send_Bus_Click(object sender, RoutedEventArgs e)
        {
            //var temp = (FrameworkElement)sender;
            //Buses line = (Buses)temp.DataContext;
            //if (line.Status != "Ready")
            //{
            //    MessageBox.Show("Bus not ready to drive");
            //}
            //else
            //{
            //    int fuel_before = line.Current_Fuel;
            //    ChooseBusToDrive cbtd = new ChooseBusToDrive(ref temp);
            //    cbtd.Show();
            //}
        }

        //-------------------------refuel button code. individual to each bus-------------------
        private void Refuel_Click(object sender, RoutedEventArgs e)
        {
            //int index = 0;
            //bool flag = false;
            //var temp = (FrameworkElement)sender;
            //Buses b1 = (Buses)temp.DataContext;
            //foreach (Buses item in BusDatabase)
            //{
            //    if (item.compare_plate(b1))
            //    {
            //        index = BusDatabase.IndexOf(item);
            //        flag = true;
            //    }
            //}
            //if (flag)
            //{
            //    b1.fuel_up();
            //    MessageBox.Show("The bus with the ID of: " + b1.License_Plate + " Was successfuly fueled up.");
            //}
            //Busses_List.Items.Refresh();
        }
        //public void drive_timer(Buses line, int fuel_before)
        //{
        //    //int dist = line.Current_Fuel - fuel_before;
        //    //if (dist != 0)
        //    //{
        //    //    line.Status = "in_drive";
        //    //    Busses_List.Items.Refresh();
        //    //    line.time = new Timerclasstest(dist * 60);
        //    //    Busses_List.Items.Refresh();
        //    //    timer.Start();
        //    //}
        //}
    }
}
