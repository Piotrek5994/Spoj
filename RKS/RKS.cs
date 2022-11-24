using System;
using System.Collections.Generic;
using System.Linq;

namespace RKS
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = input[0];
            int C = input[1];
            List<int> listOfElems = Console.ReadLine().TrimEnd().Split().ToList().
                Select(convElem => Convert.ToInt32(convElem)).ToList();

            Solve(N, C, listOfElems);
        }
        static void Solve(int N, int C, List<int> list)
        {
            Dictionary<int, int> F = new Dictionary<int, int>();
            int currentCount;
            foreach (int elem in list)
            {
                if (F.ContainsKey(elem))
                {
                    F.TryGetValue(elem, out currentCount);
                    F[elem] = currentCount + 1;
                }
                else
                {
                    F.Add(elem, 1);
                }
            }
            F = F.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            for (int i = 0; i < F.Count; i++)
            {
                for (int j = 0; j < F.ElementAt(i).Value; j++)
                {
                    Console.Write($"{F.ElementAt(i).Key} ");
                }
            }
            Console.WriteLine();
        }
    }
}