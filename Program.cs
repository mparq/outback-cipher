using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApplication
{
    public class Program
    {
        private static readonly Dictionary<char, char> outback_map = new Dictionary<char, char>
        {
            {'a', 'z'},
            {'b', 'y'},
            {'c', 'x'},
            {'d', 'w'},
            {'e', 'v'},
            {'f', 'u'},
            {'g', 't'},
            {'h', 's'},
            {'i', 'r'},
            {'j', 'q'},
            {'k', 'p'},
            {'l', 'o'},
            {'m', 'n'},
            {'n', 'm'},
            {'o', 'l'},
            {'p', 'k'},
            {'q', 'j'},
            {'r', 'i'},
            {'s', 'h'},
            {'t', 'g'},
            {'u', 'f'},
            {'v', 'e'},
            {'w', 'd'},
            {'x', 'c'},
            {'y', 'b'},
            {'z', 'a'}
        };
        public static void Main(string[] args)
        {
            string filename = args[0];
            using (StreamReader sr = File.OpenText(filename))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(DecodeOutbackCipher(s));
                }
            }
        }

        /// <summary>
        /// Decode given string encoded with outback cipher.
        /// 
        /// Outback cipher is a reflection performed on each letter. e.g. 'A' -> 'Z', 'B' -> 'Y'
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DecodeOutbackCipher(string input)
        {
            input = input.ToLower();
            var output_buf = new StringBuilder();
            foreach (char c in input)
            {
                output_buf.Append(outback_map.ContainsKey(c) ? outback_map[c] : c);
            }
            return output_buf.ToString();
        }
    }
}
