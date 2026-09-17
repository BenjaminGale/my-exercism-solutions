public static class LineUp
{
    public static string Format(string name, int number)
    {
        var numeral = number switch
        {
                var n when n % 10 == 1 && n % 100 != 11 => "st",
                var n when n % 10 == 2 && n % 100 != 12 => "nd",
                var n when n % 10 == 3 && n % 100 != 13 => "rd",
                _ => "th"
        };

        return $"{name}, you are the {number}{numeral} customer we serve today. Thank you!";
    }
}
