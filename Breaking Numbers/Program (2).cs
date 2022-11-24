using System;
public class Test
{
    static void Main(string[] args)
    {
        int tests = int.Parse(Console.ReadLine());

        for (int i = 1; i <= tests; ++i)
        {
            int num = int.Parse(Console.ReadLine());
            Console.Write($"Case {i}: ");
            for (int j = 2; j <= num; ++j)
            {
                if (num % j == 0)
                {
                    while (num % j == 0)
                        num /= j;

                    Console.Write(j + " ");
                }
            }

            Console.WriteLine();

        }
    }
}
