using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        int l = Int32.Parse(Console.ReadLine());
        string[] passwords = new string[l];
        for (int i = 0; i < l; i++)
        {
            string pass = Console.ReadLine();
            Stack<char> left = new Stack<char>();
            Stack<char> right = new Stack<char>();
            for (int j = 0; j < pass.Length; j++)
                switch (pass[j])
                {
                    case '-':
                        if (left.Count != 0)
                            left.Pop();
                        break;
                    case '<':
                        if (left.Count != 0)
                            right.Push(left.Pop());
                        break;
                    case '>':
                        if (right.Count != 0)
                            left.Push(right.Pop());
                        break;
                    default:
                        left.Push(pass[j]);
                        break;
                }
            while (left.Count != 0) right.Push(left.Pop());
            passwords[i] = new String(right.ToArray());
        }
        for (int i = 0; i < l; i++)
            Console.WriteLine(passwords[i]);
    }
}