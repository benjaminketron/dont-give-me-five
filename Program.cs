using System;

namespace CountWithoutFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountWithoutFive(1));
            Console.WriteLine(CountWithoutFive(10));
            Console.WriteLine(CountWithoutFive(100));
            Console.WriteLine(CountWithoutFive(1000));
            Console.WriteLine(CountWithoutFive(10000));
            Console.WriteLine(CountWithoutFive(100000));
            Console.WriteLine(CountWithoutFive(1000000));
            Console.WriteLine(CountWithoutFive(10000000));
            Console.WriteLine(CountWithoutFive(100000000));

            var excludeCount = CountWithoutFive(5);
            var includeCount = CountWithoutFive(555);
            Console.WriteLine(includeCount - excludeCount);
        }

        public static int CountWithoutFive(int number, int magnitude = 2, int count = 2)
        {
            if (number < 5)
            {
                return 0;
            }
            if (number <= 10)
            {
                return 1;
            }
            else
            {
                var finalMagnitude = (int)Math.Log10(number);
                if (magnitude > finalMagnitude)
                {
                    return count;
                }
                else
                {
                    var coefficient = number % (int)Math.Pow(10, magnitude + 1) / (int)Math.Pow(10, magnitude);
                    if (coefficient == 0)
                    {
                        coefficient = 1;
                    }

                    if (magnitude == 2)
                    {
                        count = 19;
                    } 
                    else
                    {
                        count = (int)Math.Pow(count, 1) * 10 + (int)Math.Pow(10, magnitude - 1) - (int)Math.Pow(count, 1);
                    }

                    count = (int)coefficient * CountWithoutFive(number, magnitude + 1, count);

                    if (coefficient >= 5)
                    {
                        count++;
                    }

                    return count;
                }
            }
        }
    }
}