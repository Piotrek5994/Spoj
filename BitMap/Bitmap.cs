using System;
using System.Collections.Generic;
using System.Text;


public static class BITMAP
{
    private static readonly Tuple<int, int>[] _neighborPixelTransformations = new[]
    {
        Tuple.Create(-1, 0), Tuple.Create(1, 0),
        Tuple.Create(0, -1), Tuple.Create(0, 1),
    };

    public static int?[,] Solve(int rowCount, int columnCount, string[] zeroOneRows)
    {
        int?[,] nearestWhitePixelDistances = new int?[rowCount, columnCount];
        var pixelsToFloodFrom = new Queue<Tuple<int, int>>();

    
        for (int r = 0; r < rowCount; ++r)
        {
            for (int c = 0; c < columnCount; ++c)
            {
                if (zeroOneRows[r][c] == '1')
                {
                    nearestWhitePixelDistances[r, c] = 0;
                    pixelsToFloodFrom.Enqueue(Tuple.Create(r, c));
                }
            }
        }

        while (pixelsToFloodFrom.Count > 0)
        {
            int waveSize = pixelsToFloodFrom.Count;
            for (int i = 0; i < waveSize; ++i)
            {
                Tuple<int, int> floodPixel = pixelsToFloodFrom.Dequeue();
                int floodPixelRow = floodPixel.Item1;
                int floodPixelColumn = floodPixel.Item2;
                int nearestWhitePixelDistance
                    = nearestWhitePixelDistances[floodPixelRow, floodPixelColumn].Value + 1;

                foreach (var neighborPixelTransformation in _neighborPixelTransformations)
                {
                    int neighborPixelRow = floodPixelRow + neighborPixelTransformation.Item1;
                    int neighborPixelColumn = floodPixelColumn + neighborPixelTransformation.Item2;

                    if (neighborPixelRow >= 0 && neighborPixelRow < rowCount
                        && neighborPixelColumn >= 0 && neighborPixelColumn < columnCount
                        && !nearestWhitePixelDistances[neighborPixelRow, neighborPixelColumn].HasValue)
                    {
                        nearestWhitePixelDistances[neighborPixelRow, neighborPixelColumn]
                            = nearestWhitePixelDistance;
                        pixelsToFloodFrom.Enqueue(Tuple.Create(neighborPixelRow, neighborPixelColumn));
                    }
                }
            }
        }

        return nearestWhitePixelDistances;
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
            int rowCount = line[0];
            int columnCount = line[1];

            string[] zeroOneRows = new string[rowCount];
            for (int r = 0; r < rowCount; ++r)
            {
                zeroOneRows[r] = Console.ReadLine();
            }

            var output = new StringBuilder();
            int?[,] nearestWhitePixelDistances = BITMAP.Solve(rowCount, columnCount, zeroOneRows);
            for (int r = 0; r < rowCount; ++r)
            {
                output.Append(nearestWhitePixelDistances[r, 0]);
                for (int c = 1; c < columnCount; ++c)
                {
                    output.Append($" {nearestWhitePixelDistances[r, c]}");
                }
                output.AppendLine();
            }

            Console.Write(output);
            Console.ReadLine();
        }
    }
}