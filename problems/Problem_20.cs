using System.Numerics;
using System;
namespace Project_Euler.problems
{
    public class Problem_20
    {
        public static void solveProblem() {
            BigInteger sum = 1;

            for(int i = 1; i <= 100; i++) {
                sum *= i;
            }

            Console.WriteLine(sum.ToString());
            int answer = 0;

            foreach(char c in sum.ToString()) {
               answer += Int32.Parse(c.ToString());
            }

            Console.WriteLine(answer);

        }
    }
}