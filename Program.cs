using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

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
        private static readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";
        public static void Main(string[] args)
        {
            string key = args[0];
            string stringToDecode = args[1];
            var map = _buildReverseKeyMap(key);
            Console.WriteLine(DecodeCipher(stringToDecode, map));
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
            return DecodeCipher(input, outback_map);
        }

        private static string DecodeCipher(string input, Dictionary<char, char> map)
        {
            input = input.ToLower();
            var output_buf = new StringBuilder();
            foreach (char c in input)
            {
                output_buf.Append(map.ContainsKey(c) ? map[c] : c);
            }
            return output_buf.ToString();
        }

        private static Dictionary<char, char> _buildReverseKeyMap(string key) {
            var map = _buildKeyMap(key);
            var reverseMap = new Dictionary<char, char>();
            foreach (var k in map.Keys)
            {
                reverseMap[map[k]] = k;
            }
            return reverseMap;
        }

        private static Dictionary<char, char> _buildKeyMap(string key) {
            Dictionary<char, char> output = new Dictionary<char, char> ();
            int alphaIndex = 0;
            foreach (char keyChar in key.ToLower()) {
                output[alphabet[alphaIndex++]] = keyChar;
            }
            int keyAlphaIndex = 0;
            while (alphaIndex < 26) {
                while (key.Contains(alphabet[keyAlphaIndex].ToString())) {
                    keyAlphaIndex++;
                }
                output[alphabet[alphaIndex++]] = alphabet[keyAlphaIndex++];
            }
            return output;
        }
    }
}
