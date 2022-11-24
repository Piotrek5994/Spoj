using System;
using System.Collections.Generic;

internal class Program
{
    static int m;
    static int[] a = new int[8];
    static int[] assignment = new int[8];
    static int finalAns = 0;
    static List<int>[] Adjlist = new List<int>[8];

    private static void backtrack(int n)
    {
        for (int i = 0; i < 2; i++)
        {
            assignment[n] = i;
            if (n == 7)
            {
                bool satisfied = true;
                for (int j = 0; j < 8; j++)
                    if (assignment[j] == 1)
                    {
                        for (int zz = 0; zz < Adjlist[j].Count; zz++)
                            if (assignment[Adjlist[j][zz]] == 1)
                                satisfied = false;
                    }
                if (satisfied)
                {
                    int tmp = 0;
                    for (int j = 0; j < 8; j++)
                        if (assignment[j] == 1)
                        {
                            tmp += a[j];
                        }
                    if (tmp > finalAns)
                        finalAns = tmp;
                }
            }
            else
                backtrack(n + 1);
            assignment[n] = 0;
        }
    }

    public static void Main(string[] args)
    {
        for (int i = 0; i < 8; i++)
            Adjlist[i] = new List<int>();
        a = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
        m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++)
        {
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Adjlist[nums[0] - 1].Add(nums[1] - 1);
            Adjlist[nums[1] - 1].Add(nums[0] - 1);
        }

        backtrack(0);
        Console.WriteLine(finalAns);
    }
}