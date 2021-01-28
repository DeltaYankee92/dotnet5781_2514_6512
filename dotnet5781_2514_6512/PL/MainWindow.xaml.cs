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
using System.Windows.Shapes;
using BL.BO;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.BLapi.IBL bl = BLapi.BLFactory.GetBL();
        public MainWindow()
        {
            InitializeComponent();
            bl.UpdateBusesStatus(bl.GetAllBuses());
            BusesView.ItemsSource = bl.GetAllBuses();
            StopsView.ItemsSource = bl.GetAllBusStops();
            LinesView.ItemsSource = bl.GetAllBusLines();
        }

        private void DeleteBus_Click(object sender, RoutedEventArgs e)
        {
            var temp = (FrameworkElement)sender;
            BL.BO.Bus b1 = (BL.BO.Bus)temp.DataContext;
            bl.removeBus(b1.licensePlateArray);
            BusesView.ItemsSource = null;
            BusesView.ItemsSource = bl.GetAllBuses();
            BusesView.Items.Refresh();
        }
        private void DoMaintenance_Click(object sender, RoutedEventArgs e)
        {
            var temp = (FrameworkElement)sender;
            BL.BO.Bus b1 = (BL.BO.Bus)temp.DataContext;
            b1.fix();
            bl.UpdateBus(b1);
            BusesView.Items.Refresh();
        }
        private void Refuel_Click(object sender, RoutedEventArgs e)
        {
            var temp = (FrameworkElement)sender;
            BL.BO.Bus b1 = (BL.BO.Bus)temp.DataContext;
            b1.fuel_up();
            bl.UpdateBus(b1);
            BusesView.Items.Refresh();
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

        private void AddBusButton_Click(object sender, RoutedEventArgs e)
        {
            InsertNewBus objInsertNewBus = new InsertNewBus();
            objInsertNewBus.Show();
            BusesView.ItemsSource = null;
            BusesView.ItemsSource = bl.GetAllBuses();
            BusesView.Items.Refresh();
            
        }

        private void AddStationButton_Click(object sender, RoutedEventArgs e)
        {
            AddStop objAddStopButton = new AddStop();
            objAddStopButton.Show();
        }

        private void AddLineButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StopsView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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

        private void DeleteStop_Click(object sender, RoutedEventArgs e)
        {
            var temp = (FrameworkElement)sender;
            BL.BO.BusStop stop = (BL.BO.BusStop)temp.DataContext;
            bl.DeleteStop(stop.BusStationKey);
            StopsView.ItemsSource = null;
            StopsView.ItemsSource = bl.GetAllBusStops();
            StopsView.Items.Refresh();
        }

        private void SendBus_Click(object sender, RoutedEventArgs e)
        {
            SendBus objSendBus = new SendBus();
            objSendBus.Show();
        }
    }
}
