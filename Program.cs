using System.Diagnostics;
using System.Reflection;

namespace AoC25
{
    internal class Program
    {
        static string GetInput(string day, bool getReal = false) {

            string dir =Path.GetFullPath(@"..\..\..\inputs\");

            string filePath = $"{dir}{day}{(getReal ? "real" : "test")}";
            filePath = File.Exists(filePath + "2.txt") ? $"{filePath}2.txt" : $"{filePath}.txt";

            if (!File.Exists(filePath)) {
                throw new FileNotFoundException();                
            }

            string input = File.ReadAllText(filePath);
            if (input.Length < 3) {
                throw new Exception("File Found with NO Data");
            }
            return File.ReadAllText(filePath); 
        }

        static void Main(string[] args) {
            //config for each day
            string day = "03";
            int part = 2;
            bool useRealData = true;
            //

            //Console.WriteLine(Path.GetFullPath(@"..\..\..\inputs\"));
            //Console.WriteLine(Path.GetFullPath(Assembly.GetExecutingAssembly().GetName().Name));
            //Console.WriteLine(Assembly.GetExecutingAssembly().Location);

            string seperator = "======================================\n";
            Console.Title = $"Day {day} Part {part} using {(useRealData ? "Real" : "Test")}";
            string header = $"{seperator} {Console.Title} Data\n{seperator}";


            AocLib.Print(header);

            var startTime = System.DateTime.Now;
            //Change each day
            Day3.Run(part, GetInput(day, useRealData));
            //

            AocLib.Print($"\n{seperator}Took {System.DateTime.Now - startTime} to complete.\n{seperator}");

            //Console.WriteLine($"{seperator}");
            
            Console.ReadKey();
        }
    }
}
