/*



    [USEFUL RESOURCE]
    Pig Latin translator: https://lingojam.com/PigLatinTranslator



*/

using System;
using System.Linq;

namespace PigLatin {
    class Program {
        static void Main() {
            Console.WriteLine("Enter a word/phrase/sentence and press ENTER key when done: ");

            string promptString = Console.ReadLine();
            string[] words = promptString.Split();

            // Problem #1
            string pig1 = PigLatin1(words[0]);
            Console.WriteLine($"\n\n\nProblem #1 : {pig1}\n\n\n");

            // Problem #2
            string pig2 = PigLatin2(words[0]);
            Console.WriteLine($"Problem #2 : {pig2}\n\n\n");

            // Problem #3
            string pig3 = PigLatin3(words[0]);
            Console.WriteLine($"Problem #3 : {pig3}\n\n\n");

            // Problem #4
            string pig4 = PigLatin4(words);
            Console.WriteLine($"Problem #4 : {pig4}\n\n");
        }

        static bool IsVowel(char c) {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            if (vowels.Contains(c)) return true;

            return false;
        }

        static bool IsPunctuation(string c) {
            if (char.IsPunctuation(char.Parse(c))) return true;

            return false;
        }

        static int IndexOfFirstVowel(string s) {
            int index = -1;

            for (int i = 0; i < s.Length && index == -1; i++) {
                char c = s[i];
                if (IsVowel(c)) index = i;
            }

            return index;
        }

        static string PigLatin1(string s) {
            int index = IndexOfFirstVowel(s);
            string firstPart = s.Substring(index);
            string secondPart = s.Substring(0, index).ToLower();
            string thirdPart = "ay";

            return $"{firstPart}{secondPart}{thirdPart}";
        }

        static string PigLatin2(string s) {
            int index = IndexOfFirstVowel(s);
            string firstPart = s.Substring(index);

            if (char.IsUpper(s, 0)) firstPart = $"{s.Substring(index).Substring(0, 1).ToUpper()}{s.Substring(index + 1)}";

            string secondPart = s.Substring(0, index).ToLower();
            string thirdPart = "ay";

            return $"{firstPart}{secondPart}{thirdPart}";
        }

        static string PigLatin3(string s) {
            int index = IndexOfFirstVowel(s);
            string firstPart = s.Substring(index);
            string secondPart = s.Substring(0, index).ToLower();
            string thirdPart = "ay";
            string fourthPart = s[^1].ToString();

            if (IsPunctuation(s[^1].ToString())) firstPart = firstPart.Remove(firstPart.Length - 1, 1);
            if (IsPunctuation(fourthPart)) return $"{firstPart}{secondPart}{thirdPart}{fourthPart}";

            return $"{firstPart}{secondPart}{thirdPart}";
        }

        static string PigLatin4(string[] str) {
            string allWords = "";

            foreach (string s in str) {
                int index = IndexOfFirstVowel(s);
                string firstPart = s.Substring(index);

                if (char.IsUpper(s, 0)) firstPart = $"{s.Substring(index).Substring(0, 1).ToUpper()}{s.Substring(index + 1)}";

                string secondPart = s.Substring(0, index).ToLower();
                string thirdPart = "ay";
                string fourthPart = s[^1].ToString();

                if (IsPunctuation(s[^1].ToString())) firstPart = firstPart.Remove(firstPart.Length - 1, 1);

                if (IsPunctuation(fourthPart)) allWords += $"{firstPart}{secondPart}{thirdPart}{fourthPart}";
                else allWords += $"{firstPart}{secondPart}{thirdPart}";

                if (s != str[^1]) allWords += " ";
            }

            return allWords;
        }
    }
}