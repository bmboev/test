using System;
using System.IO;
using System.Linq;

namespace Traveler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string fileName = args.FirstOrDefault();
            if (string.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("Usage: Traveler.exe input.txt");
            }
            else
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} doesn't exist");
            }
            else
            {
                var result = TravelParser.Run(File.ReadAllText(args[0]));
                foreach (var item in result)
                {
                    Console.WriteLine($"X={item.X} Y={item.Y} Direction={item.Direction}");
                }
            }
        }
    }
}
