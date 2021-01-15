using BL.BO;

using System.Windows;
using System.Windows.Controls;


namespace PL
{
    /// <summary>
    /// Interaction logic for ChooseBusToDrive.xaml
    /// </summary>
    public partial class ChooseBusToDrive : Window
    {
        MainWindow mainwindow2;
        private FrameworkElement temp;
        MainWindow mainWindow1;
        Bus line;


        public ChooseBusToDrive()
        {
            InitializeComponent();
        }

        public ChooseBusToDrive(ref FrameworkElement temp)
        {
            line = (Bus)temp.DataContext;
            InitializeComponent();
        }

        private void DistanceInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {

            int[] arr = atoi(DistanceInputBox.Text);
            int dist = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                dist *= 10;
                dist += arr[i];
            }
            if (line.can_go(dist))
            {

                line.drive(dist);
                if ((line.Milage >= 20000) || (line.Current_Fuel == 0))
                {
                    line.Status = "Not Ready";
                }
                this.Close();
            }
            else
            {
                MessageBox.Show($"This bus cant drive with these parameters. \nBus has enough fuel for: {line.Current_Fuel} kilometers \nBus can drive {20000 - line.Milage} kilometers before next maintenance.");
                this.Close();
            }
        }

        public static int[] atoi(string temp)
        {
            int[] generated = new int[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                char x = temp[i];
                switch (x)
                {
                    case '0':
                        generated[i] = 0;
                        break;
                    case '1':
                        generated[i] = 1;
                        break;
                    case '2':
                        generated[i] = 2;
                        break;
                    case '3':
                        generated[i] = 3;
                        break;
                    case '4':
                        generated[i] = 4;
                        break;
                    case '5':
                        generated[i] = 5;
                        break;
                    case '6':
                        generated[i] = 6;
                        break;
                    case '7':
                        generated[i] = 7;
                        break;
                    case '8':
                        generated[i] = 8;
                        break;
                    case '9':
                        generated[i] = 9;
                        break;
                    default:
                        MessageBox.Show("Insert only numbers!");
                        break;
                }
            }
            return generated;
        }

    }

}
