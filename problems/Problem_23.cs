using System.Collections.Generic;
using System;
namespace Project_Euler.problems
{
    public class Problem_23
    {
        public static void SolveProblem() {
            List<int> abundants;
            findAbundants(out abundants);

            List<int> abSums = new List<int>();
            foreach(int valA in abundants) {
                foreach(int valB in abundants) {
                    if(valA + valB > 28123) {
                        break;
                    }
                    if(!abSums.Contains(valA + valB)) {
                        abSums.Add(valA + valB);
                    }
                }
            }

            int sum = 0;

            for(int i = 0; i < 28123; i++) {
                if(!abSums.Contains(i)) {
                    sum += i;
                }
            }

            Console.WriteLine(sum);
        }

        private static void findAbundants(out List<int> abundants) {
            abundants = new List<int>();
            for(int i = 0; i < 28123; i++) {
                int[] divisors = findDivisors(i);

                int sum = 0;

                foreach(int divisor in divisors) {
                    sum += divisor;
                }

                if(sum > i) {
                    abundants.Add(i);
                }
            }
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