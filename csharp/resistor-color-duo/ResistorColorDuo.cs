using System;

public static class ResistorColorDuo
{
    public static int Value(string[] colors) =>
        (Value(colors[0]) * 10) + Value(colors[1]);

    private static int Value(string color) =>
        color switch
        {
            "black" => 0,
            "brown" => 1,
            "red" => 2,
            "orange" => 3,
            "yellow" => 4,
            "green" => 5,
            "blue" => 6,
            "violet" => 7,
            "grey" => 8,
            "white" => 9
        };
}
