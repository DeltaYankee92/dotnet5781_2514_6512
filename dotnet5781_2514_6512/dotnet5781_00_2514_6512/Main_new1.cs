using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
 namespace dotnet5781_00_2514_6512
{
    class main_targ2
    {

        /*
         * the program manages a bunch of bus lines.
         we will start by entering manualy 10 lines, then giving the rest to the will of the user.
         * */

        static void Main(string[] args)
        {
            try
            {

                LineCollecton Lines = new LineCollecton();
                Random rand = new Random();
                List<LineStation> Stops1 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 945156, Latitude = 33.4563, Longitude = 120.3454, adress = "עוזיאל 131, ירושלים" },
            new LineStation{BusStationKey = 999404, Latitude = 33.3563, Longitude = 121.3344, adress = "עוזיאל 42, ירושלים" },
            new LineStation{BusStationKey = 962404, Latitude = 33.3512, Longitude = 121.3352, adress = "עוזיאל 31, ירושלים" },
            new LineStation{BusStationKey = 329404, Latitude = 33.3552, Longitude = 121.3341, adress = "עוזיאל 25, ירושלים" },
            new LineStation{BusStationKey = 962403, Latitude = 33.3565, Longitude = 121.3361, adress = "עוזיאל 17, ירושלים" },
            new LineStation{BusStationKey = 999472, Latitude = 33.3515, Longitude = 121.3371, adress = "אינו שאקי 6, ירושלים" },
        };

