using System;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value) =>
        $"{ToRomanThousands(value)}{ToRomanHundreds(value)}{ToRomanTens(value)}{ToRomanUnits(value)}";

    private static string ToRomanThousands(int value) =>
        ToRoman(value / 1000 % 10, "M", "", "");

    private static string ToRomanHundreds(int value) =>
        ToRoman(value / 100 % 10, "C", "D", "M");

    private static string ToRomanTens(int value) =>
        ToRoman(value / 10 % 10, "X", "L", "C");

    private static string ToRomanUnits(int value) =>
        ToRoman(value % 10, "I", "V", "X");
    
    private static string ToRoman(int digit, string one, string five, string ten)
    {
        if (digit < 0 || digit > 9)
            throw new ArgumentOutOfRangeException();

        return digit switch
        {
            0 => "",
            1 => one,
            2 => $"{one}{one}",
            3 => $"{one}{one}{one}",
            4 => $"{one}{five}",
            5 => $"{five}",
            6 => $"{five}{one}",
            7 => $"{five}{one}{one}",
            8 => $"{five}{one}{one}{one}",
            9 => $"{one}{ten}"
        };
    }
}
