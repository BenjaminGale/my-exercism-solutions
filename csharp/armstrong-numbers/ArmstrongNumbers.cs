using System;
using System.Linq;
using System.Collections.Generic;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var digits = new List<int>();
        var current = number;

        while (current > 0)
        {   
            digits.Add(current % 10);
            current = current / 10;
        }

        var sum = digits.Select(n => Math.Pow(n, digits.Count)).Sum();
        
        return sum == number;
    }
}
