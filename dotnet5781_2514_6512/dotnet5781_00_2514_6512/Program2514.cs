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
            Wellcome5124();
            Wellcome6512();
            Console.ReadKey();
        }

        static partial void Wellcome6512();
        private static void Wellcome5124()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
    }
}