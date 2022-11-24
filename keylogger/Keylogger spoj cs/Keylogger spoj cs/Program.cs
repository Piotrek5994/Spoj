using System;
using System.Collections.Generic;



    
    
        int x = Int32.Parse(Console.ReadLine());
        string[] haslo = new string[x];
        for (int i = 0; i < x; i++)
        {
            string przeszlo = Console.ReadLine();
            Stack<char> right = new Stack<char>();
            Stack<char> left = new Stack<char>();
            for (int j = 0; j < przeszlo.Length; j++)
                switch (przeszlo[j])
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
                        left.Push(przeszlo[j]);
                        break;
                }
            while (left.Count != 0) right.Push(left.Pop());
            haslo[i] = new String(right.ToArray());
        }
        for (int i = 0; i < x; i++)
            Console.WriteLine(haslo[i]);
    
