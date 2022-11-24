using System;
using System.Numerics;


public static class MARBLES
{
   
    public static BigInteger Solve(int marbleCount, int colorCount)
        => NumberOfCombinations(marbleCount - 1, colorCount - 1);

   
    private static BigInteger NumberOfCombinations(int n, int k)
    {
        k = Math.Min(k, n - k);
        if (k == 0)
            return 1;

        BigInteger result = n;
        for (int denominator = 2; denominator <= k; ++denominator)
        {
           
            result *= n - denominator + 1;
            result /= denominator;
        }

        return result;
    }
}

public static class Program
{
    private static void Main()
    {
        int remainingTestCases = int.Parse(Console.ReadLine());
        while (remainingTestCases-- > 0)
        {
            int[] line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(
                MARBLES.Solve(line[0], line[1]));
        }
    }
}