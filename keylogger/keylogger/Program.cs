using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//[DllImport("User32.dll")]
//static extern int GetAsyncKeyState(Int32 i);

while (true)
{
    Thread.Sleep(100);
    
    {
        for (int i = 0; i < 127; i++)
        {
            
            
                ConsoleKey key = Console.ReadKey().Key;



                
                if (key == ConsoleKey.RightArrow)
                    Console.Write(">");
                else if (key == ConsoleKey.LeftArrow)
                    Console.Write("<");
                else if (key == ConsoleKey.Backspace)
                    Console.Write("-"+", ");
          

        }

    }



}
