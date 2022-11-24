using System;
using System.Collections.Generic;
using System.Text;


public static class SBANK
{
   
    public static void SolveTooSlowly(int accountCount, StringBuilder output)
    {
        var accountOccurrenceCounts = new SortedDictionary<string, int>();

        while (accountCount-- > 0)
        {
            string account = Console.ReadLine();

            int occurrenceCount;
            if (accountOccurrenceCounts.TryGetValue(account, out occurrenceCount))
            {
                accountOccurrenceCounts[account] = occurrenceCount + 1;
            }
            else
            {
                accountOccurrenceCounts[account] = 1;
            }
        }
        Console.ReadLine();

        foreach (var accountOccurrenceCount in accountOccurrenceCounts)
        {
            output.AppendLine($"{accountOccurrenceCount.Key} {accountOccurrenceCount.Value}");
        }
        output.AppendLine();
    }

   
    public static void SolveFastEnough(int accountCount, StringBuilder output)
    {
        var sortedAccounts = new SortedSet<string>();
        var accountOccurrenceCounts = new Dictionary<string, int>();

        while (accountCount-- > 0)
        {
            string account = Console.ReadLine();

            int occurrenceCount;
            if (accountOccurrenceCounts.TryGetValue(account, out occurrenceCount))
            {
                accountOccurrenceCounts[account] = occurrenceCount + 1;
            }
            else
            {
                accountOccurrenceCounts[account] = 1;
                sortedAccounts.Add(account);
            }
        }
        Console.ReadLine();

        foreach (var account in sortedAccounts)
        {
            output.AppendLine($"{account} {accountOccurrenceCounts[account]}");
        }
        output.AppendLine();
    }

   
    public static void SolveEvenFaster(int accountCount, StringBuilder output)
    {
        string[] accountsCurrent = new string[accountCount];
        string[] accountsPrevious = new string[accountCount];
        for (int a = 0; a < accountCount; ++a)
        {
            accountsCurrent[a] = Console.ReadLine();
        }
        Console.ReadLine();

        for (int digit = 30; digit >= 0; --digit)
        {
            if (digit == 26 || digit == 21 || digit == 16 || digit == 11 || digit == 2)
                continue; 
          
            int[] characterCounts = new int['9' + 2];

           
            for (int a = 0; a < accountCount; ++a)
            {
                ++characterCounts[accountsCurrent[a][digit] + 1];
            }

           
            for (int c = '0'; c <= '9'; ++c)
            {
                characterCounts[c + 1] += characterCounts[c];
            }

           
            for (int a = 0; a < accountCount; ++a)
            {
                accountsPrevious[characterCounts[accountsCurrent[a][digit]]++] = accountsCurrent[a];
            }

           
            var accountsTemp = accountsPrevious;
            accountsPrevious = accountsCurrent;
            accountsCurrent = accountsTemp;
        }

        
        string account = accountsCurrent[0];
        int occurrenceCount = 1;
        for (int a = 1; a < accountCount; ++a)
        {
            if (accountsCurrent[a] == account)
            {
                ++occurrenceCount;
            }
            else 
            {
                output.AppendLine($"{account} {occurrenceCount}");

                account = accountsCurrent[a];
                occurrenceCount = 1;
            }
        }
        output.AppendLine($"{account} {occurrenceCount}");
        output.AppendLine();
    }
}

public static class Program
{
    private static void Main()
    {
        var output = new StringBuilder();
        int remainingTestCases = int.Parse(Console.ReadLine());
        while (remainingTestCases-- > 0)
        {
            SBANK.SolveEvenFaster(
                accountCount: int.Parse(Console.ReadLine()),
                output: output);
        }

        Console.Write(output);
    }
}