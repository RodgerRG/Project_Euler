using System.Numerics;
using System;
namespace Project_Euler.problems
{
    public class Problem_27
    {
        public static void SolveProblem() {
            int maxCount = 40;
            int val = 0;

            for(int i = 0; i < 40; i++) {
                int a, b;
                computeEquation(i, out a, out b);

                Console.WriteLine("Integer: " + i);
                Console.WriteLine("A: " + a);
                Console.WriteLine("B: " + b);

                int count = 0;
                int temp = (int) Math.Pow(count, 2) + (a * count) + b;

                while(isPrime(temp)) {
                    count++;
                    temp = (int) Math.Pow(count, 2) + (a * count) + b;
                }

                Console.WriteLine("Prime Count: " + count);

                if(count > maxCount) {
                    maxCount = count;
                    val = i;
                }
            }

            Console.WriteLine(maxCount);
            Console.WriteLine(val);
        }

        private static void computeEquation(int input, out int a, out int b) {
            a = -2 * input + 1;
            b = (int) Math.Pow(input, 2) - input + 41;
        }

        private static bool isPrime(int num) {
            for(int i = 2; i < num / 2; i++) {
                if(num % i == 0) {
                    return false;
                }
            }

            return true;
        }
    }
}