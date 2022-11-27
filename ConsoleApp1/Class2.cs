using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Formatter
    {
        public static void FormatOut(Queue<Ask> list)
        {
            while (list.Count > 0)
                FElem(list.Dequeue());

        }

        public static void FElem(Ask element)
        {
            for(int i = 0; i<element.work_time.Length-1;i++)
            {
                Console.WriteLine($"{element.state[i]} -> {element.state[i+1]}" + "|" + $"in q {element.in_time[i]}, out q {element.out_time[i]}, wait {(element.out_time[i] - element.in_time[i])/10000}; work {element.work_time[i]/10000}");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            }
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        }
    }
}
