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
        //[InlineData(10, 1)]
        //[InlineData(20, 2)]
        //[InlineData(30, 3)]
        //[InlineData(40, 4)]
        //[InlineData(50, 6)]
        //[InlineData(60, 15)]
        //[InlineData(70, 16)]
        //[InlineData(80, 17)]
        //[InlineData(90, 18)]
        //[InlineData(100, 19)]
        //[InlineData(110, 20)]
        //[InlineData(120, 21)]
        //[InlineData(130, 22)]
        //[InlineData(140, 23)]
        //[InlineData(150, 25)]
        //[InlineData(160, 34)]
        //[InlineData(170, 35)]
        //[InlineData(180, 36)]
        //[InlineData(190, 37)]
        //[InlineData(200, 38)]
        //[InlineData(500, 96)]
        //[InlineData(2000, 542)]
        //[InlineData(2100, 561)]
        //[InlineData(2110, 562)]
        //[InlineData(5605, 1961)]
        //[InlineData(5608, 1964)]
        //[InlineData(5678, 2034)]
        public void CountInstancesOfFiveFromZeroToNumber(int number, int expected)
        {
            var fives = new Fives.Fives();

            var actual = fives.CountInstancesOfFiveFromZeroToNumber(number);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, 555, 151)]
        public void StartToEndFiveCountTest(int start, int end, int expected)
        {
            var fives = new Fives.Fives();

            var excludeCount = fives.CountInstancesOfFiveFromZeroToNumber(start - 1);
            var includeCount = fives.CountInstancesOfFiveFromZeroToNumber(end);

            Assert.Equal(expected, includeCount - excludeCount);
        }

        public static List<object> CountInstancesOfFiveFromZeroToNumberData()
        {
            var result = new List<object>();

            for (int i = 1; i <= 100000; i++)
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
