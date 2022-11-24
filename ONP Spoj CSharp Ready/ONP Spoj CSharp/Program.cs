using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ONP_Spoj_CSharp
{
    class TransformTheExpression
    {

        static void Main()
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                ConvertExpression();
            }
        }

        public static void ConvertExpression()
        {
            string exp = Console.ReadLine();
            if (exp == null)
            {
                throw new Exception("expression cannot be null");
            }
            StringBuilder result = new StringBuilder();
            Stack<char> symbols = new Stack<char>();
            foreach (char ch in exp)
            {
                if (ch == '(')
                    continue;
                else if (ch == ')')
                    result.Append(symbols.Pop());
                else if (char.IsLetterOrDigit(ch))
                    result.Append(ch);
                else
                    symbols.Push(ch);
            }
            Console.WriteLine(result);

        }
    }
}
