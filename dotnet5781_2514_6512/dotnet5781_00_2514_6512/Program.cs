using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{
    partial class Program
    {
        static void Main(string[] args)
        {
            newproject();
            Wellcome5124();
            Console.ReadKey();
        }

        static partial void Wellcome5124();
        private static void newproject()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
    }
}