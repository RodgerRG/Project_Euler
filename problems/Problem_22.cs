using System.IO;
using System;
namespace Project_Euler.problems
{
    public class Problem_22
    {
        public static void SolveProblem() {
            StreamReader reader = new StreamReader(new FileStream(Directory.GetCurrentDirectory() + "/inputs/Problem_22", FileMode.Open));
            string inputs = reader.ReadLine();
            string[] names = inputs.Split(",");

            Array.Sort(names);

            int sum = 0;
            int counter = 1;

            foreach(string name in names) {
                string val = name.Replace("\"", "");
                Console.WriteLine(val);

                int nameScore = 0;
                
                foreach(char c in val.ToCharArray()) {
                    nameScore += c - 'A' + 1;
                }

                sum += nameScore * counter;
                counter++;
            }

            Console.WriteLine(sum);
        }
    }
}