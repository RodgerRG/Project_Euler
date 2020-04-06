using System;
namespace Project_Euler.problems
{
    public class Problem_17
    {
        public static void SolveProblem() {
            int letterCount = 0;
            for(int i = 1; i <= 1000; i++) {
                letterCount += NumLetters(i);
                Console.WriteLine(NumLetters(i));
            }

            Console.WriteLine(letterCount);

        }

        private static int NumLetters(int number) {
            int ones = number % 10;
            int tens = number % 100 - ones;
            int hundreds = number % 1000 - tens - ones;
            int thousands = number / 1000;

            int letterCount = 0;

            if(thousands > 0) {
                return 11;
            }

            if(hundreds > 0) {
                letterCount += 7;
                
                switch(hundreds / 100) {
                    case 1:
                        letterCount += 3;
                    break;
                    case 2:
                        letterCount += 3;
                    break;
                    case 3:
                        letterCount += 5;
                    break;
                    case 4:
                        letterCount += 4;
                    break;
                    case 5:
                        letterCount += 4;
                    break;
                    case 6:
                        letterCount += 3;
                    break;
                    case 7:
                        letterCount += 5;
                    break;
                    case 8:
                        letterCount += 5;
                    break;
                    case 9:
                        letterCount += 4;
                    break;
                }
            }

            if(tens > 0 && hundreds > 0 || ones > 0 && hundreds > 0) {
                letterCount += 3;
            }

            if(tens > 0) {
                switch(tens / 10) {
                    case 1:
                        switch(ones) {
                            case 0:
                                letterCount += 3;
                                break;
                            case 1:
                                letterCount += 6;
                            break;
                            case 2:
                                letterCount += 6;
                            break;
                            case 3:
                                letterCount += 8;
                            break;
                            case 4:
                                letterCount += 8;
                            break;
                            case 5:
                                letterCount += 7;
                            break;
                            case 6:
                                letterCount += 7;
                            break;
                            case 7:
                                letterCount += 9;
                            break;
                            case 8:
                                letterCount += 8;
                            break;
                            case 9:
                                letterCount += 8;
                            break;
                        }

                    return letterCount;
                    case 2:
                        letterCount += 6;
                    break;
                    case 3:
                        letterCount += 6;
                    break;
                    case 4:
                        letterCount += 5;
                    break;
                    case 5:
                        letterCount += 5;
                    break;
                    case 6:
                        letterCount += 5;
                    break;
                    case 7:
                        letterCount += 7;
                    break;
                    case 8:
                        letterCount += 6;
                    break;
                    case 9:
                        letterCount += 6;
                    break;
                }
            }

            if(ones > 0) {
                switch(ones) {
                    case 1:
                        letterCount += 3;
                    break;
                    case 2:
                        letterCount += 3;
                    break;
                    case 3:
                        letterCount += 5;
                    break;
                    case 4:
                        letterCount += 4;
                    break;
                    case 5:
                        letterCount += 4;
                    break;
                    case 6:
                        letterCount += 3;
                    break;
                    case 7:
                        letterCount += 5;
                    break;
                    case 8:
                        letterCount += 5;
                    break;
                    case 9:
                        letterCount += 4;
                    break;
                }
            }

            return letterCount;
        }
    }
}