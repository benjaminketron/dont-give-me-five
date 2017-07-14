using System;

namespace Fives
{
    public class Fives : IFives
    {
        public Fives()
        {

        }

        /// <summary>
        /// Returns the count of numbers that do contain the digit five in the inclusive range of 0 to number where number is positive and always 10^n where 
        /// n is >= 0.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="magnitude"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int InstanceOfFiveBase(int number, int magnitude = 1, int count = 1)
        {
            if (number < 5)
            {
                return 0;
            }
            else if (number < 100)
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
                    if (magnitude == 2)
                    {
                        count = 19;
                    }
                    else
                    {
                        count = (int)Math.Pow(count, 1) * 10 + (int)Math.Pow(10, magnitude - 1) - (int)Math.Pow(count, 1);
                    }

                    count = InstanceOfFiveBase(number, magnitude + 1, count);
                }
            }

            return count;
        }

        /// <summary>
        /// Returns the count of numbers that do contain the digit five in the inclusive range of 0 to number where number is positive.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="magnitude"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int CountInstancesOfFiveFromZeroToNumber(int number, int magnitude = 0, int count = 1)
        {
            if (number < 5)
            {
                return 0;
            }
            else if (number <= 10)
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
                    if (magnitude == 0)
                    {
                        if (coefficient < 5)
                        {
                            count = 0;
                        }
                        else
                        {
                            count = 1;
                        }
                        count = CountInstancesOfFiveFromZeroToNumber(number, magnitude + 1, count);
                    }
                    else
                    {
                        if (coefficient >= 5)
                        {
                            var remainder = number % (int)Math.Pow(10, magnitude);

                            if (coefficient > 5)
                            {
                                count += (int)Math.Pow(10, magnitude) - InstanceOfFiveBase((int)Math.Pow(10, magnitude));
                            }
                            else
                            {
                                count += remainder - count + 1;
                            }
                        }

                        if (coefficient > 0)
                        {
                            count = coefficient * InstanceOfFiveBase((int)Math.Pow(10, magnitude)) + count;
                        }

                        count = CountInstancesOfFiveFromZeroToNumber(number, magnitude + 1, count);
                    }

                    return count;
                }
            }
        }

        /// <summary>
        /// Returns the count of numbers that do contain the digit five in the inclusive range of start to end.
        /// The start parameter must be less than or equal to the end parameter; otherwise, and exception is thrown.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int CountOfFivesInRange(int start, int end)
        {
            var result = 0;

            if (end < start)
            {
                throw new Exception("The start parameter must be less than or equal to the end parameter.");
            }

            if (start <= 0 && end <= 0)
            {
                var temp = end;
                end = (int)Math.Abs(start);
                start = (int)Math.Abs(temp);
            }

            if (start < 0 && end > 0) {
                //var startNegative = 0;
                var endNegative = (int)Math.Abs(start);
                //var startPositive = 0;
                var endPositive = end;

                result = CountInstancesOfFiveFromZeroToNumber(endNegative) + CountInstancesOfFiveFromZeroToNumber(endPositive);
            }
            else
            {
                var excludedCount = start > 0 ? CountInstancesOfFiveFromZeroToNumber(start - 1) : 0;
                var includedCount = CountInstancesOfFiveFromZeroToNumber(end);
                result = includedCount - excludedCount;
            }

            return result;
        }

        /// <summary>
        /// Returns the count of numbers that do not contain the digit five in the inclusive range of start to end.
        /// The start parameter must be less than or equal to the end parameter; otherwise, and exception is thrown.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int CountOfNotFivesInRange(int start, int end)
        {
            var fivesCount = CountOfFivesInRange(start, end);
            var completeCount = (int)Math.Abs(end - start) + 1;
            return completeCount - fivesCount;
        }
    }
}
