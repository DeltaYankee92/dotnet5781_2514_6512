

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_03B_2514_6512
{
    class buses_main
    {
        enum CHOICE { EXIT, ADD, DRIVE, REFUEL_OR_REPAIRS, MILEAGE };

        private static List<Buses> database = new List<Buses>(); // again, as requested
                static void Main(string[] args)
        {
            bool flag = false;
            CHOICE choice;
            do
            {
                Console.WriteLine(@"Enter your choice: 
                   1- add a bus to the database
                   2- choose a bus from the database to drive
                   3- fuel up a bus, or repair the bis
                   4- milage driven since the last repair
                   0-exit.");
                bool parse_success;
                parse_success = Enum.TryParse(Console.ReadLine(), out choice);
                if (!parse_success)
                    continue;
                switch (choice)
                {
                    case CHOICE.ADD:
                        ADD();
                        break;
                    case CHOICE.DRIVE:
                        DRIVE();
                        break;
                    case CHOICE.REFUEL_OR_REPAIRS :
                        REFUEL_OR_REPAIRS();
                        break;
                    case CHOICE.MILEAGE:
                        MILEAGE();
                        break;
                    case CHOICE.EXIT:
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("please try again");
                        break;
                }

            } while (flag != true);

        }

        private static void MILEAGE()
        {
            foreach (Buses var in database)
            {
                var.print_mileage(); //* print the mileage of a given bus
            }
        }

        private static void REFUEL_OR_REPAIRS()
        {
            int[] id = valid_plate();
            Console.WriteLine("would you like to refuel or repair?");
            string kelet = Console.ReadLine();
            if(kelet !="refuel" && kelet !="repairs")
            {
                Console.WriteLine("next time enter a valid input please.");
                return;
            }
            foreach (Buses var in database)
            {
                if(check_arr(var.getplate(),id)==true)
                {
                    switch (kelet)
                    {
                        case "refuel":
                            var.fuel_up(); //* add fuel to the bus
                            break;
                        case "repairs":
                            var.fix(); //* fix the current bus
                            break;
                        default:
                            Console.WriteLine("ERROR");
                            break;
                    }
                    return; // inside the "if"
                }

            }

        }


        private static void DRIVE()
        {
            int[] id = valid_plate();
            if(in_system(database,id) == false)
            {
                Console.WriteLine("can't drive a bus that isn't in the system. process failed");
                return;
            }
            Random obj = new Random();
            int amount_to_drive = obj.Next(1, 1201);

            foreach (Buses var in database)
            {
               if(check_arr(var.getplate(),id)==true)
                {
                    if(var.can_go(amount_to_drive)== true) //* can the bus drive that amount?
                    {
                        var.drive(amount_to_drive); //* take the bus out for a ride.
                        return;
                    }
                }
            }
        }

        private static void ADD()
        {
            DateTime date = valid_date();
            int[] id = valid_plate();

            if (date.Year >= 2018 && id.Length != 8)
                Console.WriteLine("ERROR: number of digits doesnt correspond to the correct year");
            else if (date.Year < 2018 && id.Length != 7)
                Console.WriteLine("ERROR: number of digits doesnt correspond to the correct year");
            else if (in_system(database,id)== false)
                database.Add(new Buses(date,id,0,0,0)); //* the bast constructor for a new bus that gets the variables
            else
                Console.WriteLine("bus already in the system. cannot add. process failed");
        }

        private static bool in_system(List<Buses> database, int[] id)
        {
            foreach (Buses bs in database)
            {
                if (check_arr(id,bs.getplate())) //* get the license plate
                    return true;
            }
            return false;
        }

        private static bool check_arr(int[] id, int[] arr)
        {
            if (id.Length != arr.Length)
                return false;
            for (int i = 0; i < id.Length; i++)
                if (id[i] != arr[i])
                    return false;

            return true;
        }

        private static int[] valid_plate()
        {
            Console.WriteLine("enter a license plate (without dashes): ");
            string temp = Console.ReadLine();
            bool flag = false;
            while(flag==false)
            {
                flag = true;
                if (temp.Length != 8 && temp.Length != 7)
                {
                    flag = false;
                    Console.WriteLine("a license plate has either 7 or 8 digits. try again ");
                    continue;
                }
                for (int i = 0; i < temp.Length; i++)
                    if (temp[i] > 57 || temp[i] < 48)
                    {
                        Console.WriteLine("a license plate in israel cannot have anything bar numbers. try again ");
                        flag = false;
                        break;
                    }
            }
            int[] valid = atoi(temp);
            return valid;
        }

        private static int[] atoi(string temp)
        {
            int[] generated = new int[temp.Length];
            for(int i=0;i<temp.Length;i++)
            {
                char x = temp[i];
                switch(x)
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

        private static DateTime valid_date()
        {
            bool flag = true;
            DateTime date;
            do
            {
                if(flag == false)
                    Console.WriteLine("ERROR: date is not valid. enter again:");
                else
                    Console.WriteLine("enter a valid date in the format: DD/MM/YYYY");
                flag = DateTime.TryParse(Console.ReadLine(), out date);
            } while (flag == false) ;
            return date;
        }
    }
}

