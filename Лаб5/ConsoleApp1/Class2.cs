using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    static class Formatter
    {
        public static void FormatOut(Queue<Ask> list)
        {
            //while (list.Count > 0)
            foreach (Ask a in list)
                FElem(a);
            //FElem(list.Dequeue());

            for(int i = 0; i < list.Peek().work_time.Length - 1; i++)
            {

            }
            Console.WriteLine($"Total wait time in queue {ss}");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        }
        static long ss = 0; 
        public static void FElem(Ask element)
        {
            long summ = 0;
            for(int i = 0; i<element.work_time.Length-1;i++)
            {
                summ += (element.out_time[i] - element.in_time[i]) / 10000;
                Console.WriteLine($"Conv {i}: {element.state[i]} -> {element.state[i+1]}" + "|" + $"in q {element.in_time[i]}, out q {element.out_time[i]}, wait {(element.out_time[i] - element.in_time[i])/10000}; work {element.work_time[i]/10000}");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
            ss += summ;
            Console.WriteLine($"All time wait {summ}");
                Console.WriteLine("**************************************************************************************************");
        }
    }
}
