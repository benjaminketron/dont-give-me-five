using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace FivesTests
{
    public class FiveTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(10, 1)]
        [InlineData(100, 19)]
        [InlineData(1000, 271)]
        [InlineData(10000, 3439)]
        [InlineData(100000, 40951)]
        [InlineData(1000000, 468559)]
        [InlineData(10000000, 5217031)]
        [InlineData(100000000, 56953279)]
        public void InstanceOfFiveBaseTests(int number, int expected)
        {
            var fives = new Fives.Fives();

            var actual = fives.InstanceOfFiveBase(number);

            Assert.Equal(expected, actual);
        }

        [Theory, MemberData(nameof(CountInstancesOfFiveFromZeroToNumberData))]
        public void CountInstancesOfFiveFromZeroToNumber(int number, int expected)
        {
            var fives = new Fives.Fives();

            var actual = fives.CountInstancesOfFiveFromZeroToNumber(number);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, 555, 151)]
        [InlineData(-4, 555, 151)]
        [InlineData(-555, -4, 151)]
        [InlineData(-100, 100, 38)]
        public void CountOfFivesInRangeTest(int start, int end, int expected)
        {
            var fives = new Fives.Fives();

            var result = fives.CountOfFivesInRange(start, end);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(4, 555, 401)]
        [InlineData(-4, 555, 409)]
        [InlineData(-555, -4, 401)]
        [InlineData(-100, 100, 136)]        
        public void CountOfNotFivesInRangeTest(int start, int end, int expected)
        {
            var fives = new Fives.Fives();

            var result = fives.CountOfNotFivesInRange(start, end);

            Assert.Equal(expected, result);
        }

        public static List<object> CountInstancesOfFiveFromZeroToNumberData()
        {
            var result = new List<object>();

            for (int i = 1; i <= 10000; i++)
            {
                var number = i;
                var expected = CountFivesIteratively(i);
                result.Add(new object[] { number, expected });
            }

            return result;
        }

        public static int CountFivesIteratively(int number)
        {
            var result = 0;

            for (int i = 1; i <= number; i++)
            {
                if (i.ToString().Contains("5"))
                {
                    result++;
                }
            }

            return result;
        }        
    }
}
