﻿using System;
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

      static public char CodeEncode(string/*char*/ text, int k)
        {
            var fullAlfabet = alfabet.ToLower();// + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            //char retVal = '\0';
            string retVal = "";

            var index = fullAlfabet.IndexOf(text);
            if (index < 0)
            {
                retVal = text;
            }
            else
            {
                int codeIndex=0;
                for (int i = 0; i < text.Length; i++)
                {
                    codeIndex = (letterQty + index + k) % letterQty;
                    retVal  += fullAlfabet[codeIndex];
                }
            }
            //Thread.Sleep(k);
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
            Thread.Sleep(key);
            return res;
        }

        static public char aaa(char text, int key)
        {
            Thread.Sleep(key);
            return 'q';
        }
    }
}
