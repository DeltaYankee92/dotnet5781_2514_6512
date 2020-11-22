using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{
    class BusLine : IComparable<BusLine>
    {


        List<LineStation> Stations = new List<LineStation>();
        BusStop FirstStation, LastStation;
        public int LineStation;
        string Area;
        public int get_line_num()
        {
            return this.LineStation;
        }
        public BusLine(List<LineStation> stations, BusStop firstStation, BusStop lastStation, int lineStation, string area)
        {
            Stations = stations;
            FirstStation = firstStation;
            LastStation = lastStation;
            LineStation = lineStation;
            Area = area;
        }
        public int CompareTo(BusLine other)
        {
            TimeSpan ThisTotalTime = new TimeSpan(0, 0, 0);
            TimeSpan OtherTotalTime = new TimeSpan(0, 0, 0);
            foreach (LineStation s in this.Stations)
            {
                ThisTotalTime += s.time;
            }
            foreach (LineStation s in other.Stations)
            {
                OtherTotalTime += s.time;
            }
            if (ThisTotalTime < OtherTotalTime)
            {
                return 1;
            }
            else if (ThisTotalTime > OtherTotalTime)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public BusLine()
        {
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
        public bool exists(int action)
        {
            foreach (LineStation b1 in Stations)
            {
                if (b1.getkey() == action)
                    return true;
            }
            return false;
        }
        internal double TimeOrDistance(LineStation a, LineStation b, int action)
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
            double count = 0;
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
        public double distance(LineStation a, LineStation b)
        {
            return TimeOrDistance(a, b, 1);
        }
        public double time(LineStation a, LineStation b)
        {
            return TimeOrDistance(a, b, 0);
        }

        public double distance(int a, int b)
        {
            if (!this.exists(a) || !this.exists(b))
                throw new ArgumentException("doesnt exist");
            LineStation temp1 = null, temp2 =null;
            foreach (LineStation it in Stations)
            {
                if (it.getkey() == a)
                    temp1 = it;
                if (it.getkey() == b)
                    temp2 = it;
            }
            return distance(temp1, temp2);
        }
        public double time(int a, int b)
        {
            if (!this.exists(a) || !this.exists(b))
                throw new ArgumentException("one or more of the stations don't exist");
            LineStation temp1 = null, temp2 = null;
            foreach (LineStation it in Stations)
            {
                if (it.getkey() == a)
                    temp1 = it;
                if (it.getkey() == b)
                    temp2 = it;
            }
            return time(temp1, temp2);
        }
        public LineStation subRoute(LineStation a, LineStation b)
        {
            if (!this.exists(a) || !this.exists(b))
                throw new ArgumentException("one or more of the stations do not exist.");

            double sum_time = 0;
            double sum_distance = 0;
            double f1;
            double f2;
            string adress;
            int newnum;
            int indexa = this.Stations.IndexOf(a);
            int indexb = this.Stations.IndexOf(b);

            if (indexa < indexb)
            {
                f1 = a.getlongitude();
                f2 = a.getlatitute();
                adress = a.getadress();
                newnum = a.getkey();
                indexa += indexb;
                indexb = indexa - indexb;
                indexa -= indexb;

            }
            else
            {
                f1 = b.getlongitude();
                f2 = b.getlatitute();
                adress = b.getadress();
                newnum = b.getkey();
            }

            for (int i = indexb; i < indexa; i++)
            {
                sum_time += this.Stations.ElementAtOrDefault(i).gettime();
                sum_distance += this.Stations.ElementAtOrDefault(i).getdistance();
            }

            return new LineStation(sum_distance, sum_time, newnum, f1, f2, adress);
        }

        public bool check_location(LineStation a)
        {
            foreach (LineStation item in Stations)
            {
                if(item.getkey()==a.getkey())// could be an and. thats longer though
                    if(item.getadress()!=a.getadress()||(item.getlatitute()!=a.getlatitute())||(item.getlongitude()!=a.getlongitude()))
                return false;
            }
            return true;
        }
        public bool checknum()
        {
            if (this.Stations.Count <= 1)
                return false;
            return true;
        }   
    }
}
