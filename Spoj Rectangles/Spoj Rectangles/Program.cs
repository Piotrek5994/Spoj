using System;


public static class AE00
{
    public static int Solve(int n)
    {
        
        int cumulativeRectangleCount = 0;
        for (int s = 1; s <= n; ++s)
        {
            
            cumulativeRectangleCount += 1;

           
            for (int d = 2; d <= Math.Sqrt(s); ++d)
            {
           
                if (s % d == 0)
                {
                    cumulativeRectangleCount += 1;
                }
            }
        }

        return cumulativeRectangleCount;
    }
}

public static class Program
{
    private static void Main()
    {
        Console.WriteLine(
            AE00.Solve(int.Parse(Console.ReadLine())));
    }
}