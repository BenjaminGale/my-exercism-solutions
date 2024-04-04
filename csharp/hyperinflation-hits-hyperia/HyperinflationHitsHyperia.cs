using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            checked
            {
                return (@base * multiplier).ToString();
            }
        }
        catch (OverflowException e)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        var amount = (@base * multiplier);

        return amount == float.PositiveInfinity
            ? "*** Too Big ***"
            : amount.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            checked
            {
                return (salaryBase * multiplier).ToString();
            }
        }
        catch (OverflowException e)
        {
            return "*** Much Too Big ***";
        }
    }
}
