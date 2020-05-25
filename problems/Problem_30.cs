using System;
namespace Project_Euler.problems
{
    public class Problem_30
    {
        private static int upper = 330000;
        public static void SolveProblem() {
            int count = 0;
            for(int i = 2; i < upper; i++) {
                if(isSum(i)) {
                    count += i;
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine(count);
        }

        private static bool isSum(int num) {
            string raw = num.ToString();
            int sum = 0;

            foreach(char integer in raw) {
                int i = int.Parse("" + integer);
                sum += (int) Math.Pow(i, 5);
            }

            return sum.ToString().Equals(raw);
        }
    }
}