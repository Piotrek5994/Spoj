using System;
using System.Numerics;
using System.Text;

namespace SPOJ
{
    internal class Program
    {
        public static int Mod = 1000000007;
        public static int[] factorial = new int[1000000];
        public static int[] inversal = new int[1000000];

        static void Main(string[] args)
        {
            string str;
            StringBuilder result = new StringBuilder();
            BigInteger[] fac = new BigInteger[1000005];
            fac[0] = 1;
            for (int i = 1; i <= 1000000; i++)
            {
                fac[i] = i * fac[i - 1];
                fac[i] %= Mod;
            }

            while ((str = Console.ReadLine()) != null && str.Length > 0)
            {
                var line = str.Split(' ');
                int N = int.Parse(line[0]);
                int A = int.Parse(line[1]);
                int B = int.Parse(line[2]);
                int D = int.Parse(line[3]);

                result.AppendLine(Solve(N, A, B, D, fac).ToString());
            }

            Console.Write(result.ToString().TrimEnd());
        }

        public static BigInteger Solve(int n, int a, int b, int d, BigInteger[] fac)
        {
            BigInteger r1 = (((fac[n] * pow(fac[n - a], Mod - 2)) % Mod) * (pow(fac[a], Mod - 2))) % Mod;
            BigInteger r2 = pow(((((fac[b] * pow(fac[b - d], Mod - 2)) % Mod) * (pow(fac[d], Mod - 2))) % Mod),
                a);

            return (r1 * r2) % Mod;
        }

        static int pow(BigInteger a, int b)
        {
            BigInteger res = 1;
            while (b != 0)
            {
                if ((b & 1) == 1)
                {
                    res *= a;
                    res %= Mod;
                }

                a = (a * a) % Mod;
                b >>= 1;
            }

            return (int)res;
        }

        public static BigInteger Fac(int n)
        {
            BigInteger sum = n;
            BigInteger result = n;
            for (int i = n - 2; i > 1; i -= 2)
            {
                sum = (sum + i);
                result *= sum;
            }

            if (n % 2 != 0)
            {
                result *= (BigInteger)Math.Round((double)n / 2, MidpointRounding.AwayFromZero);
            }
            return result;
        }
    }
}