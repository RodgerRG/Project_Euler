using System;
namespace Project_Euler.problems
{
    public class Problem_19
    {
        public static int weekday_offset = 0;
        public static bool isLeapYear = false;

        public static void solveProblem() {
            int count = 0;

            for(int i = 1901; i < 2000; i++) {
                if((i % 4 == 0 && i % 100 != 0) || (i % 100 == 0 && i % 400 == 0)) {
                    isLeapYear = true;
                } else {
                    isLeapYear = false;
                }

                for(int month = 0; month < 12; month++) {
                    if(weekday_offset % 7 == 6) {
                        count++;
                    }

                    if(month == 8 || month == 3 || month == 5 || month == 10) {
                        weekday_offset += 30 % 7;
                    } else if(month == 1) {
                        if(isLeapYear) {
                            weekday_offset += 29 % 7;
                        } else {
                            weekday_offset += 28 % 7;
                        }
                    } else {
                        weekday_offset += 31 % 7;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}