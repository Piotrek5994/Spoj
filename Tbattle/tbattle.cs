using System;

public static class Problem
{

	public static readonly int me = 100025;
	public static readonly int max = 20;

	public static int n;
	public static int[] a = new int[me];
	public static int[,] st = new int[me, max];

	public static int get(int x, int y)
	{
		int z = 1;
		for (int i = max; i >= 0; i--)
		{
			if (x + (1 << i) - 1 <= y)
			{
				z = (int)(1L * z * st[x, i] % n);
				x += 1 << i;
			}
		}
		return z;
	}

	internal static void Main(string[] args)
	{

		string str1 = Console.ReadLine();
		if (str1 != null)
		{
			n = int.Parse(str1);
		}
		for (int i = 1; i <= n; i++)
		{
			string str2 = Console.ReadLine();
			if (str2 != null)
			{
				Problem.a[i] = int.Parse(str2);
			}
		}
		for (int i = 1; i <= n; i++)
		{
			st[i, 0] = Problem.a[i] % n;
		}
		for (int j = 1; j < max; j++)
		{
			for (int i = 1; i + (1 << j) - 1 <= n; i++)
			{
				st[i, j] = (int)(1L * st[i, j - 1] * st[i + (1 << (j - 1)), j - 1] % n);
			}
		}
		int a = n + 1;
		int b = n + 1;
		for (int i = 1; i <= n; i++)
		{
			if (get(i, n) != 0)
			{
				continue;
			}
			int low = i;
			int high = n;
			int mid;
			int best = n;
			while (low <= high)
			{
				mid = (low + high + 1) >> 1;
				if (get(i, mid) == 0)
				{
					best = mid;
					high = mid - 1;
				}
				else
				{
					low = mid + 1;
				}
			}
			if (best - i + 1 < a)
			{
				a = best - i + 1;
				b = i;
			}
		}
		if (a == n + 1)
		{
			Console.Write(-1);
			Console.Write("\n");
		}
		else
		{
			Console.Write(b - 1);
			//Console.Write(" ");
			Console.Write(b + a - 2);
			Console.Write("\n");
		}

	}
}