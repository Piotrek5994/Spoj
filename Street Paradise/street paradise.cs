using System;
using System.Collections.Generic;

namespace STPAR
{
    class Program
    {
        static void Main(string[] args)
        {
            int Street;
            while ((Street = int.Parse(Console.ReadLine())) != 0)
            {
                int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                Console.WriteLine(Problem.Answer(arr) ? "yes" : "no");
            }
        }
    }

    public static class Problem
    {
        public static bool Answer(int[] arr)
        {
            var help = new Stack<int>();
            int next = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                while (help.Count > 0 && help.Peek() == next)
                {
                    help.Pop();
                    next++;
                }

                int con = arr[i];
                if (con == next)
                {
                    next++;
                }
                else if (help.Count == 0 || con < help.Peek())
                {
                    help.Push(con);
                }
                else return false;
            }
            return true;
        }
    }
}
