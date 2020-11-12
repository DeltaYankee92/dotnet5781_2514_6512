using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{
    class BusLine : IComparable
    {
        List<LineStation> Stations = new List<LineStation>();
        BusStop FirstStation, LastStation;
        int LineStation;
        string Area;

        public BusLine(List<LineStation> stations, BusStop firstStation, BusStop lastStation, int LineStation, string area)
        {
            Stations = stations;
            FirstStation = firstStation;
            LastStation = lastStation;
            LineStation = LineStation;
            Area = area;
        }

        public override string ToString()
        {
            string str = $"LineStation:{this.LineStation},Area:{this.Area},All_stations:";
            foreach (LineStation bs in Stations)
            {
                str += bs.ToString();
                str += " ";
            }
            return str;
        }

        public void AddOrRemove(LineStation action)
        {
            Console.WriteLine("would you like to add or remove?");// see here i'm not looking if its in the list, because its theoritaclly possible for a bus to stop at the same stop twice in one line.
            string str;
            str = Console.ReadLine();
            if (str == "remove")
            {
                bool success = Stations.Remove(action);
                if (success == true)
                    Console.WriteLine("remove was successful");
                else
                    throw new ArgumentException("object not found");
            }
            else if (str == "add")
            {
                Console.WriteLine("there are 3 ways to add a bus. enter 1 to add for begginning, 2 for the middle (you will need to enter a bus number), 3 for the end");
                bool success;
                int todo;
                success = int.TryParse(Console.ReadLine(), out todo);
                if (success)
                    switch (todo)
                    {
                        case 1:
                            Stations.Insert(0, action);
                            break;
                        case 2:
                            success = int.TryParse(Console.ReadLine(), out todo);
                            if (success)
                            {
                                int i = 0;
                                foreach (LineStation it in Stations)
                                {
                                    if (it.getkey() == todo)
                                    {
                                        Stations.Insert(i, action);
                                        return;
                                    }
                                    i++;
                                }
                                throw new ArgumentException("no bus with that number is in the list");
                            }
                            else
                                throw new ArgumentException("invalid input. try again next time");
                        case 3:
                            Stations.Add(action);
                            break;
                        default:
                            throw new ArgumentException("invalid input. try again next time");
                    }
                else
                    throw new ArgumentException("invalid input. try again next time");
            }
            else
                throw new ArgumentException("invalid input. try again next time");
        }

        public bool exists(LineStation action)
        {
            foreach (LineStation b1 in Stations)
            {
                if (b1.getkey() == action.getkey())
                    return true;
            }
            return false;
        }
        internal int TimeOrDistance(LineStation a, LineStation b, int action)
        {
            bool flag = true; // a before b on the list
            int place1 = this.Stations.IndexOf(a);
            int place2 = this.Stations.IndexOf(b);
            if (place1 < place2)
            {
                place1 += place2;
                place2 = place1 - place2;
                place1 -= place2;
                flag = false; // if the place for b was bigger than the place for a, aka b before a
            }
            if (place1 == place2 || place1 == this.Stations.Count || place2 == 0)
                throw new IndexOutOfRangeException("invalid range or invalid stations");
            if (action != 1 || action != 0)
                throw new ArgumentException("not valid");

            bool usage = false;
            int count = 0;
            foreach (LineStation it in Stations)
            {
                if (flag)
                {
                    if (it.getkey() == a.getkey())
                        usage = true;
                    if (it.getkey() == b.getkey())
                        return count;
                    if (usage)
                    {
                        if (action == 0)
                            count += it.gettime();
                        else
                            count += it.getdistance();
                    }
                }
                else
                {
                    if (it.getkey() == b.getkey())
                        usage = true;
                    if (it.getkey() == b.getkey())
                        return count;
                    if (usage)
                    {
                        if (action == 0)
                            count += it.gettime();
                        else
                            count += it.getdistance();
                    }
                }

            }
            return -1; // should never happen
        }
        public int distance(LineStation a, LineStation b)
        {
            return TimeOrDistance(a, b, 1);
        }
        public int time(LineStation a, LineStation b)
        {
            return TimeOrDistance(a, b, 0);
        }

        public LineStation subRoute(LineStation a, LineStation b)
        {
            if (!this.exists(a) || !this.exists(b))
                throw new ArgumentException("one or more of the stations do not exist.");

            int sum_time = 0;
            int sum_distance = 0;
            float f1;
            float f2;
            string adress;
            int newnum;
            int indexa = this.Stations.IndexOf(a);
            int indexb = this.Stations.IndexOf(b);

            if (indexa < indexb)
            {
                f1 = a.getlongtitude();
                f2 = a.getlatitute();
                adress = a.getadress();
                newnum = a.getkey();
                indexa += indexb;
                indexb = indexa - indexb;
                indexa -= indexb;

            }
            else
            {
                f1 = b.getlongtitude();
                f2 = b.getlatitute();
                adress = b.getadress();
                newnum = b.getkey();
            }

            for (int i = indexb; i < indexa; i++)
            {
                sum_time += this.Stations.ElementAtOrDefault(i).gettime();
                sum_distance += this.Stations.ElementAtOrDefault(i).getdistance();
            }

            return new LineStation(sum_time, sum_distance, newnum, f1, f2, adress);
        }

        public int CompareTo(ref List<LineStation> other_route, LineStation a, LineStation b)
        {

        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
