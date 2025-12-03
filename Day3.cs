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
            int outputJoltage = 0;

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

                outputJoltage += (jolt1 * 10) + jolt2;

                //AocLib.Print(outputJoltage.ToString());
            }

            AocLib.Print($"Output Joltages: {outputJoltage}");

        }        

        public static void Part2(string input) {
            string[] banks = input.Split("\r\n");
            ulong outputJoltage = 0;

            foreach (string bank in banks) {
                int[] joltages = Array.ConvertAll<char, int>(bank.ToCharArray(), c => (int)Char.GetNumericValue(c));

                int[] jolts = new int[12];

                for (int batt = 0; batt < joltages.Length; batt++) {
                    int curJolt = joltages[batt];
                    bool updated = false;

                    for (int i = Math.Clamp( jolts.Length - ((joltages.Length) - batt), 0, jolts.Length - 1); i < jolts.Length; i++) {
                        if (updated) {
                            jolts[i] = 0;                            
                        } 
                        else if (curJolt > jolts[i]) {
                            jolts[i] = curJolt;
                            updated = true;                            
                        }
                    }                    
                }


                string output = "";

                for (int i = 0; i < jolts.Length; i++) {
                    output += jolts[i].ToString();
                }
                outputJoltage += ulong.Parse(output);       

                //AocLib.Print(outputJoltage.ToString());
            }

            AocLib.Print($"Output Joltages: {outputJoltage}");

        }

        static void checkJolt(int[] jolts, int curJolt, int distanceFromEnd) {



        }

    }
}
