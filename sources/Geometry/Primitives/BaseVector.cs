namespace Dungeon.Geometry.Primitives;

/// <summary>
/// Presents standard operations which are common for all types of vectors
/// </summary>
/// <param name="X">Coordinate by X-axis</param>
/// <param name="Y">Coordinate by Y-axis</param>
public abstract record BaseVector(double X, double Y)
{
    public double Length() => Math.Sqrt(X * X + Y * Y);
    public double Dot(BaseVector other) => this.X * other.X + this.Y * other.Y;

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
    public double AngleBetween(BaseVector other) => Math.Acos(Dot(other) / (this.Length() * other.Length()));
}