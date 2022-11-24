using System;
using System.Text;

namespace HEAP
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			int tests = int.Parse(Console.ReadLine());
			long[][] heaps = new long[tests][];
			char[][] instructions = new char[tests][];
			
			for (int itr = 0; itr < tests; ++itr)
			{
				bool nParsed = false;
				int n;
				do
				{
					nParsed = int.TryParse(Console.ReadLine(), out n);
				} while (!nParsed);
				heaps[itr] = new long[n];
				for (int i = 0; i < n; ++i)
					heaps[itr][i] = long.Parse(Console.ReadLine());

				bool mParsed = false;
				int m;
				do
				{
					mParsed = int.TryParse(Console.ReadLine(), out m);
				} while (!mParsed);
				
				instructions[itr] = new char[m];
				for (int i = 0; i < m; ++i)
					instructions[itr][i] = char.Parse(Console.ReadLine());
			}

			for (int itr = 0; itr < tests; ++itr)
			{
				BuildHeap(ref heaps[itr]);
				foreach (var instruction in instructions[itr])
				{
					switch (instruction)
					{
						case 'P':
							PrintHeap(heaps[itr]);
							break;
						case 'E':
							Console.WriteLine(ExtractTop(ref heaps[itr]));
							BuildHeap(ref heaps[itr]);
							break;
					}
				}
			}
		}

		static void BuildHeap(ref long[] heap)
		{
			for(int i = heap.Length/2; i >= 0; i--) {
				Heapify(ref heap, heap.Length-1, i);
			}
		}
		static void Heapify(ref long[] heap, int n, long i)
		{
			long min = i;
			long left = 2*i + 1;
			long right = 2*i + 2;

			if(left <= n && heap[left] < heap[min]) {
				min = left;
			}

			if(right <= n && heap[right] < heap[min]) {
				min = right;
			}

			if(min != i) {
			
				var tmpSwap = heap[i];
				heap[i] = heap[min];
				heap[min] = tmpSwap;
				Heapify(ref heap, n, min); 
			}
		}

		static void PrintHeap(long[] heap)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (var cell in heap)
				stringBuilder.Append($"{cell} ");
			Console.WriteLine(stringBuilder.ToString());
		}

		static long ExtractTop(ref long[] heap)
		{
			int lastIndex = heap.Length - 1;
		
			var tmpSwap = heap[0];
			heap[0] = heap[lastIndex];
			heap[lastIndex] = tmpSwap;
			long extracted = heap[lastIndex];
			
			long[] newHeap = new long[lastIndex];
			
			for (int i = 0; i < lastIndex; ++i)
			{
				newHeap[i] = heap[i];
			}

			heap = newHeap;
			return extracted;
		}
	}
}