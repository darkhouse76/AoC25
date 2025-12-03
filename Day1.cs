using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC25
{
    internal static class Day1
    {

        static int GetRotation(string instruction) {

            if (instruction[..1] == "R") { return 1; }
            return -1;
        }

        static int RotateDial(int dialStartPoint, int ticks, int directionMod = 1) {
            int dialPoint = dialStartPoint;

            dialPoint = (dialPoint + (ticks * directionMod)) % 100;

            return (dialPoint < 0) ? 100 + dialPoint : dialPoint;
        }

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
            string[] instructions = input.Split("\r\n");
            int dialPoint = 50;
            int password = 0;

            for (int i = 0; i < instructions.Length; i++) {
                dialPoint = RotateDial(dialPoint, int.Parse(instructions[i][1..]), GetRotation(instructions[i]));

                if (dialPoint == 0) {
                    password++;
                }
            }

            AocLib.Print($"The password for Part 1: {password}");

        }

        public static void Part2(string input) {
            string[] instructions = input.Split("\r\n");
            int dialPoint = 50;
            int password = 0;

            for (int i = 0; i < instructions.Length; i++) {
                int rotation = GetRotation(instructions[i]);
                int numTicks = int.Parse(instructions[i][1..]);

                for (int tickProgress = 0; tickProgress < numTicks; tickProgress++) {
                    dialPoint = RotateDial(dialPoint, 1, rotation);
                    if (dialPoint == 0) {
                        password++;
                    }
                }
            }

            AocLib.Print($"The password for Part 2: {password}");

        }

    }
}
