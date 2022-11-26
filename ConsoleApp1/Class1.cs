using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate char Action(char a, int key);
    static class  Crypto
    {
        const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

      static public char CodeEncode(char text, int k)
        {
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            char retVal = '\0';

            var index = fullAlfabet.IndexOf(text);
            if (index < 0)
            {
                retVal = text;
            }
            else
            {
                var codeIndex = (letterQty + index + k) % letterQty;
                retVal = fullAlfabet[codeIndex];
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

       static public char Cipher(char text, int key)
        {
            var currentKey = GetRandomKey(key);
            char res = '\0';
            res = ((char)(text ^ key));
            return res;
        }

       
    }
}
