using System;
using System.Collections.Generic;
using System.Text;

namespace Fives
{
    interface IFives
    {
        int InstanceOfFiveBase(int number, int magnitude = 1, int count = 1);
        int CountInstancesOfFiveFromZeroToNumber(int number, int magnitude = 0, int count = 1);
        int CountOfFivesInRange(int start, int end);
        int CountOfNotFivesInRange(int start, int end);
    }
}
