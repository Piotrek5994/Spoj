using System;
using System.Numerics;
using System.Text;

namespace SPOJ_TPC07
{
    public class Program
    {
        private static int[] COEFFICIENT = {
            1,1,1,1,1,2,2,2,2,2,4,4,4,4,4,6,6,6,6,6,9,9,9,9,9,13,13,13,13,13,18,18,18,18,18,24,24,24,24,24,31,31,31,31,31,39,39,39,39,39,
            45,45,45,45,45,52,52,52,52,52,57,57,57,57,57,63,63,63,63,63,67,67,67,67,67,69,69,69,69,69,69,69,69,69,69,67,67,67,67,67,63,63,
            63,63,63,57,57,57,57,57,52,52,52,52,52,45,45,45,45,45,39,39,39,39,39,31,31,31,31,31,24,24,24,24,24,18,18,18,18,18,13,13,13,13,
            13,9,9,9,9,9,6,6,6,6,6,4,4,4,4,4,2,2,2,2,2,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

        static void Main(string[] args)
        {
            string line;
            var result = new StringBuilder();

            while ((line = Console.ReadLine()) != null && line.Length > 0)
            {
                int n = int.Parse(line);


                int[] x = new int[10];
                x[0] = n % 50;
                int lx = 1;


                for (int i = 1; ; ++i)
                {
                    x[i] = x[i - 1] + 50;
                    if (x[i] >= COEFFICIENT.Length || x[i] > n)
                    {
                        break;
                    }
                    lx++;
                }


                int sn = (n - x[lx - 1]) / 50 + 4;

                BigInteger top = new BigInteger(sn);

                for (int i = 1; i < 4; ++i)
                {
                    top = BigInteger.Multiply(top, sn - i);
                }

                top = BigInteger.Divide(top, 24);


                BigInteger sum = BigInteger.Zero;
                int tn = sn;

                for (int i = lx - 1; i >= 0; --i)
                {
                    sum = BigInteger.Add(sum, BigInteger.Multiply(top, COEFFICIENT[x[i]]));
                    top = BigInteger.Divide(BigInteger.Multiply(top, tn + 1), tn - 3);
                    tn++;
                }

                result.AppendLine(sum.ToString());
            }

            Console.Write(result.ToString().TrimEnd());
        }

        static int powmod(BigInteger a, int b)
        {
            BigInteger res = 1;
            while (b != 0)
            {
                if ((b & 1) == 1)
                {
                    res *= a;
                }

                a = (a * a);
                b >>= 1;
            }
            return (int)res;
        }

        public static BigInteger Factorial(long n)
        {
            BigInteger sum = n;
            BigInteger result = n;
            for (long i = n - 2; i > 1; i -= 2)
            {
                sum = (sum + i);
                result *= sum;
            }
            if (n % 2 != 0)
                result *= (BigInteger)Math.Round((double)n / 2, MidpointRounding.AwayFromZero);

            return result;
        }

        public static BigInteger Combination(long n, long k)
        {
            if (k > n)
            {
                return 0;
            }
            else if (k == n) return 1;

            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }
    }
}