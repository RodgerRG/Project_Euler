using System;
namespace Project_Euler.problems
{
    public class Problem_26
    {
        public static void SolveProblem() {
            int currentLongest = 0;
            int currentNum = 1;
            for(int i = 2; i < 1000; i++) {
                if(!IsPrime(i)) {
                    continue;
                }

                int iLength = FindCycle(i);

                if(iLength > currentLongest) {
                    currentLongest = iLength;
                    currentNum = i;
                }
            }

            Console.WriteLine(currentNum);

        }

        private static int FindCycle(int num) {
            Console.WriteLine("Finding the cycle of: " + num);
            string res = "";
            bool foundCycle = false;
            
            int val = 1 * (int)(Math.Pow(10, num.ToString().Length));
            
            if(num > 10) {
                res = res + "0";
            } 
            if(num > 100) {
                res = res + "0";
            }

            while(!foundCycle) {
                if(val % num != 0) {
                    res = res + val / num;
                    val = (val % num) * 10;
                } else {
                    //break this loop because the number is perfectly divisible!
                    foundCycle = true;
                }

                if(res.Length % 2 == 0 && res.Length != 0) {
                    string check = res.Substring(0, res.Length / 2);
                    string other = res.Substring(res.Length / 2, res.Length / 2);

                    if(check.Equals(other)) {
                        return check.Length;
                    }
                }
            }

            return -1;
        }

        private static bool IsPrime(int num) {
            for(int i = 2; i < num / 2; i++) {
                if(num % i == 0) {
                    return false;
                }
            }

            return true;
        }
    }
}