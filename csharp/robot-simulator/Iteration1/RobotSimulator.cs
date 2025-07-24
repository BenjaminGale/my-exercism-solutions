using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{   
    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    public Direction Direction { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }

    public void Move(string instructions)
    {
        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case 'A':
                    Advance();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'L':
                    TurnLeft();
                    break;
            }
        }
    }

    private void TurnRight()
    {
        switch (Direction)
        {
            case Direction.North:
                Direction = Direction.East;
                break;
            case Direction.East:
                Direction = Direction.South;
                break;
            case Direction.South:
                Direction = Direction.West;
                break;
            case Direction.West:
                Direction = Direction.North;
                break;
        }
    }

    private void TurnLeft()
    {
        switch (Direction)
        {
            case Direction.North:
                Direction = Direction.West;
                break;
            case Direction.West:
                Direction = Direction.South;
                break;
            case Direction.South:
                Direction = Direction.East;
                break;
            case Direction.East:
                Direction = Direction.North;
                break;
        }
    }

    private void Advance()
    {
        switch (Direction)
        {
            case Direction.North:
                Y++;
                break;
            case Direction.East:
                X++;
                break;
            case Direction.West:
                X--;
                break;
            case Direction.South:
                Y--;
                break;
        }
    }
}
