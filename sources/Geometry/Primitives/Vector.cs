namespace Dungeon.Geometry.Primitives;
/**
 * @description
 * This class defines an easy interface to the vector in 2d space
 * 
 * @param {double} x - coordinate by X
 * @param {double} y - coordinate by Y
 */
public record Vector(double X, double Y)
{
    public static Vector operator +(Vector left, Vector right)
    {
        return new Vector(left.X + right.X, left.Y + right.Y);
    }

    public static Vector operator -(Vector left, Vector right)
    {
        return new Vector(left.X - right.X, left.Y - right.Y);
    }

    public static Vector operator -(Vector left)
    {
        return new Vector(-left.X, -left.Y);
    }

    public static Vector operator *(double coefficient, Vector right)
    {
        return new Vector(coefficient * right.X, coefficient * right.Y);
    }

    public static double Dot(Vector left, Vector right)
    {
        return left.X * right.X + left.Y * right.Y;
    }
}