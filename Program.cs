using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "Hello world!";
            string output = DecodeOutbackCipher(input);
            Console.WriteLine(output);
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
            return input;
        }
    }
}
