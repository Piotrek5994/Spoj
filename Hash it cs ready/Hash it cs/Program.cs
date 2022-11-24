using System;

namespace Hash_it_cs
{
    internal class Program
    {
		public static bool add(string[] my_map, string key)
		{
			int h;
			int hash;
			int new_hash;
			h = 0;
			for (int i = 0; i < key.Length; i++)
			{
				h += (int)key[i] * (i + 1);
			}
			hash = (h * 19) % 101;
			
			if (my_map[hash] == key)
			{
				
				return false;
			}
			
			else
			{
				for (int j = 1; j <= 19; j++)
				{
					new_hash = (hash + (23 * j) + (j * j)) % 101;
					if (my_map[new_hash] == key)
					{
						return false;
					}
				}
			}
			
			if (my_map[hash] == "")
			{
				my_map[hash] = key;
				return true;
			}
			for (int j = 1; j <= 19; j++)
			{
				new_hash = (hash + (j * j) + (23 * j)) % 101;
				
				if (my_map[new_hash] == "")
				{
					my_map[new_hash] = key;
					return true;
				}
			}
			return false;
		}

		public static bool del(string[] my_map, string key)
		{
			for (int i = 0; i < 101; i++)
			{
				
				if (my_map[i] == key)
				{
					my_map[i] = "";
					return true;
				}
			}
			return false;
		}
		static void Main(string[] args)
        {
			int N;
			int m;
			int number_of_entries;
			string op = "";
			string key = "";
			string[] my_map = Arrays.InitializeStringArrayWithDefaultInstances(101);
			N = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			for (int testcase = 0; testcase < N; testcase++)
			{
				m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				
				number_of_entries = 0;
				
				for (int i = 0; i < 101; i++)
				{
					my_map[i] = "";
				}
				for (int operation = 0; operation < m; operation++)
				{
					op = ConsoleInput.ReadToWhiteSpace(true);
					
					if (op.Substring(0, 3) == "ADD")
					{
						key = op.Substring(4);
						if (add(my_map, key))
						{
							number_of_entries += 1;
						}
					}
					
					else if (op.Substring(0, 3) == "DEL")
					{
						key = op.Substring(4);
						if (del(my_map, key))
						{
							number_of_entries -= 1;
						}
					}
				}
				
				Console.Write(number_of_entries);
				Console.Write("\n");
				for (int i = 0; i < 101; i++)
				{
					if (my_map[i] != "")
					{
						Console.Write(i);
						Console.Write(":");
						Console.Write(my_map[i]);
						Console.Write("\n");
					}
				}
			}
		}
    }
	internal static class ConsoleInput
	{
		private static bool goodLastRead = false;
		public static bool LastReadWasGood
		{
			get
			{
				return goodLastRead;
			}
		}

		public static string ReadToWhiteSpace(bool skipLeadingWhiteSpace)
		{
			string input = "";

			char nextChar;
			while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
			{
				
				if (!skipLeadingWhiteSpace)
					input += nextChar;
			}
			
			input += nextChar;

			
			while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
			{
				input += nextChar;
			}

			goodLastRead = input.Length > 0;
			return input;
		}

		public static string ScanfRead(string unwantedSequence = null, int maxFieldLength = -1)
		{
			string input = "";

			char nextChar;
			if (unwantedSequence != null)
			{
				nextChar = '\0';
				for (int charIndex = 0; charIndex < unwantedSequence.Length; charIndex++)
				{
					if (char.IsWhiteSpace(unwantedSequence[charIndex]))
					{
						
						while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
						{
						}
					}
					else
					{
						
						nextChar = (char)System.Console.Read();
						if (nextChar != unwantedSequence[charIndex])
							return null;
					}
				}

				input = nextChar.ToString();
				if (maxFieldLength == 1)
					return input;
			}

			while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
			{
				input += nextChar;
				if (maxFieldLength == input.Length)
					return input;
			}

			return input;
		}
	}
	internal static class Arrays
	{
		public static T[] InitializeWithDefaultInstances<T>(int length) where T : class, new()
		{
			T[] array = new T[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = new T();
			}
			return array;
		}

		public static string[] InitializeStringArrayWithDefaultInstances(int length)
		{
			string[] array = new string[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = "";
			}
			return array;
		}

		public static T[] PadWithNull<T>(int length, T[] existingItems) where T : class
		{
			if (length > existingItems.Length)
			{
				T[] array = new T[length];

				for (int i = 0; i < existingItems.Length; i++)
				{
					array[i] = existingItems[i];
				}

				return array;
			}
			else
				return existingItems;
		}

		public static T[] PadValueTypeArrayWithDefaultInstances<T>(int length, T[] existingItems) where T : struct
		{
			if (length > existingItems.Length)
			{
				T[] array = new T[length];

				for (int i = 0; i < existingItems.Length; i++)
				{
					array[i] = existingItems[i];
				}

				return array;
			}
			else
				return existingItems;
		}

		public static T[] PadReferenceTypeArrayWithDefaultInstances<T>(int length, T[] existingItems) where T : class, new()
		{
			if (length > existingItems.Length)
			{
				T[] array = new T[length];

				for (int i = 0; i < existingItems.Length; i++)
				{
					array[i] = existingItems[i];
				}

				for (int i = existingItems.Length; i < length; i++)
				{
					array[i] = new T();
				}

				return array;
			}
			else
				return existingItems;
		}

		public static string[] PadStringArrayWithDefaultInstances(int length, string[] existingItems)
		{
			if (length > existingItems.Length)
			{
				string[] array = new string[length];

				for (int i = 0; i < existingItems.Length; i++)
				{
					array[i] = existingItems[i];
				}

				for (int i = existingItems.Length; i < length; i++)
				{
					array[i] = "";
				}

				return array;
			}
			else
				return existingItems;
		}

		public static void DeleteArray<T>(T[] array) where T : System.IDisposable
		{
			foreach (T element in array)
			{
				if (element != null)
					element.Dispose();
			}
		}
	}
}
