/*



    [USEFUL RESOURCES]
    Caesar cypher translator: https://dcode.fr/caesar-cipher

    Long sentence example: https://10fastfingers.com/text/101161-long-sentence



*/

using System;

namespace ShiftCypher {
    class Program {
        public static string englishAlphabet = "abcdefghijklmnopqrstuvwxyz";
        static void Main() {
            // Problem #5
            Console.WriteLine(CaesarCypher("dCode Caesar", 10));
            Console.WriteLine(CaesarCypher("dCode Caesar", 10));
            Console.WriteLine(CaesarCypher("dCode Caesar", -10));
            Console.WriteLine(CaesarCypher("dCode Caesar", -10));

            // Problem #6
            Console.WriteLine("\n\n\nEnter a word/phrase/sentence containing only English letters (no exceptions) and press ENTER key when done: ");

            string promptString = Console.ReadLine();
            int rndIndex = new Random().Next(0, 10);

            Console.WriteLine($"\n\nGenerated random shift index: {rndIndex}\n\n\nEncoded Caesar cypher:\n{CaesarCypher(promptString, rndIndex)}\n\n");
        }
        static string CaesarCypher(string str, int shift) {
            string allWords = "";
            bool capitalized;

            foreach (char s in str) {
                if (char.IsLetter(s)) {
                    capitalized = char.IsUpper(s);

                    int remainder = englishAlphabet.IndexOf(s.ToString().ToLower()) + shift;

                    if (capitalized) {
                        if ((remainder < englishAlphabet.Length) && (remainder >= 0)) allWords += char.Parse(englishAlphabet[remainder].ToString().ToUpper());
                        else if (remainder >= englishAlphabet.Length) allWords += char.Parse(englishAlphabet[remainder - englishAlphabet.Length].ToString().ToUpper());
                        else if (remainder <= 0) allWords += char.Parse(englishAlphabet[englishAlphabet.Length + remainder].ToString().ToUpper());
                    } else {
                        if (remainder < englishAlphabet.Length && remainder >= 0) allWords += englishAlphabet[remainder];
                        else if (remainder >= englishAlphabet.Length) allWords += englishAlphabet[remainder - englishAlphabet.Length];
                        else if (remainder <= 0)  allWords += englishAlphabet[englishAlphabet.Length + remainder];
                    }
                } else allWords += s;
            }

            return allWords;
        }
    }
}