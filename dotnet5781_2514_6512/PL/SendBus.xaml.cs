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
    /// Interaction logic for Send_Bus.xaml
    /// </summary>
    public partial class SendBus : Window
    {
        BL.BLapi.IBL bl = BLapi.BLFactory.GetBL();
        MainWindow mainwindow1;
        public SendBus()
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
    }
}
