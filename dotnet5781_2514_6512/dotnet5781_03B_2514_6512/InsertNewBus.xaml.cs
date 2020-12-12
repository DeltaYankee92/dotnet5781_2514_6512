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

        private void ID_Text_Box_TextChanged(object sender, TextChangedEventArgs e) //"ID_Text_Box"
        {

        }
        private void Milage_Text_Box_TextChanged(object sender, TextChangedEventArgs e) //"Milage_Text_Box"
        {

        }

        private void Fuel_Text_Box_TextChanged(object sender, TextChangedEventArgs e) // Name="Fuel_Text_Box"
        {

        }
        private void Date_Text_Box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime d1;
            int[] id_add;
            id_add = atoi(ID_Text_Box.Text);// id
            int milage, fuel;
            milage = turn_full(atoi(Milage_Text_Box.Text));
            fuel = turn_full(atoi(Fuel_Text_Box.Text));
            try
            {
                d1 = valid_date(Date_Text_Box.Text);
                check_id(id_add,d1);
                Buses b1 = new Buses(d1,id_add,milage,0,fuel);
                foreach (Buses it in mainwindow1.BusData)
                {
                    if (it.compare_plate(b1))
                        throw new ArgumentException("plate already in system");
                }
                mainwindow1.BusData.Add(b1);
                mainwindow1.Busses_List.Items.Refresh();
                this.Close();
            }
            catch(Exception oops)
            {
                MessageBox.Show(oops.Message);
                this.Close();
            }
        }

        private void check_id(int[] id_add, DateTime d1)
        {
            if (d1.Year >= 2018 && id_add.Length != 8)
                throw new ArgumentException("ERROR: number of digits doesnt correspond to the correct year");
            else if (d1.Year < 2018 && id_add.Length != 7)
                throw new ArgumentException("ERROR: number of digits doesnt correspond to the correct year");
        }

        public static DateTime valid_date(string x)
        {
            bool flag = true;
            DateTime date;
              flag = DateTime.TryParse(x, out date);
            if (flag == false)
                throw new ArgumentException("ERROR: date is not valid. the format is: DD/MM/YYYY");
            return date;
        }
        public static int turn_full(int[] temp)
        {
            int sum = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                sum += temp[i];
            }
            return sum;
        }
        public static int[] atoi(string temp)
        {
            int[] generated = new int[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                char x = temp[i];
                switch (x)
                {
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
                        generated[i] = -1;
                        break;
                }
            }
            return generated;
        }
    }
}
