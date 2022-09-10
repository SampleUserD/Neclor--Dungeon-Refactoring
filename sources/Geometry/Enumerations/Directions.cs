using Dungeon.Geometry.Primitives;

namespace Dungeon.Geometry.Enumerations;
public static class Directions
{
    public static readonly Vector Left = new Vector(-1.0, 0.0);
    public static readonly Vector Up = new Vector(0.0, -1.0);

    public static readonly Vector Right = -Left;
    public static readonly Vector Down = -Up;
}