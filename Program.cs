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
            if (args.Length < 4)
            {
                Console.WriteLine('\n');
                return;
            }
            string stringToDecode = args[0];
            int start = int.Parse(args[1]);
            int step = int.Parse(args[2]);
            int limit = int.Parse(args[3]);
            Console.WriteLine(EncodeRollingCaesarCipher(stringToDecode, start, step, limit));
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

        public static string EncodeRollingCaesarCipher(string input, int start, int step, int limit)
        {
            var output_buf = new StringBuilder();
            char newChar;
            int asciiCode;
            int newCode;
            int moveAmount = start;
            bool isUpper;
            bool isLower;
            foreach (char c in input)
            {
                asciiCode = (int)c;
                isUpper = asciiCode >= 65 && asciiCode <= 90;
                isLower = asciiCode >= 97 && asciiCode <= 122;

                if (isUpper || isLower)
                {
                    if (isUpper)
                    {
                        newCode = 65 + (((asciiCode - 65) + moveAmount) % 26);
                    }
                    else
                    {
                        newCode = 97 + (((asciiCode - 97) + moveAmount) % 26);
                    }
                    moveAmount = (moveAmount + step);
                    if (moveAmount > limit)
                    {
                        moveAmount = moveAmount - limit;
                    }
                }
                else
                {
                    newCode = asciiCode;
                }
                newChar = (char)newCode;
                output_buf.Append(newChar);
            }
            return output_buf.ToString();
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
