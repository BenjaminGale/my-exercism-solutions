using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Plot(Coord topLeft, Coord topRight, Coord bottomLeft, Coord bottomRight)
    {
        TopLeft = topLeft;
        TopRight = topRight;
        BottomLeft = bottomLeft;
        BottomRight = bottomRight;
    }
    
    public Coord TopLeft { get; }
    public Coord TopRight { get; }
    public Coord BottomLeft { get; }
    public Coord BottomRight { get; }

    public int LongestSideLength =>
        new int[]
        {
            TopRight.X - TopLeft.X,
            BottomRight.X - BottomLeft.X,
            BottomLeft.Y - TopLeft.Y,
            BottomRight.Y - TopRight.Y
        }.Max();
}

public class ClaimsHandler
{
    private readonly ISet<Plot> _claimedPlots = new HashSet<Plot>();
    private Plot _lastClaim;
    
    public void StakeClaim(Plot plot)
    {
        _claimedPlots.Add(plot);
        _lastClaim = plot;
    }

    public bool IsClaimStaked(Plot plot) => 
        _claimedPlots.Contains(plot);

    public bool IsLastClaim(Plot plot) => 
        _lastClaim.Equals(plot);

    public Plot GetClaimWithLongestSide() =>
        _claimedPlots
            .OrderByDescending(plot => plot.LongestSideLength)
            .First();
}
