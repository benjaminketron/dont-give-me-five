using System;

namespace Fives
{
    public class Fives
    {
        public Fives()
        {

        }

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

        public int CountInstancesOfFiveFromZeroToNumber(int number, int magnitude = 0, int count = 1)
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
                    //var coefficient = number % (int)Math.Pow(10, finalMagnitude + 1) / (int)Math.Pow(10, finalMagnitude);

                    //if (coefficient >= 5)
                    //{
                    //    count += (int)Math.Pow(10, finalMagnitude) - 2 * CountInstancesOfFiveFromZeroToNumber((int)Math.Pow(10, finalMagnitude));
                    //}

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
    }
}
