using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeightedGraph<L> 
{    double Cost(Location a, Location b);
    IEnumerable<Location> Neighbors(Location id);
}

public struct Location : IEquatable<Location>
{
    // Read/write auto-implemented properties.
    public int X { get; private set; }
    public int Y { get; private set; }

    public Location(int x, int y)
    {
        X = x;
        Y = x;
    }

    public override bool Equals(object obj)
    {
        if (obj is Location)
        {
            return this.Equals((Location)obj);
        }
        return false;
    }

    public bool Equals(Location p)
    {
        return (X == p.X) && (Y == p.Y);
    }

    public override int GetHashCode()
    {
        return X ^ Y;
    }

    public static bool operator ==(Location lhs, Location rhs)
    {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(Location lhs, Location rhs)
    {
        return !(lhs.Equals(rhs));
    }
}
