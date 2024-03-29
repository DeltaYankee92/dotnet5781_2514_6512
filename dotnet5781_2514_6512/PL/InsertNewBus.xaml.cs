﻿using System;
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
    /// Interaction logic for InsertNewBus.xaml
    /// </summary>
    public partial class InsertNewBus : Window
    {
        BL.BLapi.IBL bl = BLapi.BLFactory.GetBL();
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
        private void Last_Maintenance_km_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //---------------code for the enter button after inserting the new bus info--------------------
        private void Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            var temp = (FrameworkElement)sender;
            DateTime d1;
            int[] id_add;
            id_add = atoi(ID_Text_Box.Text);// id
            int milage, last_maintenance_km, total_milage, fuel;
            total_milage = turn_full(atoi(Milage_Text_Box.Text));
            last_maintenance_km = turn_full(atoi(Last_Maintenance_km.Text));
            milage = total_milage - last_maintenance_km;
            fuel = turn_full(atoi(Fuel_Text_Box.Text));
            try
            {
                d1 = valid_date(Date_Text_Box.Text);
                check_id(id_add, d1);
                BL.BO.Bus b1 = new BL.BO.Bus(d1, id_add, milage, last_maintenance_km, total_milage, fuel);
                List<BL.BO.Bus> busList = new List<BL.BO.Bus>(bl.GetAllBuses());
                foreach (BL.BO.Bus item in busList)
                {
                    if (b1.License_Plate == item.License_Plate)
                    {
                        throw new Exception("Error! Bus is already in the system");
                    }
                }
                bl.AddBus(b1);
                this.Close();
            }
            catch (Exception oops)
            {
                MessageBox.Show(oops.Message);
                this.Close();
            }
        }

        //---------------functon to validate propper license plate insertion (8 digit plate)--------------------
        private void check_id(int[] id_add, DateTime d1)
        {
            if (d1.Year >= 2018 && id_add.Length != 8)
                throw new ArgumentException("ERROR: number of digits doesnt correspond to the correct year. since 2018 - license plates are 8 digits.");
            else if (d1.Year < 2018 && id_add.Length != 7)
                throw new ArgumentException("ERROR: number of digits doesnt correspond to the correct year. before 2018 - license plates are 7 digits");
        }

        //---------------functon to validate propper date insertion--------------------
        public static DateTime valid_date(string x)
        {
            bool flag = true;
            DateTime date;
              flag = DateTime.TryParse(x, out date);
            if (flag == false)
                throw new ArgumentException("ERROR: date is not valid. the format is: DD/MM/YYYY");
            return date;
        }

        //------------------function to turn array of intengers into one intenger----------------
        public static int turn_full(int[] temp)
        {
            int sum = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                sum *= 10;
                sum += temp[i];
            }
            return sum;
        }

        //-----------------function to read data from user input and accept only numbers-------------------
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
                        MessageBox.Show("Insert numbers only!");
                        break;
                }
            }
            return generated;
        }


    }
}
