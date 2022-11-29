using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate string Action(string a, int key);
    static class  Crypto
    {
        const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static public string CodeEncode(string text, int k)
        {
            //добавляем в алфавит маленькие буквы
            var fullAlfabet = alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    //если символ не найден, то добавляем его в неизменном виде
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

        static char GetRandomKey(int k)
        {
            char gamma = '\0';
            var rnd = new Random(k);
            gamma = (char)rnd.Next(97, 123);
            return gamma;
        }

        static public string Cipher(string text, int key)
        {
       
            string res = "";
            for (var i = 0; i < text.Length; i++)
            {
                res += Convert.ToString(text[i] ^ key);
            }

            return res;
        }

        static public char aaa(char text, int key)
        {
            Thread.Sleep(key);
            return 'q';
        }
    }
}
