using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
namespace Project_Euler.problems
{
    public class Problem_29
    {
        private static List<BigInteger> primes = new List<BigInteger>();
        private static Dictionary<BigInteger, BigInteger[]> knowns = new Dictionary<BigInteger, BigInteger[]>();

        public static void SolveProblem() {
            primes.Add(2);
            primes.Add(3);
            
            for(int i = 2; i <= 100; i++) {
                for(int j = 2; j <= 100; j++) {
                    BigInteger num = BigInteger.Pow(i, j);
                    BigInteger[] factors = findFactors(num);
                    Console.WriteLine(String.Join(", ", primes));

                    if(!knowns.ContainsKey(num)) {
                        knowns.Add(num, factors);
                    }
                }
            }

            Console.WriteLine(knowns.Keys.Count);
        }

        private static BigInteger[] findFactors(BigInteger num) {
            List<BigInteger> factors = new List<BigInteger>();

            int ind = 0;

            while(num != 1) {
                if(num % primes[ind] == 0) {
                    num /= primes[ind];
                    factors.Add(primes[ind]);
                } else {
                    ind++;
                }

                if(ind >= primes.Count) {
                    if(isPrime(num)) { 
                        primes.Add(num);
                        factors.Add(num);
                    } else {
                        int newPrimeSqr = (int) num;
                        primes.Add((int) Math.Sqrt(newPrimeSqr));
                    }

                    num /= num;
                }
            }

            return factors.ToArray();
        }

        private static bool isPrime(BigInteger number) {
            for(int i = 2; i < number / 2; i++) {
                if(number % i == 0) {
                    return false;
                }
            }

            return true;
        }
    }
}