namespace Dungeon.Geometry.Primitives;

/// <summary>
/// Represents vector on plane
/// </summary>
/// <param name="X">Coordinate by X-axis</param>
/// <param name="Y">Coordinate by Y-axis</param>
public record Vector(double X, double Y) : BaseVector(X, Y)
{
    public static Vector operator +(Vector left, Vector right)
    {
        return new(left.X + right.X, left.Y + right.Y);
    }

    public static Vector operator -(Vector left, Vector right)
    {
        return new(left.X - right.X, left.Y - right.Y);
    }

    public static Vector operator -(Vector left)
    {
        return new(-left.X, -left.Y);
    }

    public static Vector operator *(double coefficient, Vector right)
    {
        return new(coefficient * right.X, coefficient * right.Y);
    }
}