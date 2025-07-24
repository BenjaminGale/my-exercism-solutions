using System;

public class Queen
{
    public Queen(int row, int column)
    {
        if (row < 0 || row > 7 || column < 0 || column > 7)
            throw new ArgumentOutOfRangeException();
        
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }

    public bool OnSameRow(Queen other) =>
        Row == other.Row;

    public bool OnSameColumn(Queen other) =>
        Column == other.Column;

    public bool OnSameDiagonal(Queen other) =>
        Math.Abs(Row - other.Row) == Math.Abs(Column - other.Column);
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black) =>
        white.OnSameRow(black) || white.OnSameColumn(black) || white.OnSameDiagonal(black);

    public static Queen Create(int row, int column) =>
        new(row, column);
}
