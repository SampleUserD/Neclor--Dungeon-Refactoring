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
    public double Length() => Math.Sqrt(X * X + Y * Y);
    public double Dot(Vector other) => this.X * other.X + this.Y * other.Y;

    /// <summary>
    /// Calculate angle between vector and X-axis as known as direction.
    /// Angle belongs to interval (0; pi)
    /// </summary>
    /// <returns>Angle in radians</returns>
    public double Direction() => Math.Atan2(this.Y, this.X);

    /// <summary>
    /// Return angle between current vector and given vector.
    /// Angle belongs to interval (0; pi)
    /// </summary>
    /// <returns>Angle in radians</returns>
    public double AngleBetween(Vector other) => Math.Acos(Dot(other) / (this.Length() * other.Length()));

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
}