using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        var start = 0;
        var end = input.Length - 1;

        while (start <= end)
        {
            var middle = start + (end - start) / 2;
            var target = input[middle];
            
            if (target == value) return middle;

            if (value > target)
            {
                start = middle + 1;
            }
            else
            {
                end = middle - 1;
            }
        }

        return -1;
    }
}
