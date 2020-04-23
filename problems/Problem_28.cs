using System;
namespace Project_Euler.problems
{
    public class Problem_28
    {
        public static void SolveProblem() {
            int diaLength = 1;
            int diaMod = 0;
            int currentInd = 1;
            int sum = 1;

            while(diaLength < 1001) {
                diaMod += 2;
                diaLength = diaMod + 1;
                for(int i = 0; i < 4; i++) {
                    currentInd += diaMod;
                    sum += currentInd;
                }

                Console.WriteLine("Spiral Diameter: " + diaLength);
                Console.WriteLine("Sum: " + sum);
            }
        }
    }
}