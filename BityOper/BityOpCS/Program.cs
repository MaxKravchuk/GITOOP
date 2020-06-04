using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BityOpCS
{
    class Program
    {
        static int Decrease(int a)
        {
            int b = ~-a;
            return b;
        }
        static void HiB(int a, int b)
        {
            int ans = b & ((a - b) >> 31) | a & (~(a - b) >> 31);
            Console.WriteLine("{0} is bigger",ans);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\tKravchuk Maxim\n\tIS-92");
            Console.WriteLine("Enter First and Second digits");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            HiB(a, b);
            Console.WriteLine("{0} - 1 = {1}\n{2} - 1 = {3}", a, Decrease(a), b, Decrease(b));
        }
    }
}
