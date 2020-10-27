using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{
    class buses_main
    {
        const int max_fuel = 1200;// to use as we go along: maximum fuel
        enum CHOICE { EXIT, ADD, DRIVE, REFUEL, REPAIRS, MILEAGE };

        private static List<Buses> database = new List<Buses>(); // again, as requested

        static void Main(string[] args)
        {
            bool flag = false;
            CHOICE choice;
            do
            {
                bool parse_success = true;
                parse_success = Enum.TryParse(Console.ReadLine(), out choice);
                if (!parse_success)
                    continue;
                switch(choice)
                {
                    case CHOICE.ADD:
                         ADD();
                        break;
                    case CHOICE.DRIVE:
                         DRIVE(); 
                        break;
                    case CHOICE.REFUEL:
                         REFEUL();
                        break;
                    case CHOICE.REPAIRS:
                         REPAIRS(); 
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
            throw new NotImplementedException();
        }

        private static void REPAIRS()
        {
            throw new NotImplementedException();
        }

        private static void REFEUL()
        {
            throw new NotImplementedException();
        }

        private static void DRIVE()
        {
            throw new NotImplementedException();
        }

        private static void ADD()
        {
            throw new NotImplementedException();
        }
    }
