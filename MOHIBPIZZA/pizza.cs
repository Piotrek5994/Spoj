using System;
using System.IO;

public class Test
{
    public static void Main()
    {
        InputOutput reader = new InputOutput();
        StreamWriter _output = new StreamWriter(Console.OpenStandardOutput());

        long T = reader.ReadInt();
        for (long i = 0; i < T; i++)
        {
            _output.WriteLine(Solution(reader.ReadInt()));
        }
        _output.Flush();
    }

    private static long Solution(long n) => (long)(((long)n * n + n + 2) / 2);

    #region Input Output Helper 
    public class InputOutput : System.IDisposable
    {
        private System.IO.Stream _readStream, _writeStream;
        private int _readIdx, _bytesRead, _writeIdx, _inBuffSize, _outBuffSize;
        private readonly byte[] _inBuff, _outBuff;
        private readonly bool _bThrowErrorOnEof;

        public void SetBuffSize(int n)
        {
            _inBuffSize = _outBuffSize = n;
        }

        public InputOutput(bool throwEndOfInputsError = false)
        {
            _readStream = System.Console.OpenStandardInput();
            _writeStream = System.Console.OpenStandardOutput();
            _readIdx = _bytesRead = _writeIdx = 0;
            _inBuffSize = _outBuffSize = 1 << 22;
            _inBuff = new byte[_inBuffSize];
            _outBuff = new byte[_outBuffSize];
            _bThrowErrorOnEof = throwEndOfInputsError;
        }

        public void SetFilePath(string strPath)
        {
            strPath = System.IO.Path.GetFullPath(strPath);
            _readStream = System.IO.File.Open(strPath, System.IO.FileMode.Open);
        }

        public T ReadNumber<T>()
        {
            byte rb;
            while ((rb = GetByte()) < '-')
                ;

            var neg = false;
            if (rb == '-')
            {
                neg = true;
                rb = GetByte();
            }
            dynamic m = (T)Convert.ChangeType(rb - '0', typeof(T));
            while (true)
            {
                rb = GetByte();
                if (rb < '0')
                    break;
                m = m * 10 + (rb - '0');
            }
            return neg ? -m : m;
        }

        public int ReadInt()
        {
            byte readByte;
            while ((readByte = GetByte()) < '-')
                ;

            var neg = false;
            if (readByte == '-')
            {
                neg = true;
                readByte = GetByte();
            }
            var m = readByte - '0';
            while (true)
            {
                readByte = GetByte();
                if (readByte < '0')
                    break;
                m = m * 10 + (readByte - '0');
            }
            return neg ? -m : m;
        }

        public string ReadString()
        {
            return ReadString(' ');
        }

        public string ReadString(string delimiter)
        {
            return ReadString(delimiter[0]);
        }

        public string ReadString(char delimiter)
        {
            byte readByte;
            while ((readByte = GetByte()) <= delimiter)
                ;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            do
            {
                sb.Append((char)readByte);
            } while ((readByte = GetByte()) > delimiter);

            return sb.ToString();
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private byte GetByte()
        {
            if (_readIdx >= _bytesRead)
            {
                _readIdx = 0;
                _bytesRead = _readStream.Read(_inBuff, 0, _inBuffSize);
                if (_bytesRead >= 1)
                    return _inBuff[_readIdx++];

                if (_bThrowErrorOnEof)
                    throw new System.Exception("End Of Input");
                _inBuff[_bytesRead++] = 0;
            }
            return _inBuff[_readIdx++];
        }

        public void WriteToBuffer(string s)
        {
            foreach (var b in System.Text.Encoding.ASCII.GetBytes(s))
            {
                if (_writeIdx == _outBuffSize)
                    Flush();
                _outBuff[_writeIdx++] = b;
            }
        }

        public void WriteLineToBuffer(string s)
        {
            WriteToBuffer(s);
            if (_writeIdx == _outBuffSize)
                Flush();
            _outBuff[_writeIdx++] = 10;
        }

        public void WriteToBuffer(int c)
        {
            byte[] temp = new byte[10];
            int tempidx = 0;
            if (c < 0)
            {
                if (_writeIdx == _outBuffSize)
                    Flush();
                _outBuff[_writeIdx++] = (byte)'-';
                c = -c;
            }
            do
            {
                temp[tempidx++] = (byte)((c % 10) + '0');
                c /= 10;
            } while (c > 0);
            for (int i = tempidx - 1; i >= 0; i--)
            {
                if (_writeIdx == _outBuffSize)
                    Flush();
                _outBuff[_writeIdx++] = temp[i];
            }
        }

        public void WriteLineToBuffer(int c)
        {
            WriteToBuffer(c);
            if (_writeIdx == _outBuffSize)
                Flush();
            _outBuff[_writeIdx++] = 10;
        }

        private void Flush()
        {
            _writeStream.Write(_outBuff, 0, _writeIdx);
            _writeStream.Flush();
            _writeIdx = 0;
        }

        public void Dispose()
        {
            Flush();
            _writeStream.Close();
            _readStream.Close();
        }
    }
    #endregion Input Output Helper 

}