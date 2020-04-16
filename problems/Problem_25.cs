using System.Numerics;
using System;
namespace Project_Euler.problems
{
    public class Problem_25
    {
        private static BigInteger golden_ratio_hundred = BigInteger.Parse("792070839853519714273");

        public static void SolveProblem() {
            BigInteger fib = 1;
            int counter = 0;

            while(fib.ToString().Length < 1000) {
                fib = fib * golden_ratio_hundred;
                counter += 100;
            }

            for(int i = counter - 100; i < counter; i++) {
                //somehow do a golden ratio calculation in here without BigFloat...
                //TODO: implement BigFloat
            }

            Console.WriteLine(counter);
        }
    }
}