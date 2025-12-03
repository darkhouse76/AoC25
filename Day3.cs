using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC25
{
    internal static class Day3
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

        public static void Part1(string input) {
            string[] banks = input.Split("\r\n");            


            foreach (string bank in banks) {
                int[] joltages = Array.ConvertAll<char, int>(bank.ToCharArray(), c => (int)Char.GetNumericValue(c));

                int jolt1 = 0;
                int jolt2 = 0;

                for (int i = 0; i < joltages.Length; i++) {
                    int curJolt = joltages[i];

                    if (curJolt > jolt1 && i != joltages.Length-1) {
                        jolt1 = curJolt;
                        jolt2 = 0;                        
                    } 
                    else if (curJolt > jolt2) {
                        jolt2 = curJolt;
                    } 
                }

                AocLib.Print(jolt1.ToString() + jolt2.ToString());


            }

        }

        public static void Part2(string input) {


        }

    }
}
