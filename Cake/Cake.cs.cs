using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions
{
    class CUTCAKE
    {
        static void Main()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                long totalGuest = long.Parse(Console.ReadLine());
                long min = 0;
                long max = 1000000;
                while (min < max)
                {
                    long mid = min + (max - min) / 2;
                    long g = ((mid * (mid + 1)) / 2) + 1;
                    if (g < totalGuest)
                    {
                        min = mid + 1;
                    }
                    else
                    {
                        max = mid;
                    }
                }
                Console.WriteLine(min);
                t--;
            }
        }
    }
}