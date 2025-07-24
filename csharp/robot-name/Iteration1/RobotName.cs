using System;
using System.Collections.Generic;

public class Robot
{
    private static readonly Random _random = new Random();
    private static readonly List<string> _robotNames = new List<string>();

    static Robot() =>
        GenerateRobotNames();

    private string _name = null;
    
    public string Name
    {
        get
        {
            if (_name == null)
            {
                var randomIndex = _random.Next(_robotNames.Count);
                _name = _robotNames[randomIndex];
                _robotNames.RemoveAt(randomIndex);
            }

            return _name;
        }
    }

    public void Reset()
    {
        _robotNames.Add(_name);
        _name = null;
    }

    private static void GenerateRobotNames()
    {
        for (char i = 'A'; i <= 'Z'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                for (int n = 0; n <= 999; n++)
                {
                    _robotNames.Add($"{i}{j}{n:000}");
                }
            }
        }
    }
}