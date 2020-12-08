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

namespace dotnet5781_03B_2514_6512
{
    /// <summary>
    /// Interaction logic for InsertNewBus.xaml
    /// </summary>
    public partial class InsertNewBus : Window
    {
        MainWindow mainwindow1;
        public InsertNewBus()
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
