using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     delegate string Action(Ask a, int key,int i);
    static class  Crypto
    {
        const string alfabet = "abcdefghijklmnopqrstuvwxyz";

        static public string CodeEncode(Ask text, int k, int id)
        {
            //добавляем в алфавит маленькие буквы
            //  var fullAlfabet = alfabet.ToLower();
            long s = DateTime.Now.Ticks;
            var letterQty = alfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.elem.Length; i++)
            {
                var c = text.elem[i];
                var index = alfabet.IndexOf(c);
                if (index < 0)
                {
                    //если символ не найден, то добавляем его в неизменном виде
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += alfabet[codeIndex];
                }
            }
            text.work_timeF[id] = DateTime.Now.Ticks-s;
            //   Thread.Sleep(2);
            return retVal;
        }

        static char GetRandomKey(int k)
        {
            char gamma = '\0';
            var rnd = new Random(k);
            gamma = (char)rnd.Next(97, 123);
            return gamma;
        }

        static public string Cipher(Ask text, int key, int id)
        {
            long s = DateTime.Now.Ticks;
            string res = "";
            for (var i = 0; i < text.elem.Length; i++)
            {
                res += Convert.ToString(text.elem[i] ^ key);
            }
           //   Thread.Sleep(1);
            text.work_timeF[id] = DateTime.Now.Ticks - s;
            return res;
        }

        static public char aaa(char text, int key)
        {
            Thread.Sleep(key);
            return 'q';
        }
    }
}
