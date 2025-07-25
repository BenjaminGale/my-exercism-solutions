using System;
using System.Linq;
using System.Collections.Generic;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var cleaned = new string(phoneNumber.ValidChars().ToArray());
        
        if (!cleaned.IsValid())
            throw new ArgumentException();

        if (cleaned.Length == 11)
            cleaned = cleaned.Substring(1);
        
        return cleaned;
    }
}

public static class Extensions
{
    public static IEnumerable<char> ValidChars(this string phoneNumber)
    {
        foreach (var c in phoneNumber)
            if (Char.IsDigit(c))
                yield return c;
    }

    public static bool IsValid(this string phoneNumber) =>
        phoneNumber.IsValidTenDigitNumber() ||
        phoneNumber.IsValidElevenDigitNumber();

    public static bool IsValidTenDigitNumber(this string phoneNumber) =>
        phoneNumber.Length == 10 &&
        phoneNumber[0] != '1' &&
        phoneNumber[0] != '0' &&
        phoneNumber[3] != '0' &&
        phoneNumber[3] != '1';

    public static bool IsValidElevenDigitNumber(this string phoneNumber) =>
        phoneNumber.Length == 11 &&
        phoneNumber[0] == '1' &&
        phoneNumber[1] != '1' &&
        phoneNumber[1] != '0' &&
        phoneNumber[4] != '0' &&
        phoneNumber[4] != '1';
}
