using System;
using System.IO;
using System.Text;

public class Program
{
    public static void Main()
    {
        Reader r = new Reader();
        StringBuilder sb = new StringBuilder();
        long n;
        while ((n = r.next()) != 0)
        {
            long noOfTeams = (((n * (n - 1)) % 1000000007) * Power(2, n - 2, 1000000007)) % 1000000007;
            sb.Append(noOfTeams);
            sb.Append('\n');
        }

        Console.Write(sb.ToString());
    }

    private static long Power(long x, long y, long p)
    {
        long result = 1;
        x = x % p;
        while (y > 0)
        {
            if ((y & 1) == 1)
            {
                result = (result * x) % p;
            }

            y = y >> 1;
            x = (x * x) % p;
        }

        return result;
    }

    class Reader
    {
        int BUFFER_SIZE = 1 << 16;
        BinaryReader dis;
        byte[] buffer;
        int bufferPointer, bytesRead;

        public Reader()
        {
            dis = new BinaryReader(Console.OpenStandardInput(), Encoding.ASCII);
            buffer = new byte[BUFFER_SIZE];
            bufferPointer = bytesRead = 0;
        }

        public int next()
        {
            int ret = 0;
            byte c = read();
            while (c <= ' ')
            {
                c = read();
            }

            do
            {
                ret = ret * 10 + c - '0';
            } while ((c = read()) >= '0' && c <= '9');

            return ret;
        }

        private void fillBuffer()
        {
            bytesRead = dis.Read(buffer, bufferPointer = 0, BUFFER_SIZE);
            if (bytesRead == -1)
            {
                buffer[0] = 0;
            }
        }

        private byte read()
        {
            if (bufferPointer == bytesRead)
            {
                fillBuffer();
            }

            return buffer[bufferPointer++];
        }
    }
}