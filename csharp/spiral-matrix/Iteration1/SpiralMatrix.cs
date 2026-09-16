using System.Linq;

public enum Direction
{
    Right,
    Down,
    Left,
    Up
}

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var results = new int[size, size];
        
        var direction = Direction.Right;        
        
        var step = size - 1;
        var curr = step;
        var times = 3;

        var row = 0;
        var col = 0;
        
        foreach (var i in Enumerable.Range(1, size * size))
        {
            results[row, col] = i;

            row += RowIncrement(direction);
            col += ColumnIncrement(direction);

            curr -= 1;
            
            if (curr == 0) {
                times -= 1;
                direction = NextDirection(direction);

                if (times == 0) {
                    step = Math.Max(1, step - 1);
                    times = 2;
                }

                curr = step;
            }
        }

        return results;
    }

    private static int RowIncrement(Direction currentDirection) =>
        currentDirection switch
        {
                Direction.Down => 1,
                Direction.Up => -1,
                _ => 0,
        };

    private static int ColumnIncrement(Direction currentDirection) =>
        currentDirection switch
        {
                Direction.Right => 1,
                Direction.Left => -1,
                _ => 0,
        };
    
    private static Direction NextDirection(Direction currentDirection) =>
        currentDirection switch
        {
                Direction.Right => Direction.Down,
                Direction.Down => Direction.Left,
                Direction.Left => Direction.Up,
                Direction.Up => Direction.Right,
        };
}