                List<LineStation> Stops2 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 945233, Latitude = 33.3651, Longitude = 121.3367, adress = "בית וגן 13, ירושלים" },
            new LineStation{BusStationKey = 944326, Latitude = 33.1421, Longitude = 121.6421, adress = "בית וגן 14, ירושלים" },
            new LineStation{BusStationKey = 634443, Latitude = 33.5231, Longitude = 121.3634, adress = "בית וגן 15, ירושלים" },
            new LineStation{BusStationKey = 949443, Latitude = 33.7341, Longitude = 121.9561, adress = "בית וגן 16, ירושלים" },
            new LineStation{BusStationKey = 634613, Latitude = 33.7462, Longitude = 121.0524, adress = "בית וגן 17, ירושלים" },
            new LineStation{BusStationKey = 329404, Latitude = 33.3552, Longitude = 121.3341, adress = "עוזיאל 25, ירושלים" },
            new LineStation{BusStationKey = 999472, Latitude = 33.3515, Longitude = 121.3371, adress = "אינו שאקי 6, ירושלים" },
            new LineStation{BusStationKey = 962404, Latitude = 33.3512, Longitude = 121.3352, adress = "עוזיאל 31, ירושלים" },
        };
                List<LineStation> Stops3 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 949823, Latitude = 33.8342, Longitude = 121.0452, adress = "התירוש 1, אפרת" },
            new LineStation{BusStationKey = 949945, Latitude = 33.0951, Longitude = 121.0361, adress = "התירוש 2, אפרת" },
            new LineStation{BusStationKey = 867323, Latitude = 33.7455, Longitude = 121.6111, adress = "התירוש 3, אפרת" },
            new LineStation{BusStationKey = 972364, Latitude = 33.3098, Longitude = 121.0912, adress = "התירוש 4, אפרת" },
            new LineStation{BusStationKey = 940913, Latitude = 33.3652, Longitude = 121.9152, adress = "התירוש 5, אפרת" },
            new LineStation{BusStationKey = 835125, Latitude = 33.0912, Longitude = 121.8761, adress = "התירוש 6, אפרת" },
            new LineStation{BusStationKey = 091235, Latitude = 33.8713, Longitude = 121.8721, adress = "התירוש 7, אפרת" },
            new LineStation{BusStationKey = 976443, Latitude = 33.6121, Longitude = 121.9571, adress = "התירוש 8, אפרת" },
        };
                List<LineStation> Stops4 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 948453, Latitude = 33.7364, Longitude = 121.0465, adress = "יצחק מן 23, ירושלים" },
            new LineStation{BusStationKey = 683443, Latitude = 33.8345, Longitude = 121.0465, adress = "יצחק מן 24, ירושלים" },
            new LineStation{BusStationKey = 906743, Latitude = 33.3583, Longitude = 121.0342, adress = "יצחק מן 25, ירושלים" },
        };
                List<LineStation> Stops5 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 949653, Latitude = 33.6531, Longitude = 121.6541, adress = "זרובבל 10, אלעזר" },
            new LineStation{BusStationKey = 946521, Latitude = 33.5421, Longitude = 121.7641, adress = "זרובבל 11, אלעזר" },
            new LineStation{BusStationKey = 946531, Latitude = 33.6512, Longitude = 121.6512, adress = "זרובבל 12, אלעזר" },
            new LineStation{BusStationKey = 949651, Latitude = 33.5411, Longitude = 121.6531, adress = "זרובבל 13, אלעזר" },
            new LineStation{BusStationKey = 949823, Latitude = 33.8342, Longitude = 121.0452, adress = "התירוש 1, אפרת" },
        };
                List<LineStation> Stops6 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 162542, Latitude = 33.3856, Longitude = 121.7421, adress = "הפסגה 18, ירושלים" },
            new LineStation{BusStationKey = 946351, Latitude = 33.7462, Longitude = 121.7415, adress = "הפסגה 19, ירושלים" },
            new LineStation{BusStationKey = 949522, Latitude = 33.3612, Longitude = 121.6161, adress = "הפסגה 20, ירושלים" },
            new LineStation{BusStationKey = 952343, Latitude = 33.4251, Longitude = 121.6761, adress = "הפסגה 21, ירושלים" },
            new LineStation{BusStationKey = 745443, Latitude = 33.3723, Longitude = 121.7451, adress = "הפסגה 22, ירושלים" },
            new LineStation{BusStationKey = 962404, Latitude = 33.3512, Longitude = 121.3352, adress = "עוזיאל 31, ירושלים" },
            new LineStation{BusStationKey = 999472, Latitude = 33.3515, Longitude = 121.3371, adress = "אינו שאקי 6, ירושלים" },
        };
                List<LineStation> Stops7 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 995123, Latitude = 33.3551, Longitude = 121.3374, adress = "רינה ניקובה 11, ירושלים" },
            new LineStation{BusStationKey = 949443, Latitude = 33.3551, Longitude = 121.3361, adress = "רינה ניקובה 12, ירושלים" },
            new LineStation{BusStationKey = 999472, Latitude = 33.3515, Longitude = 121.3371, adress = "אינו שאקי 6, ירושלים" },
        };
                List<LineStation> Stops8 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 949745, Latitude = 33.3651, Longitude = 121.3371, adress = "מעלה משואות יצחק 1, אפרת" },
            new LineStation{BusStationKey = 947613, Latitude = 33.6231, Longitude = 121.8231, adress = "מעלה משואות יצחק 2, אפרת" },
            new LineStation{BusStationKey = 652443, Latitude = 33.6551, Longitude = 121.9861, adress = "מעלה משואות יצחק 3, אפרת" },
            new LineStation{BusStationKey = 949542, Latitude = 33.7321, Longitude = 121.3661, adress = "מעלה משואות יצחק 4, אפרת" },
            new LineStation{BusStationKey = 652645, Latitude = 33.7621, Longitude = 121.7661, adress = "מעלה משואות יצחק 5, אפרת" },
            new LineStation{BusStationKey = 947643, Latitude = 33.6551, Longitude = 121.3641, adress = "מעלה משואות יצחק 6, אפרת" },
            new LineStation{BusStationKey = 949653, Latitude = 33.6531, Longitude = 121.7651, adress = "מעלה משואות יצחק 7, אפרת" },
            new LineStation{BusStationKey = 835125, Latitude = 33.0912, Longitude = 121.8761, adress = "התירוש 6, אפרת" },
            new LineStation{BusStationKey = 091235, Latitude = 33.8713, Longitude = 121.8721, adress = "התירוש 7, אפרת" },
            new LineStation{BusStationKey = 949823, Latitude = 33.8342, Longitude = 121.0452, adress = "התירוש 1, אפרת" },
        };
                BusLine b1 = new BusLine(Stops1, Stops1.ElementAt(0), Stops1.ElementAt(Stops1.Count - 1), 1, "עוזיאל");
                BusLine b2 = new BusLine(Stops2, Stops2.ElementAt(0), Stops2.ElementAt(Stops2.Count - 1), 2, "בית וגן");
                BusLine b3 = new BusLine(Stops3, Stops3.ElementAt(0), Stops3.ElementAt(Stops3.Count - 1), 3, "התירוש");
                BusLine b4 = new BusLine(Stops4, Stops4.ElementAt(0), Stops4.ElementAt(Stops4.Count - 1), 4, "זרובבל");
                BusLine b5 = new BusLine(Stops5, Stops5.ElementAt(0), Stops5.ElementAt(Stops5.Count - 1), 5, "הפסגה");
                BusLine b6 = new BusLine(Stops6, Stops6.ElementAt(0), Stops6.ElementAt(Stops6.Count - 1), 6, "רינה ניקובה");
                BusLine b7 = new BusLine(Stops7, Stops7.ElementAt(0), Stops7.ElementAt(Stops7.Count - 1), 7, "אפרת-ירושלים");
                BusLine b8 = new BusLine(Stops8, Stops8.ElementAt(0), Stops8.ElementAt(Stops8.Count - 1), 8, "התירוש2");
                Lines.ADD_Line(b1);
                Lines.ADD_Line(b2);
                Lines.ADD_Line(b3);
                Lines.ADD_Line(b4);
                Lines.ADD_Line(b5);
                Lines.ADD_Line(b6);
                Lines.ADD_Line(b7);
                Lines.ADD_Line(b8);


                int choice = 3;

     while (choice != 0)
        {
                    Console.WriteLine(@"here are the options: 
            1. add/remove a bus: more details will come
            2. search for a bus: more details will come
            3. print details: more details will come
            0. exit");
      bool success;
      success = int.TryParse(Console.ReadLine(), out choice);
     if (!success)
          throw new ArgumentException("invalid input. try again next time");
         switch (choice)
            {
              case 1:
                  Console.WriteLine(@"
you can either create a new line with its requirements or add a station
choose 1 to add/remove a new line
choose 2 to add/remove a new station
");
              success = int.TryParse(Console.ReadLine(), out choice);
              if (!success)
                  throw new ArgumentException("invalid input. try again next time");
               else
                 {
                    LineStation X = new LineStation();
                     switch (choice)
                      {

                            case 1: // the setting for a line. we need to build a line of we are adding to the system
                            Console.WriteLine(@"you have chosen to add or remove a line. enter '1' to add, '2' to remove a line
");
                            success = int.TryParse(Console.ReadLine(), out choice);
                            if (!success)
                                  throw new ArgumentException("invalid input. try again next time");
                         switch (choice)
                         {

                                            case 1:
                                 Console.WriteLine(@"
we are entering the new line section for adding
 a new line needs the following requirements:
    1. the station ID can't belong to another station
    2. line must have two stops
    lets start by entering one bus at a time. for the bus ID type 0 if you are done
");
                                 List<LineStation> stations = new List<LineStation>();
                                 Console.WriteLine("for the first station, the time from previous and distance is 0");

                                 X.fillfields();
                                 while (X.getkey() != 0)
                                     {
                                       X.fillfields();
                                       if (X.getkey() == 0)
                                           {
                                               break;
                                           }
                                       else
                                           {
                                              if (!(Lines.check_location(X)))
                                                   {
                                                      throw new ArgumentException("Some property already exists in the system!");
                                                   }
                                           stations.Add(X);
                                           }
                                     }
                                 Console.WriteLine("enter the number of the new line");
                                 success = int.TryParse(Console.ReadLine(), out choice);
                                 if (!success)
                                       throw new ArgumentException("invalid input. try again next time");
                                        string str;
                                        Console.WriteLine("enter the adresses the busline stops at/name of the line");
                                        str = Console.ReadLine();
                                        BusLine bn = new BusLine(stations, stations.ElementAt(0), stations.ElementAt(stations.Count - 1), choice, str);
                                        if (!(bn.checknum()))
                                           {
                                              throw new ArgumentException("Not enough stations");
                                           }
                                         Lines.ADD_Line(bn);
                                         break;
                                            case 2:
                                                Console.WriteLine("enter the id of the line to remove");
                                                success = int.TryParse(Console.ReadLine(), out choice);
                                                if (!success)
                                                    throw new ArgumentException("invalid input. try again next time");
                                                Lines.Delete_Line(choice);
                                                break;
                                            default:
                                                throw new ArgumentException("you did not enter 1 or 2");
                         }
                             break;
                          case 2:
                                        Console.WriteLine(@"
you have chosen to add or remove.
an option will come for you to enter details of a bus station in preperations to adding it. 
");

                                X.fillfields(); // will add the fields as the override
                                Console.WriteLine("enter the id of the list we will remove from / add to");

                                success = int.TryParse(Console.ReadLine(), out choice);
                                if (!success)
                                      throw new ArgumentException("invalid input. try again next time");
                                foreach (BusLine item in Lines)
                                     {
                                       if (item.get_line_num() == choice)
                                            item.AddOrRemove(X);
                                       Console.WriteLine("enter 0 to stop, any other number we will get a new enter");
                                       success = int.TryParse(Console.ReadLine(), out choice);
                                       if (!success)
                                            throw new ArgumentException("invalid input. try again next time");
                                       else
                                            {
                                                if (choice == 0)
                                                    break;
                                            }
                                     }
                            break;
                            default:
                                Console.WriteLine("invalid input. try again next time");
                                break;
                                }

                            }
                            break;
                        case 2:
                            Console.WriteLine("Press 1 to search station and see the bus list, or press 2 to find route between two stations");
                            success = int.TryParse(Console.ReadLine(), out choice);
                            if (!success)
                                throw new ArgumentException("invalid input. try again next time");
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Enter Station key");
                                    int key = Convert.ToInt32(Console.ReadLine());
                                    bool flag = false;
                                    foreach (BusLine l1 in Lines)
                                    {
                                        if (l1.exists(key))
                                        {
                                            Console.WriteLine("Bus Number {0} passes in this station", l1.LineStation);
                                            flag = true;
                                        }
                                    }
                                    if (flag == false)
                                    {
                                        throw new ArgumentException("No buses passing through this station");
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("enter id of the first station:");
                                    int first = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("enter id of the second station:");
                                    int second = Convert.ToInt32(Console.ReadLine());
                                    List<BusLine> FirstList = Lines.LinesInStop(first);
                                    List<BusLine> SecondList = Lines.LinesInStop(second);
                                    List<BusLine> SortedResult = new List<BusLine>();
                                    foreach (BusLine l1 in FirstList)
                                    {
                                        foreach (BusLine l2 in SecondList)
                                        {
                                            if (l1.LineStation == l2.LineStation)
                                            {
                                                SortedResult.Add(l1);
                                            }
                                        }
                                    }
                                    SortedResult.Sort();
                                    foreach (BusLine l1 in SortedResult)
                                    {
                                        Console.WriteLine("Line Number {0} is good for you.", l1.LineStation);
                                    }
                                    break;
                                   
                            }
                            break;
                                 case 3: 
                                    Console.WriteLine("welocome to the print menu. there are two options");
                                    Console.WriteLine("press 1 to print all lines. 2 to print all stations");
                                    success = int.TryParse(Console.ReadLine(), out choice);
                                    if (!success)
                                        throw new ArgumentException("invalid input. try again next time");
                                    switch (choice)
                                    {
                                        case 1:
                                            Console.WriteLine("Buses in system:");
                                            foreach (BusLine l1 in Lines)
                                            {
                                                Console.WriteLine(l1.LineStation);
                                            }
                                            break;
                                        case 2:
                                            Console.WriteLine("Stations in system:");

                                            for (int i = 0; i < 999999; i++)
                                            {
                                                foreach (BusLine l1 in Lines)
                                                {
                                                    if (l1.exists(i))
                                                    {
                                                        if (success)
                                                        {
                                                            Console.WriteLine("Station number {0}", i);
                                                        }
                                                        success = false;
                                                        Console.WriteLine("Bus Number {0} passes in this station", l1.LineStation);
                                                    }
                                                }
                                                success = true;
                                            }
                                            break;
                                        default:
                                    throw new ArgumentException("invalid input. try again next time");
                                    
                                    }
                                    break;
                                case 0:
                                    Console.WriteLine("thanks for choosing eggedish");
                                    break;
                                default:
                                    throw new ArgumentException("invalid input. try again next time");
                            }

                    }

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("program ending. enter correctly and no-one gets hurt");
            }
        }

    }
}