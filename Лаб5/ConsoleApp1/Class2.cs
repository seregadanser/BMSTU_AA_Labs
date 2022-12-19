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
            ss = 0;
            ww = 0;
            //while (list.Count > 0)
            foreach (Ask a in list)
                FElem(a);
            //FElem(list.Dequeue());

           
            Console.WriteLine($"Total wait time in queue {ss}, work time {ww}");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        }
        static long ss = 0;
        static long ww = 0;
        public static void FElem(Ask element)
        {
            long summ = 0;
            long w = 0;
            for(int i = 0; i<element.work_time.Length-1;i++)
            {
                w += element.work_time[i];
                //{element.state[i]} -> {element.state[i+1]}" + "|" 
                summ += (element.out_time[i] - element.in_time[i]);
            
           //  Console.WriteLine($"Conv {i}:" + $"in q {element.in_time[i]}, out q {element.out_time[i]}, wait {(element.out_time[i] - element.in_time[i])}; work {element.work_time[i]}; workF {element.work_timeF[i]}");
           //   Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
            ww += w;
            ss += summ;
           // Console.WriteLine($"All time wait {summ}");
           //     Console.WriteLine("**************************************************************************************************");
        }
    }
}
