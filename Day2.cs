using System.Diagnostics;
using System.Text.RegularExpressions;


namespace AoC25
{    
    internal static class Day2
    {
        public static void Run(int part, string input) {
            switch (part) {
                case 1:
                    Part1(input);
                    break;
                case 2:
                    Part2(input);
                    break;
            }
        }

        static bool IsInvalid(ulong productID) {
            string ID = productID.ToString();

            //if odd then must be valid Part 1 (Not invalid)
            if (ID.Length % 2 != 0) { return false; }

            int halfIndexPos = ID.Length / 2;

            return ID[..halfIndexPos] == ID[halfIndexPos..];
        }

        static bool IsInvalid2(ulong productID) {
            string ID = productID.ToString();
            int halfIndexPos = ID.Length / 2;
            string pattern = @"^(\d+)\1+$"; //new, after original solve

            //for (int i = 1; i <= halfIndexPos; i++) { //old way
            //print($"{ID} Trying {ID[..i]}"); //remove before full testing

            //string pattern = @"^(?:" + ID[..i] + @"){2,}$"; //old pattern that originally solved in ~48seconds


            if (Regex.IsMatch(ID, pattern)) {
                return true;
            }
            //} //old way

            return false;
        }


        public static void Part1(string input) {

            ulong answer = 0;

            foreach (Match range in Regex.Matches(input, @"(?<low>\d*)-(?<high>\d*)")) {

                ulong startNum = ulong.Parse(range.Groups["low"].Value);
                ulong endNum = ulong.Parse(range.Groups["high"].Value);

                for (ulong i = startNum; i <= endNum; i++) {
                    if (IsInvalid(i)) {
                        answer += i;
                    }
                }
            }

            AocLib.Print($"Part 1 answer: {answer}");

        }
        
        public static void Part2(string input) {
            //print(IsInvalid2(44644677));            

            ulong answer = 0;

            foreach (Match range in Regex.Matches(input, @"(?<low>\d*)-(?<high>\d*)")) {

                ulong startNum = ulong.Parse(range.Groups["low"].Value);
                ulong endNum = ulong.Parse(range.Groups["high"].Value);

                for (ulong i = startNum; i <= endNum; i++) {
                    if (IsInvalid2(i)) {
                        answer += i;
                    }
                }
            }

            
            AocLib.Print($"Part 2 answer: {answer}");
            

        }

    }
}
