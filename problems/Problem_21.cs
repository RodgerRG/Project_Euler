using System.Collections.Generic;
using System;
namespace Project_Euler.problems
{
    public class Problem_21
    {
        private static Dictionary<int, int> pairs = new Dictionary<int, int>();
        public static void solveProblem() {
            for(int i = 1; i < 10000; i++) {
                int[] divisors = findDivisors(i);

                int sum = 0;
                foreach(int divisor in divisors) {
                    sum += divisor;
                }

                if(sum < 10000) {
                    divisors = findDivisors(sum);
                    int newSum = 0;
                    foreach(int divisor in divisors) {
                        newSum += divisor;
                    }

                    if(newSum == i && i != sum) {
                        pairs.Add(i, sum);
                    }
                }
            }

            int output = 0;

            foreach(int key in pairs.Keys) {
                output += key;
                int temp;
                pairs.TryGetValue(key, out temp);

                Console.WriteLine("Amicable Pair: " + key + ", " + temp);

                output += temp;
            }

            Console.WriteLine(output / 2);
        }

        private static int[] findDivisors(int num) {
            List<int> divisors = new List<int>();
            for(int i = 1; i <= num / 2; i++) {
                if(num % i == 0) {
                    divisors.Add(i);
                }
            }

            return divisors.ToArray();
        }
    }
}