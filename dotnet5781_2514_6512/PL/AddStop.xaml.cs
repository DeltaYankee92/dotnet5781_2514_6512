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

namespace PL
{
    /// <summary>
    /// Interaction logic for AddStation.xaml
    /// </summary>
    public partial class AddStop : Window
    {
        BL.BLapi.IBL bl = BLapi.BLFactory.GetBL();
        MainWindow mainwindow1;
        public AddStop()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    mainwindow1 = window as MainWindow;
                }
            }
            InitializeComponent();
        }

        private void StationKeyText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LangtitudeText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LongtitudeText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AdressText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddStationButton_Click(object sender, RoutedEventArgs e)
        {
            var temp = (FrameworkElement)sender;
            int Key = int.Parse(StationKeyText.Text);
            float langtitude = float.Parse(LangtitudeText.Text);
            float longtitude = float.Parse(LongtitudeText.Text);
            string adress = AdressText.Text;
            try
            {
                BL.BO.BusStop stop = new BL.BO.BusStop(Key, langtitude, longtitude, adress);
                if (!bl.CheckIfExists(stop))
                {
                    bl.addStop(stop);
                    mainwindow1.StopsView.ItemsSource = null;
                    mainwindow1.StopsView.ItemsSource = bl.GetAllBusStops();
                    mainwindow1.StopsView.Items.Refresh();
                    this.Close();
                }
                else
                {
                    throw new Exception("Error! Bus is already in the system");
                }
            }
            catch (Exception oops)
            {
                MessageBox.Show(oops.Message);
                this.Close();
            }

        }
    }
}
